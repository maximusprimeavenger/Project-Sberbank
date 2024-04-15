namespace Проект_Сбербанк.Forms
{
    partial class MobilePhone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MobilePhone));
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button_Num = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.textBoxNumber.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxNumber.Location = new System.Drawing.Point(72, 115);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(394, 26);
            this.textBoxNumber.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(184)))), ((int)(((byte)(170)))));
            this.label10.Location = new System.Drawing.Point(97, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(339, 41);
            this.label10.TabIndex = 16;
            this.label10.Text = "Enter new phone number:";
            // 
            // button_Num
            // 
            this.button_Num.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(171)))), ((int)(((byte)(0)))));
            this.button_Num.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Num.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Num.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button_Num.Location = new System.Drawing.Point(72, 194);
            this.button_Num.Name = "button_Num";
            this.button_Num.Size = new System.Drawing.Size(394, 56);
            this.button_Num.TabIndex = 15;
            this.button_Num.Text = "Change the phone number";
            this.button_Num.UseVisualStyleBackColor = false;
            this.button_Num.Click += new System.EventHandler(this.button_Num_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(171)))), ((int)(((byte)(0)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(506, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 37);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MobilePhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(568, 351);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_Num);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MobilePhone";
            this.Text = "MobilePhone";
            this.Load += new System.EventHandler(this.MobilePhone_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MobilePhone_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MobilePhone_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_Num;
        private System.Windows.Forms.Button button1;
    }
}