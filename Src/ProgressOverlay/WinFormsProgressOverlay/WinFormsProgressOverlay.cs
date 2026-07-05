using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsProgressOverlay
{
    /// <summary>
    /// 処理中オーバーレイを表示するクラス
    /// usingステートメントで使用し、ブロック内の処理中にオーバーレイを表示します
    /// </summary>
    public class ProgressOverlay : IDisposable
    {
        private readonly Form _owner;
        private readonly OverlayForm _overlay;
        private readonly CancellationTokenSource _cts;
        private readonly List<Control> _disabledControls;
        private readonly bool _wasOwnerEnabled;

        // use IDisposable.
        private bool _disposed = false;

        /// <summary>
        /// キャンセルトークン
        /// </summary>
        public CancellationToken CancellationToken => _cts.Token;

        /// <summary>
        /// Private コンストラクタ
        /// </summary>
        /// <param name="owner">呼び出し元のフォーム</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="cancellable">キャンセル可能かどうか</param>
        /// <param name="disableControls">無効化するコントロールのリスト（nullの場合はForm全体を無効化）</param>
        /// <param name="messageFont">メッセージのフォント（nullの場合は親Formのフォントを使用）</param>
        private ProgressOverlay(Form owner, string message, bool cancellable, IEnumerable<Control> disableControls, Font messageFont)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            _owner = owner;
            _cts = new CancellationTokenSource();
            _disabledControls = new List<Control>();
            _wasOwnerEnabled = _owner.Enabled;

            // UI操作の無効化
            if (disableControls != null)
            {
                // 指定されたコントロールのみを無効化
                foreach (var control in disableControls)
                {
                    if (control != null && control.Enabled)
                    {
                        control.Enabled = false;
                        _disabledControls.Add(control);
                    }
                }
            }
            else
            {
                // Form全体を無効化（デフォルト動作）
                _owner.Enabled = false;
            }

            // メッセージフォントが指定されていない場合は親Formのフォントを使用
            Font fontToUse = messageFont ?? _owner.Font;

            // オーバーレイフォームの作成と表示
            _overlay = new OverlayForm(
                message,
                cancellable,
                () => _cts.Cancel(),
                fontToUse
                );

            // 親Formのクライアント領域に合わせてオーバーレイを配置
            this.UpdateOverlayBounds();

            // 親Formのイベントにハンドラを登録（移動・リサイズ・状態変更に追従）
            _owner.Move += owner_MoveOrResize;
            _owner.Resize += owner_MoveOrResize;
            _owner.SizeChanged += owner_MoveOrResize;

            // オーバーレイを表示
            _overlay.Show(_owner);

            // UIの更新を強制
            Application.DoEvents();
        }

        /// <summary>
        /// 親Formの移動・リサイズイベントハンドラ
        /// </summary>
        private void owner_MoveOrResize(object sender, EventArgs e)
        {
            if (_overlay != null && !_overlay.IsDisposed)
            {
                this.UpdateOverlayBounds();
            }
        }

        /// <summary>
        /// オーバーレイの位置とサイズを親Formのクライアント領域に合わせて更新
        /// </summary>
        private void UpdateOverlayBounds()
        {
            if (_owner != null && !_owner.IsDisposed && _overlay != null && !_overlay.IsDisposed)
            {
                // 親Formのクライアント領域の画面上の座標を取得
                var clientRect = _owner.RectangleToScreen(_owner.ClientRectangle);
                _overlay.Bounds = clientRect;
            }
        }

        /// <summary>
        /// オーバーレイを表示する（Form全体を無効化）
        /// </summary>
        /// <param name="owner">呼び出し元のフォーム</param>
        /// <param name="message">表示メッセージ（デフォルト: "処理中..."）</param>
        /// <param name="cancellable">キャンセル可能かどうか（デフォルト: false）</param>
        /// <param name="messageFont">メッセージのフォント（nullの場合は親Formのフォントを使用）</param>
        /// <returns>ProcessingOverlayインスタンス</returns>
        public static ProgressOverlay Show(Form owner, string message = "処理中...", bool cancellable = false, Font messageFont = null)
        {
            return new ProgressOverlay(owner, message, cancellable, null, messageFont);
        }

        /// <summary>
        /// オーバーレイを表示する（指定されたコントロールのみを無効化）
        /// </summary>
        /// <param name="owner">呼び出し元のフォーム</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="disableControls">無効化するコントロールのリスト</param>
        /// <param name="cancellable">キャンセル可能かどうか（デフォルト: false）</param>
        /// <param name="messageFont">メッセージのフォント（nullの場合は親Formのフォントを使用）</param>
        /// <returns>ProcessingOverlayインスタンス</returns>
        public static ProgressOverlay Show(Form owner, string message, IEnumerable<Control> disableControls, bool cancellable = false, Font messageFont = null)
        {
            return new ProgressOverlay(owner, message, cancellable, disableControls, messageFont);
        }

        /// <summary>
        /// オーバーレイを表示する（指定されたコントロールのみを無効化、可変長引数版）
        /// </summary>
        /// <param name="owner">呼び出し元のフォーム</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="cancellable">キャンセル可能かどうか</param>
        /// <param name="messageFont">メッセージのフォント（nullの場合は親Formのフォントを使用）</param>
        /// <param name="disableControls">無効化するコントロール（可変長引数）</param>
        /// <returns>ProcessingOverlayインスタンス</returns>
        public static ProgressOverlay ShowWithControls(Form owner, string message, bool cancellable, Font messageFont, params Control[] disableControls)
        {
            return new ProgressOverlay(owner, message, cancellable, disableControls, messageFont);
        }

        /// <summary>
        /// オーバーレイを表示する（指定されたコントロールのみを無効化、可変長引数版、フォント省略）
        /// </summary>
        /// <param name="owner">呼び出し元のフォーム</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="cancellable">キャンセル可能かどうか</param>
        /// <param name="disableControls">無効化するコントロール（可変長引数）</param>
        /// <returns>ProcessingOverlayインスタンス</returns>
        public static ProgressOverlay ShowWithControls(Form owner, string message, bool cancellable, params Control[] disableControls)
        {
            return new ProgressOverlay(owner, message, cancellable, disableControls, null);
        }

        /// <summary>
        /// 表示メッセージを更新する
        /// </summary>
        /// <param name="message">新しいメッセージ</param>
        public void UpdateMessage(string message)
        {
            if (_overlay != null && !_overlay.IsDisposed)
            {
                _overlay.UpdateMessage(message);
            }
        }


        /// <summary>
        /// リソースを解放する
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// リソースを解放する（内部実装）
        /// </summary>
        /// <param name="disposing">マネージドリソースを解放するかどうか</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // 親Formのイベントハンドラを解除
                    if (_owner != null && !_owner.IsDisposed)
                    {
                        _owner.Move -= owner_MoveOrResize;
                        _owner.Resize -= owner_MoveOrResize;
                        _owner.SizeChanged -= owner_MoveOrResize;
                    }

                    // オーバーレイを閉じる
                    if (_overlay != null && !_overlay.IsDisposed)
                    {
                        _overlay.Close();
                        _overlay.Dispose();
                    }

                    // UI操作の有効化
                    if (_owner != null && !_owner.IsDisposed)
                    {
                        if (_disabledControls.Any())
                        {
                            // 無効化したコントロールを有効化
                            foreach (var control in _disabledControls)
                            {
                                if (control != null && !control.IsDisposed)
                                {
                                    control.Enabled = true;
                                }
                            }
                        }
                        else
                        {
                            // Form全体を有効化
                            _owner.Enabled = _wasOwnerEnabled;
                        }

                        _owner.Activate();
                    }

                    // CancellationTokenSourceを解放
                    if (_cts != null)
                    {
                        _cts.Dispose();
                    }
                }

                _disposed = true;
            }
        }
    }
}
