namespace Проект_Сбербанк.Forms
{
    partial class Adress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Adress));
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxAdress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button_Adr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(171)))), ((int)(((byte)(0)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(579, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 37);
            this.button1.TabIndex = 23;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxAdress
            // 
            this.textBoxAdress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.textBoxAdress.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxAdress.Location = new System.Drawing.Point(145, 159);
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.Size = new System.Drawing.Size(394, 26);
            this.textBoxAdress.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(184)))), ((int)(((byte)(170)))));
            this.label10.Location = new System.Drawing.Point(170, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(339, 41);
            this.label10.TabIndex = 21;
            this.label10.Text = "Enter new mail adress:";
            // 
            // button_Adr
            // 
            this.button_Adr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(171)))), ((int)(((byte)(0)))));
            this.button_Adr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Adr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Adr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button_Adr.Location = new System.Drawing.Point(145, 238);
            this.button_Adr.Name = "button_Adr";
            this.button_Adr.Size = new System.Drawing.Size(394, 56);
            this.button_Adr.TabIndex = 20;
            this.button_Adr.Text = "Change the mail adress";
            this.button_Adr.UseVisualStyleBackColor = false;
            this.button_Adr.Click += new System.EventHandler(this.button_Adr_Click);
            // 
            // Adress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(686, 435);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxAdress);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_Adr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Adress";
            this.Text = "Adress";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Adress_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Adress_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxAdress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_Adr;
    }
}