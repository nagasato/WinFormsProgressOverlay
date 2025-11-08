using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsProgressOverlay;

namespace SampleWinFormsApp_netfx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// シンプルな処理のデモ
        /// </summary>
        private async void btnSimpleProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // using方式でオーバーレイを表示
                // フォントを省略すると親Formのフォントが使用される
                using (var overlay = ProgressOverlay.Show(this, "データを読み込んでいます..."))
                {
                    // ** このブロックに非同期処理を記述する **

                    // 何か時間のかかる処理をシミュレート
                    await Task.Delay(3000);
                }

                MessageBox.Show("処理が完了しました！", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// キャンセル可能な処理のデモ
        /// </summary>
        private async void btnCancellableProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // using方式でキャンセル可能なオーバーレイを表示
                using (var overlay = ProgressOverlay.Show(this, "長時間処理を実行中...\n（キャンセル可能）", cancellable: true))
                {
                    // ** このブロックに非同期処理を記述する **

                    // 10秒かかる処理をシミュレート（1秒ごとにキャンセルチェック）
                    for (int i = 0; i < 10; i++)
                    {
                        overlay.CancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, overlay.CancellationToken);

                        // メッセージを動的に更新
                        overlay.UpdateMessage($"長時間処理を実行中... ({i + 1}/10)\n（キャンセル可能）");
                    }
                }

                MessageBox.Show("処理が完了しました！", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("処理がキャンセルされました。", "キャンセル", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 一部のボタンのみを無効化するデモ
        /// </summary>
        private async void btnPartialDisable_Click(object sender, EventArgs e)
        {
            try
            {
                // 特定のボタンのみを無効化（btnKeepEnabledは有効のまま）
                using (var overlay = ProgressOverlay.ShowWithControls(
                    this,
                    "一部のボタンのみ無効化中...\n「有効のまま」ボタンはクリック可能です",
                    cancellable: true,
                    btnSimpleProcess,
                    btnCancellableProcess,
                    btnPartialDisable
                    ))
                {
                    // ** このブロックに非同期処理を記述する **

                    // 10秒かかる処理をシミュレート
                    for (int i = 0; i < 10; i++)
                    {
                        overlay.CancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, overlay.CancellationToken);
                    }
                }

                MessageBox.Show("処理が完了しました！", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("処理がキャンセルされました。", "キャンセル", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 常に有効なボタンのクリックイベント
        /// </summary>
        private void btnKeepEnabled_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "このボタンは「一部のボタンのみ無効化」処理中でもクリック可能です！",
                "情報",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// カスタムフォントのデモ
        /// </summary>
        private async void btnCustomFont_Click(object sender, EventArgs e)
        {
            try
            {
                // カスタムフォントを指定してオーバーレイを表示
                Font customFont = new Font("MS ゴシック", 16F, FontStyle.Bold);
                using (var overlay = ProgressOverlay.Show(
                    this,
                    "カスタムフォントで表示中...",
                    cancellable: false,
                    customFont
                    ))
                {
                    // ** このブロックに非同期処理を記述する **

                    for (int i = 0; i < 5; i++)
                    {
                        await Task.Delay(1000);
                        overlay.UpdateMessage($"カスタムフォントで表示中... ({i + 1}/5)");
                    }
                }

                MessageBox.Show("処理が完了しました！", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
