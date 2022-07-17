namespace UmamusumeChoicesChecker
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
            this.lblChoices1 = new System.Windows.Forms.Label();
            this.lblChoices2 = new System.Windows.Forms.Label();
            this.btnCheckStart = new System.Windows.Forms.Button();
            this.picChoices1 = new System.Windows.Forms.PictureBox();
            this.picChoices2 = new System.Windows.Forms.PictureBox();
            this.lblStatusTitle1 = new System.Windows.Forms.Label();
            this.lblStatusTitle2 = new System.Windows.Forms.Label();
            this.lblStatus1 = new System.Windows.Forms.Label();
            this.lblStatus2 = new System.Windows.Forms.Label();
            this.btnCheckEnd = new System.Windows.Forms.Button();
            this.lblStatus3 = new System.Windows.Forms.Label();
            this.lblStatusTitle3 = new System.Windows.Forms.Label();
            this.picChoices3 = new System.Windows.Forms.PictureBox();
            this.lblChoices3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picChoices1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChoices2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChoices3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblChoices1
            // 
            this.lblChoices1.AutoSize = true;
            this.lblChoices1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblChoices1.Location = new System.Drawing.Point(4, 0);
            this.lblChoices1.Name = "lblChoices1";
            this.lblChoices1.Size = new System.Drawing.Size(74, 24);
            this.lblChoices1.TabIndex = 2;
            this.lblChoices1.Text = "選択肢１";
            // 
            // lblChoices2
            // 
            this.lblChoices2.AutoSize = true;
            this.lblChoices2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblChoices2.Location = new System.Drawing.Point(4, 0);
            this.lblChoices2.Name = "lblChoices2";
            this.lblChoices2.Size = new System.Drawing.Size(74, 24);
            this.lblChoices2.TabIndex = 4;
            this.lblChoices2.Text = "選択肢２";
            // 
            // btnCheckStart
            // 
            this.btnCheckStart.Location = new System.Drawing.Point(230, 738);
            this.btnCheckStart.Name = "btnCheckStart";
            this.btnCheckStart.Size = new System.Drawing.Size(138, 35);
            this.btnCheckStart.TabIndex = 7;
            this.btnCheckStart.Text = "判定開始！";
            this.btnCheckStart.UseVisualStyleBackColor = true;
            this.btnCheckStart.Click += new System.EventHandler(this.btnCheckStartClicked);
            // 
            // picChoices1
            // 
            this.picChoices1.BackColor = System.Drawing.Color.White;
            this.picChoices1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picChoices1.Location = new System.Drawing.Point(4, 27);
            this.picChoices1.Name = "picChoices1";
            this.picChoices1.Size = new System.Drawing.Size(488, 85);
            this.picChoices1.TabIndex = 8;
            this.picChoices1.TabStop = false;
            // 
            // picChoices2
            // 
            this.picChoices2.BackColor = System.Drawing.Color.White;
            this.picChoices2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picChoices2.Location = new System.Drawing.Point(4, 27);
            this.picChoices2.Name = "picChoices2";
            this.picChoices2.Size = new System.Drawing.Size(488, 83);
            this.picChoices2.TabIndex = 9;
            this.picChoices2.TabStop = false;
            // 
            // lblStatusTitle1
            // 
            this.lblStatusTitle1.AutoSize = true;
            this.lblStatusTitle1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStatusTitle1.Location = new System.Drawing.Point(4, 115);
            this.lblStatusTitle1.Name = "lblStatusTitle1";
            this.lblStatusTitle1.Size = new System.Drawing.Size(35, 20);
            this.lblStatusTitle1.TabIndex = 10;
            this.lblStatusTitle1.Text = "効果";
            // 
            // lblStatusTitle2
            // 
            this.lblStatusTitle2.AutoSize = true;
            this.lblStatusTitle2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStatusTitle2.Location = new System.Drawing.Point(4, 113);
            this.lblStatusTitle2.Name = "lblStatusTitle2";
            this.lblStatusTitle2.Size = new System.Drawing.Size(35, 20);
            this.lblStatusTitle2.TabIndex = 11;
            this.lblStatusTitle2.Text = "効果";
            // 
            // lblStatus1
            // 
            this.lblStatus1.AutoSize = true;
            this.lblStatus1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStatus1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus1.Location = new System.Drawing.Point(6, 135);
            this.lblStatus1.Name = "lblStatus1";
            this.lblStatus1.Size = new System.Drawing.Size(42, 18);
            this.lblStatus1.TabIndex = 12;
            this.lblStatus1.Text = "label5";
            // 
            // lblStatus2
            // 
            this.lblStatus2.AutoSize = true;
            this.lblStatus2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStatus2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus2.Location = new System.Drawing.Point(6, 133);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(42, 18);
            this.lblStatus2.TabIndex = 13;
            this.lblStatus2.Text = "label6";
            // 
            // btnCheckEnd
            // 
            this.btnCheckEnd.Location = new System.Drawing.Point(374, 738);
            this.btnCheckEnd.Name = "btnCheckEnd";
            this.btnCheckEnd.Size = new System.Drawing.Size(138, 35);
            this.btnCheckEnd.TabIndex = 14;
            this.btnCheckEnd.Text = "判定終了！";
            this.btnCheckEnd.UseVisualStyleBackColor = true;
            this.btnCheckEnd.Click += new System.EventHandler(this.btnCheckEndClicked);
            // 
            // lblStatus3
            // 
            this.lblStatus3.AutoSize = true;
            this.lblStatus3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStatus3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus3.Location = new System.Drawing.Point(6, 133);
            this.lblStatus3.Name = "lblStatus3";
            this.lblStatus3.Size = new System.Drawing.Size(42, 18);
            this.lblStatus3.TabIndex = 18;
            this.lblStatus3.Text = "label7";
            // 
            // lblStatusTitle3
            // 
            this.lblStatusTitle3.AutoSize = true;
            this.lblStatusTitle3.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStatusTitle3.Location = new System.Drawing.Point(4, 113);
            this.lblStatusTitle3.Name = "lblStatusTitle3";
            this.lblStatusTitle3.Size = new System.Drawing.Size(35, 20);
            this.lblStatusTitle3.TabIndex = 17;
            this.lblStatusTitle3.Text = "効果";
            // 
            // picChoices3
            // 
            this.picChoices3.BackColor = System.Drawing.Color.White;
            this.picChoices3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picChoices3.Location = new System.Drawing.Point(4, 27);
            this.picChoices3.Name = "picChoices3";
            this.picChoices3.Size = new System.Drawing.Size(488, 83);
            this.picChoices3.TabIndex = 16;
            this.picChoices3.TabStop = false;
            // 
            // lblChoices3
            // 
            this.lblChoices3.AutoSize = true;
            this.lblChoices3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblChoices3.Location = new System.Drawing.Point(4, 0);
            this.lblChoices3.Name = "lblChoices3";
            this.lblChoices3.Size = new System.Drawing.Size(74, 24);
            this.lblChoices3.TabIndex = 15;
            this.lblChoices3.Text = "選択肢３";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblChoices1);
            this.panel1.Controls.Add(this.lblStatus1);
            this.panel1.Controls.Add(this.picChoices1);
            this.panel1.Controls.Add(this.lblStatusTitle1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 240);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblChoices2);
            this.panel2.Controls.Add(this.lblStatus2);
            this.panel2.Controls.Add(this.lblStatusTitle2);
            this.panel2.Controls.Add(this.picChoices2);
            this.panel2.Location = new System.Drawing.Point(12, 252);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 240);
            this.panel2.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblChoices3);
            this.panel3.Controls.Add(this.picChoices3);
            this.panel3.Controls.Add(this.lblStatusTitle3);
            this.panel3.Controls.Add(this.lblStatus3);
            this.panel3.Location = new System.Drawing.Point(12, 492);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(500, 240);
            this.panel3.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(518, 777);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCheckEnd);
            this.Controls.Add(this.btnCheckStart);
            this.Name = "Form1";
            this.Text = "ウマ娘選択肢チェッカー";
            ((System.ComponentModel.ISupportInitialize)(this.picChoices1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChoices2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChoices3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblChoices1;
        private System.Windows.Forms.Label lblChoices2;
        private System.Windows.Forms.Button btnCheckStart;
        private System.Windows.Forms.PictureBox picChoices1;
        private System.Windows.Forms.PictureBox picChoices2;
        private System.Windows.Forms.Label lblStatusTitle1;
        private System.Windows.Forms.Label lblStatusTitle2;
        private System.Windows.Forms.Label lblStatus1;
        private System.Windows.Forms.Label lblStatus2;
        private System.Windows.Forms.Button btnCheckEnd;
        private System.Windows.Forms.Label lblStatus3;
        private System.Windows.Forms.Label lblStatusTitle3;
        private System.Windows.Forms.PictureBox picChoices3;
        private System.Windows.Forms.Label lblChoices3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

