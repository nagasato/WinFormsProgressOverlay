namespace SampleWinFormsApp_netfx
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
            this.btnSimpleProcess = new System.Windows.Forms.Button();
            this.btnCancellableProcess = new System.Windows.Forms.Button();
            this.btnPartialDisable = new System.Windows.Forms.Button();
            this.btnKeepEnabled = new System.Windows.Forms.Button();
            this.btnCustomFont = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSimpleProcess
            // 
            this.btnSimpleProcess.Location = new System.Drawing.Point(22, 50);
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
            this.btnCancellableProcess.Location = new System.Drawing.Point(22, 86);
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
            this.btnKeepEnabled.Location = new System.Drawing.Point(22, 236);
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
            this.btnCustomFont.Location = new System.Drawing.Point(22, 294);
            this.btnCustomFont.Margin = new System.Windows.Forms.Padding(2);
            this.btnCustomFont.Name = "btnCustomFont";
            this.btnCustomFont.Size = new System.Drawing.Size(202, 32);
            this.btnCustomFont.TabIndex = 6;
            this.btnCustomFont.Text = "カスタムフォント";
            this.btnCustomFont.UseVisualStyleBackColor = true;
            this.btnCustomFont.Click += new System.EventHandler(this.btnCustomFont_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(248, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 288);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Panel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "[Formにオーバーレイ]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "[Panelにオーバーレイ]";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(827, 500);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCustomFont);
            this.Controls.Add(this.btnKeepEnabled);
            this.Controls.Add(this.btnPartialDisable);
            this.Controls.Add(this.btnCancellableProcess);
            this.Controls.Add(this.btnSimpleProcess);
            this.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "処理中オーバーレイ サンプル (.NET Framework)";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
