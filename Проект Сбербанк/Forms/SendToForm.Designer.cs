namespace Проект_Сбербанк.Forms
{
    partial class SendToForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendToForm));
            this.button_Trans = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCard = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCardTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCVV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDestinationCard = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxSum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Trans
            // 
            this.button_Trans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(171)))), ((int)(((byte)(0)))));
            this.button_Trans.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Trans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Trans.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button_Trans.Location = new System.Drawing.Point(203, 557);
            this.button_Trans.Name = "button_Trans";
            this.button_Trans.Size = new System.Drawing.Size(394, 56);
            this.button_Trans.TabIndex = 6;
            this.button_Trans.Text = "Transfer";
            this.button_Trans.UseVisualStyleBackColor = false;
            this.button_Trans.Click += new System.EventHandler(this.button_Trans_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(171)))), ((int)(((byte)(0)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(772, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 37);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(184)))), ((int)(((byte)(170)))));
            this.label1.Location = new System.Drawing.Point(87, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 41);
            this.label1.TabIndex = 8;
            this.label1.Text = "From card:";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(184)))), ((int)(((byte)(170)))));
            this.label10.Location = new System.Drawing.Point(87, 334);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(272, 41);
            this.label10.TabIndex = 10;
            this.label10.Text = "To card:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(184)))), ((int)(((byte)(170)))));
            this.label2.Location = new System.Drawing.Point(141, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Card number:";
            // 
            // textBoxCard
            // 
            this.textBoxCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.textBoxCard.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxCard.Location = new System.Drawing.Point(146, 134);
            this.textBoxCard.Name = "textBoxCard";
            this.textBoxCard.Size = new System.Drawing.Size(337, 26);
            this.textBoxCard.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(184)))), ((int)(((byte)(170)))));
            this.label3.Location = new System.Drawing.Point(141, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Validity period:";
            // 
            // textBoxCardTo
            // 
            this.textBoxCardTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.textBoxCardTo.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxCardTo.Location = new System.Drawing.Point(146, 213);
            this.textBoxCardTo.Name = "textBoxCardTo";
            this.textBoxCardTo.Size = new System.Drawing.Size(194, 26);
            this.textBoxCardTo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(184)))), ((int)(((byte)(170)))));
            this.label4.Location = new System.Drawing.Point(451, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 29);
            this.label4.TabIndex = 4;
            // 
            // textBoxCVV
            // 
            this.textBoxCVV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.textBoxCVV.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxCVV.Location = new System.Drawing.Point(456, 213);
            this.textBoxCVV.Name = "textBoxCVV";
            this.textBoxCVV.Size = new System.Drawing.Size(194, 26);
            this.textBoxCVV.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(184)))), ((int)(((byte)(170)))));
            this.label5.Location = new System.Drawing.Point(451, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 29);
            this.label5.TabIndex = 6;
            this.label5.Text = "CVV-code:";
            // 
            // textBoxDestinationCard
            // 
            this.textBoxDestinationCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.textBoxDestinationCard.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxDestinationCard.Location = new System.Drawing.Point(135, 429);
            this.textBoxDestinationCard.Name = "textBoxDestinationCard";
            this.textBoxDestinationCard.Size = new System.Drawing.Size(337, 26);
            this.textBoxDestinationCard.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(184)))), ((int)(((byte)(170)))));
            this.label6.Location = new System.Drawing.Point(130, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "Card number:";
            // 
            // TextBoxSum
            // 
            this.TextBoxSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.TextBoxSum.ForeColor = System.Drawing.SystemColors.Window;
            this.TextBoxSum.Location = new System.Drawing.Point(135, 516);
            this.TextBoxSum.Name = "TextBoxSum";
            this.TextBoxSum.Size = new System.Drawing.Size(154, 26);
            this.TextBoxSum.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(184)))), ((int)(((byte)(170)))));
            this.label7.Location = new System.Drawing.Point(130, 484);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 29);
            this.label7.TabIndex = 13;
            this.label7.Text = "Amount:";
            // 
            // textBoxPass
            // 
            this.textBoxPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.textBoxPass.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxPass.Location = new System.Drawing.Point(146, 304);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(337, 26);
            this.textBoxPass.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(184)))), ((int)(((byte)(170)))));
            this.label8.Location = new System.Drawing.Point(141, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 29);
            this.label8.TabIndex = 15;
            this.label8.Text = "Passport details";
            // 
            // SendToForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(821, 691);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TextBoxSum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxDestinationCard);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxCVV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCardTo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Trans);
            this.Controls.Add(this.textBoxCard);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SendToForm";
            this.Text = "SendToForm";
            this.Load += new System.EventHandler(this.SendToForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SendToForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SendToForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Trans;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCardTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCVV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDestinationCard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBoxSum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Label label8;
    }
}