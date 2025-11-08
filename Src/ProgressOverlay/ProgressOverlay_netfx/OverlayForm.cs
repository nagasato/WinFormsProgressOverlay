using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsProgressOverlay
{
    /// <summary>
    /// 処理中を表現する半透明のオーバーレイフォーム
    /// </summary>
    public partial class OverlayForm : Form
    {
        private Action _cancelAction;

        public OverlayForm(string message, bool showCancelButton, Action onCancel, Font messageFont)
        {
            InitializeComponent();

            this.InitializeControls(message, showCancelButton, messageFont);
            _cancelAction = onCancel;
        }

        private void InitializeControls(string message, bool showCancelButton, Font messageFont)
        {
            // フォームの基本設定 (Formデザイナ設定済みでも、重要な部分を上書き)
            this.FormBorderStyle = FormBorderStyle.None;
            //this.BackColor = Color.Black;
            //this.Opacity = 0.7;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ControlBox = false;

            // ボタン有り/無しと、中央パネルのサイズ調整
            if (showCancelButton)
            {
                // キャンセルボタンのクリックイベントハンドラ
                cancelButton.Click += (s, e) =>
                {
                    if (cancelButton != null)
                    {
                        cancelButton.Enabled = false;
                        cancelButton.Text = "キャンセル中...";
                    }

                    _cancelAction?.Invoke();
                };
            }
            else
            {
                var buttonSize = cancelButton.Size; // Size is struct.
                centerPanel.Controls.Remove(cancelButton);
                centerPanel.Size = new Size(centerPanel.Width, centerPanel.Height - buttonSize.Height);
            }

            // パネルを画面中央に配置
            centerPanel.Location = new Point(
                (this.ClientSize.Width - centerPanel.Width) / 2,
                (this.ClientSize.Height - centerPanel.Height) / 2);
            centerPanel.Anchor = AnchorStyles.None;

            // リサイズしてもパネルの中央を維持
            this.Resize += (s, e) =>
            {
                centerPanel.Location = new Point(
                       (this.ClientSize.Width - centerPanel.Width) / 2,
                       (this.ClientSize.Height - centerPanel.Height) / 2
                     );
            };

            // メッセージラベルの設定
            messageLabel.Font = messageFont;
            messageLabel.Text = message;
        }

        /// <summary>
        /// メッセージを更新する
        /// </summary>
        public void UpdateMessage(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateMessage(message)));
                return;
            }
            messageLabel.Text = message;
        }
    }
}
