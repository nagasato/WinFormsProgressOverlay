namespace SampleWinFormsApp_net8
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnSimpleProcess = new System.Windows.Forms.Button();
            btnCancellableProcess = new System.Windows.Forms.Button();
            btnPartialDisable = new System.Windows.Forms.Button();
            btnKeepEnabled = new System.Windows.Forms.Button();
            btnCustomFont = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSimpleProcess
            // 
            btnSimpleProcess.Location = new System.Drawing.Point(22, 50);
            btnSimpleProcess.Margin = new System.Windows.Forms.Padding(2);
            btnSimpleProcess.Name = "btnSimpleProcess";
            btnSimpleProcess.Size = new System.Drawing.Size(202, 32);
            btnSimpleProcess.TabIndex = 0;
            btnSimpleProcess.Text = "シンプルな処理";
            btnSimpleProcess.UseVisualStyleBackColor = true;
            btnSimpleProcess.Click += btnSimpleProcess_Click;
            // 
            // btnCancellableProcess
            // 
            btnCancellableProcess.Location = new System.Drawing.Point(22, 86);
            btnCancellableProcess.Margin = new System.Windows.Forms.Padding(2);
            btnCancellableProcess.Name = "btnCancellableProcess";
            btnCancellableProcess.Size = new System.Drawing.Size(202, 32);
            btnCancellableProcess.TabIndex = 1;
            btnCancellableProcess.Text = "キャンセル可能な処理";
            btnCancellableProcess.UseVisualStyleBackColor = true;
            btnCancellableProcess.Click += btnCancellableProcess_Click;
            // 
            // btnPartialDisable
            // 
            btnPartialDisable.Location = new System.Drawing.Point(22, 200);
            btnPartialDisable.Margin = new System.Windows.Forms.Padding(2);
            btnPartialDisable.Name = "btnPartialDisable";
            btnPartialDisable.Size = new System.Drawing.Size(202, 32);
            btnPartialDisable.TabIndex = 4;
            btnPartialDisable.Text = "一部のボタンのみ無効化";
            btnPartialDisable.UseVisualStyleBackColor = true;
            btnPartialDisable.Click += btnPartialDisable_Click;
            // 
            // btnKeepEnabled
            // 
            btnKeepEnabled.Location = new System.Drawing.Point(22, 236);
            btnKeepEnabled.Margin = new System.Windows.Forms.Padding(2);
            btnKeepEnabled.Name = "btnKeepEnabled";
            btnKeepEnabled.Size = new System.Drawing.Size(202, 32);
            btnKeepEnabled.TabIndex = 5;
            btnKeepEnabled.Text = "有効のまま（クリック可能）";
            btnKeepEnabled.UseVisualStyleBackColor = true;
            btnKeepEnabled.Click += btnKeepEnabled_Click;
            // 
            // btnCustomFont
            // 
            btnCustomFont.Location = new System.Drawing.Point(22, 294);
            btnCustomFont.Margin = new System.Windows.Forms.Padding(2);
            btnCustomFont.Name = "btnCustomFont";
            btnCustomFont.Size = new System.Drawing.Size(202, 32);
            btnCustomFont.TabIndex = 6;
            btnCustomFont.Text = "カスタムフォント";
            btnCustomFont.UseVisualStyleBackColor = true;
            btnCustomFont.Click += btnCustomFont_Click;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Location = new System.Drawing.Point(248, 200);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(567, 288);
            panel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 5);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 20);
            label1.TabIndex = 0;
            label1.Text = "Panel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(22, 19);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(153, 20);
            label2.TabIndex = 8;
            label2.Text = "[Formにオーバーレイ]";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(22, 169);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(154, 20);
            label3.TabIndex = 9;
            label3.Text = "[Panelにオーバーレイ]";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(827, 500);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(btnCustomFont);
            Controls.Add(btnKeepEnabled);
            Controls.Add(btnPartialDisable);
            Controls.Add(btnCancellableProcess);
            Controls.Add(btnSimpleProcess);
            Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Margin = new System.Windows.Forms.Padding(2);
            Name = "Form1";
            Text = "処理中オーバーレイ サンプル (.NET 8)";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSimpleProcess;
        private System.Windows.Forms.Button btnCancellableProcess;
        private System.Windows.Forms.Button btnPartialDisable;
        private System.Windows.Forms.Button btnKeepEnabled;
        private System.Windows.Forms.Button btnCustomFont;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
