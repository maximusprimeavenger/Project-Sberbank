namespace Проект_Сбербанк.Forms
{
    partial class Password
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Password));
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button_Pass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(171)))), ((int)(((byte)(0)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(552, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 37);
            this.button1.TabIndex = 23;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxPass
            // 
            this.textBoxPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.textBoxPass.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxPass.Location = new System.Drawing.Point(118, 142);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(394, 26);
            this.textBoxPass.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(184)))), ((int)(((byte)(170)))));
            this.label10.Location = new System.Drawing.Point(143, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(339, 41);
            this.label10.TabIndex = 21;
            this.label10.Text = "Enter new password:";
            // 
            // button_Pass
            // 
            this.button_Pass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(171)))), ((int)(((byte)(0)))));
            this.button_Pass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Pass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button_Pass.Location = new System.Drawing.Point(118, 221);
            this.button_Pass.Name = "button_Pass";
            this.button_Pass.Size = new System.Drawing.Size(394, 56);
            this.button_Pass.TabIndex = 20;
            this.button_Pass.Text = "Change the password";
            this.button_Pass.UseVisualStyleBackColor = false;
            this.button_Pass.Click += new System.EventHandler(this.button_Pass_Click);
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(643, 403);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_Pass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Password";
            this.Text = "Password";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Password_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Password_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_Pass;
    }
}