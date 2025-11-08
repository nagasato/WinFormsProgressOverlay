namespace SampleWinFormsApp_netfx
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
   {
                components.Dispose();
            }
       base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
     /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSimpleProcess = new System.Windows.Forms.Button();
            this.btnCancellableProcess = new System.Windows.Forms.Button();
            this.btnPartialDisable = new System.Windows.Forms.Button();
            this.btnKeepEnabled = new System.Windows.Forms.Button();
            this.btnCustomFont = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSimpleProcess
            // 
            this.btnSimpleProcess.Location = new System.Drawing.Point(22, 24);
            this.btnSimpleProcess.Margin = new System.Windows.Forms.Padding(2);
            this.btnSimpleProcess.Name = "btnSimpleProcess";
            this.btnSimpleProcess.Size = new System.Drawing.Size(202, 32);
            this.btnSimpleProcess.TabIndex = 0;
            this.btnSimpleProcess.Text = "シンプルな処理";
            this.btnSimpleProcess.UseVisualStyleBackColor = true;
            this.btnSimpleProcess.Click += new System.EventHandler(this.btnSimpleProcess_Click);
            // 
            // btnCancellableProcess
            // 
            this.btnCancellableProcess.Location = new System.Drawing.Point(22, 72);
            this.btnCancellableProcess.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancellableProcess.Name = "btnCancellableProcess";
            this.btnCancellableProcess.Size = new System.Drawing.Size(202, 32);
            this.btnCancellableProcess.TabIndex = 1;
            this.btnCancellableProcess.Text = "キャンセル可能な処理";
            this.btnCancellableProcess.UseVisualStyleBackColor = true;
            this.btnCancellableProcess.Click += new System.EventHandler(this.btnCancellableProcess_Click);
            // 
            // btnPartialDisable
            // 
            this.btnPartialDisable.Location = new System.Drawing.Point(22, 200);
            this.btnPartialDisable.Margin = new System.Windows.Forms.Padding(2);
            this.btnPartialDisable.Name = "btnPartialDisable";
            this.btnPartialDisable.Size = new System.Drawing.Size(202, 32);
            this.btnPartialDisable.TabIndex = 4;
            this.btnPartialDisable.Text = "一部のボタンのみ無効化";
            this.btnPartialDisable.UseVisualStyleBackColor = true;
            this.btnPartialDisable.Click += new System.EventHandler(this.btnPartialDisable_Click);
            // 
            // btnKeepEnabled
            // 
            this.btnKeepEnabled.Location = new System.Drawing.Point(22, 248);
            this.btnKeepEnabled.Margin = new System.Windows.Forms.Padding(2);
            this.btnKeepEnabled.Name = "btnKeepEnabled";
            this.btnKeepEnabled.Size = new System.Drawing.Size(202, 32);
            this.btnKeepEnabled.TabIndex = 5;
            this.btnKeepEnabled.Text = "有効のまま（クリック可能）";
            this.btnKeepEnabled.UseVisualStyleBackColor = true;
            this.btnKeepEnabled.Click += new System.EventHandler(this.btnKeepEnabled_Click);
            // 
            // btnCustomFont
            // 
            this.btnCustomFont.Location = new System.Drawing.Point(22, 296);
            this.btnCustomFont.Margin = new System.Windows.Forms.Padding(2);
            this.btnCustomFont.Name = "btnCustomFont";
            this.btnCustomFont.Size = new System.Drawing.Size(202, 32);
            this.btnCustomFont.TabIndex = 6;
            this.btnCustomFont.Text = "カスタムフォント";
            this.btnCustomFont.UseVisualStyleBackColor = true;
            this.btnCustomFont.Click += new System.EventHandler(this.btnCustomFont_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(832, 484);
            this.Controls.Add(this.btnCustomFont);
            this.Controls.Add(this.btnKeepEnabled);
            this.Controls.Add(this.btnPartialDisable);
            this.Controls.Add(this.btnCancellableProcess);
            this.Controls.Add(this.btnSimpleProcess);
            this.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "処理中オーバーレイ サンプル";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSimpleProcess;
        private System.Windows.Forms.Button btnCancellableProcess;
        private System.Windows.Forms.Button btnPartialDisable;
        private System.Windows.Forms.Button btnKeepEnabled;
        private System.Windows.Forms.Button btnCustomFont;
    }
}
