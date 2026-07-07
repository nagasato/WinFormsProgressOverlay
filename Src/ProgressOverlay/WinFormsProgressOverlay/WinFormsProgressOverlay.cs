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
    /// usingステートメントで使用し、ブロック内の処理中にオーバーレイを表示する。
    /// </summary>
    public class ProgressOverlay : IDisposable
    {
        private readonly Control _hostControl;
        private readonly OverlayForm _overlay;
        private readonly CancellationTokenSource _cts;
        private readonly List<Control> _disabledControls;
        private readonly bool _wasHostControlEnabled;

        // use IDisposable.
        private bool _disposed = false;

        /// <summary>
        /// キャンセルトークン
        /// </summary>
        public CancellationToken CancellationToken => _cts.Token;

        /// <summary>
        /// Private コンストラクタ
        /// </summary>
        /// <param name="hostControl">オーバーレイされるコントロール</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="cancellable">キャンセル可能かどうか</param>
        /// <param name="disableControls">無効化するコントロールのリスト（nullの場合はホストコントロール全体を無効化）</param>
        /// <param name="messageFont">メッセージのフォント（nullの場合はホストコントロールのフォントを使用）</param>
        private ProgressOverlay(Control hostControl, string message, bool cancellable, IEnumerable<Control> disableControls, Font messageFont)
        {
            if (hostControl == null)
            {
                throw new ArgumentNullException(nameof(hostControl));
            }

            _hostControl = hostControl;
            _cts = new CancellationTokenSource();
            _disabledControls = new List<Control>();
            _wasHostControlEnabled = _hostControl.Enabled;

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
                // ホストコントロール全体を無効化（デフォルト動作）
                _hostControl.Enabled = false;
            }

            // メッセージフォントが指定されていない場合はホストコントロールのフォントを使用
            Font fontToUse = messageFont ?? _hostControl.Font;

            // オーバーレイフォームの作成と表示
            _overlay = new OverlayForm(
                message,
                cancellable,
                () => _cts.Cancel(),
                fontToUse
                );

            // ホストコントロールのクライアント領域に合わせてオーバーレイを配置
            this.UpdateOverlayBounds();

            // ホストコントロールのイベントにハンドラを登録（移動・リサイズ・状態変更に追従）
            if (_hostControl is Form)
            {
                _hostControl.Move += HostControl_MoveOrResize;
            }
            else
            {
                var parentForm = _hostControl.FindForm();
                parentForm.Move += HostControl_MoveOrResize;
            }
            _hostControl.Resize += HostControl_MoveOrResize;
            _hostControl.SizeChanged += HostControl_MoveOrResize;

            // オーバーレイを表示
            _overlay.Show(_hostControl);

            // UIの更新を強制
            Application.DoEvents();
        }

        /// <summary>
        /// ホストコントロールの移動・リサイズイベントハンドラ
        /// </summary>
        private void HostControl_MoveOrResize(object sender, EventArgs e)
        {
            if (_overlay != null && !_overlay.IsDisposed)
            {
                this.UpdateOverlayBounds();
            }
        }

        /// <summary>
        /// オーバーレイの位置とサイズをホストコントロールのクライアント領域に合わせて更新
        /// </summary>
        private void UpdateOverlayBounds()
        {
            if (_hostControl != null && !_hostControl.IsDisposed && _overlay != null && !_overlay.IsDisposed)
            {
                // ホストコントロールのクライアント領域の画面上の座標を取得
                var clientRect = _hostControl.RectangleToScreen(_hostControl.ClientRectangle);
                _overlay.Bounds = clientRect;
            }
        }

        /// <summary>
        /// オーバーレイを表示する（ホストコントロール全体を無効化）
        /// </summary>
        /// <param name="hostControl">オーバーレイされるコントロール</param>
        /// <param name="message">表示メッセージ（デフォルト: "処理中..."）</param>
        /// <param name="cancellable">キャンセル可能かどうか（デフォルト: false）</param>
        /// <param name="messageFont">メッセージのフォント（nullの場合はホストコントロールのフォントを使用）</param>
        /// <returns>ProcessingOverlayインスタンス</returns>
        public static ProgressOverlay Show(Control hostControl, string message = "処理中...", bool cancellable = false, Font messageFont = null)
        {
            return new ProgressOverlay(hostControl, message, cancellable, null, messageFont);
        }

        /// <summary>
        /// オーバーレイを表示する（指定されたコントロールのみを無効化）
        /// </summary>
        /// <param name="hostControl">オーバーレイされるコントロール</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="disableControls">無効化するコントロールのリスト</param>
        /// <param name="cancellable">キャンセル可能かどうか（デフォルト: false）</param>
        /// <param name="messageFont">メッセージのフォント（nullの場合はホストコントロールのフォントを使用）</param>
        /// <returns>ProcessingOverlayインスタンス</returns>
        public static ProgressOverlay Show(Control hostControl, string message, IEnumerable<Control> disableControls, bool cancellable = false, Font messageFont = null)
        {
            return new ProgressOverlay(hostControl, message, cancellable, disableControls, messageFont);
        }

        /// <summary>
        /// オーバーレイを表示する（指定されたコントロールのみを無効化、可変長引数版）
        /// </summary>
        /// <param name="hostControl">オーバーレイされるフォーム</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="cancellable">キャンセル可能かどうか</param>
        /// <param name="messageFont">メッセージのフォント（nullの場合はホストコントロールのフォントを使用）</param>
        /// <param name="disableControls">無効化するコントロール（可変長引数）</param>
        /// <returns>ProcessingOverlayインスタンス</returns>
        [Obsolete("このオーバーロードは非推奨です。Showメソッドを使用してください。")]
        public static ProgressOverlay ShowWithControls(Form hostForm, string message, bool cancellable, Font messageFont, params Control[] disableControls)
        {
            return new ProgressOverlay(hostForm, message, cancellable, disableControls, messageFont);
        }

        /// <summary>
        /// オーバーレイを表示する（指定されたコントロールのみを無効化、可変長引数版、フォント省略）
        /// </summary>
        /// <param name="hostForm">オーバーレイされるフォーム</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="cancellable">キャンセル可能かどうか</param>
        /// <param name="disableControls">無効化するコントロール（可変長引数）</param>
        /// <returns>ProcessingOverlayインスタンス</returns>
        [Obsolete("このオーバーロードは非推奨です。Showメソッドを使用してください。")]
        public static ProgressOverlay ShowWithControls(Form hostForm, string message, bool cancellable, params Control[] disableControls)
        {
            return new ProgressOverlay(hostForm, message, cancellable, disableControls, null);
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
                    // ホストコントロールのイベントハンドラを解除
                    if (_hostControl != null && !_hostControl.IsDisposed)
                    {
                        if (_hostControl is Form)
                        {
                            _hostControl.Move -= HostControl_MoveOrResize;
                        }
                        else
                        {
                            var parentForm = _hostControl.FindForm();
                            if (parentForm != null && !parentForm.IsDisposed)
                            {
                                parentForm.Move -= HostControl_MoveOrResize;
                            }
                        }
                        _hostControl.Resize -= HostControl_MoveOrResize;
                        _hostControl.SizeChanged -= HostControl_MoveOrResize;
                    }

                    // オーバーレイを閉じる
                    if (_overlay != null && !_overlay.IsDisposed)
                    {
                        _overlay.Close();
                        _overlay.Dispose();
                    }

                    // UI操作の有効化
                    if (_hostControl != null && !_hostControl.IsDisposed)
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
                            // ホストコントロール全体を有効化
                            _hostControl.Enabled = _wasHostControlEnabled;
                        }

                        // 親Formのフォーカスを復元
                        var form = _hostControl.FindForm();
                        form?.Activate();
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
