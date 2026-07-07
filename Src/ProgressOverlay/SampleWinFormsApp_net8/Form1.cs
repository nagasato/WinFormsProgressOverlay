using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsProgressOverlay;

namespace SampleWinFormsApp_net8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSimpleProcess_Click(object sender, EventArgs e)
        {
            try
            {
                using (var overlay = ProgressOverlay.Show(this, "データを読み込んでいます..."))
                {
                    await Task.Delay(3000);
                }

                MessageBox.Show("処理が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCancellableProcess_Click(object sender, EventArgs e)
        {
            try
            {
                using (var overlay = ProgressOverlay.Show(this, "長時間処理を実行中...\n(キャンセル可能)", cancellable: true))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        overlay.CancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, overlay.CancellationToken);
                        overlay.UpdateMessage($"長時間処理を実行中... ({i + 1}/10)\n(キャンセル可能)");
                    }
                }

                MessageBox.Show("処理が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("処理はキャンセルされました。", "キャンセル", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnPartialDisable_Click(object sender, EventArgs e)
        {
            try
            {
                var disableControls = new Control[] { btnSimpleProcess, btnCancellableProcess, btnPartialDisable, btnCustomFont };
                using (var overlay = ProgressOverlay.Show(
                    panel1,
                    "一部のボタンのみ無効化しています...\n[有効のまま] ボタンはクリック可能です",
                    disableControls,
                    cancellable: true))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        overlay.CancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, overlay.CancellationToken);
                    }
                }

                MessageBox.Show("処理が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("処理はキャンセルされました。", "キャンセル", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKeepEnabled_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "このボタンは「一部のボタンのみ無効化」実行中でもクリック可能です。",
                "確認",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private async void btnCustomFont_Click(object sender, EventArgs e)
        {
            try
            {
                using (var customFont = new Font("MS Gothic", 16F, FontStyle.Bold))
                using (var overlay = ProgressOverlay.Show(
                    panel1,
                    "カスタムフォントで表示中...",
                    cancellable: false,
                    customFont))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        await Task.Delay(1000);
                        overlay.UpdateMessage($"カスタムフォントで表示中... ({i + 1}/5)");
                    }
                }

                MessageBox.Show("処理が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
