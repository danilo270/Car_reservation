namespace Projekat_tvp
{
    partial class Form1
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
            this.administracija_dugme = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.korisnik_dugme = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // administracija_dugme
            // 
            this.administracija_dugme.Location = new System.Drawing.Point(31, 216);
            this.administracija_dugme.Name = "administracija_dugme";
            this.administracija_dugme.Size = new System.Drawing.Size(169, 82);
            this.administracija_dugme.TabIndex = 0;
            this.administracija_dugme.Text = "Administracija";
            this.administracija_dugme.UseVisualStyleBackColor = true;
            this.administracija_dugme.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rezervacija automobila";
            // 
            // korisnik_dugme
            // 
            this.korisnik_dugme.Location = new System.Drawing.Point(294, 216);
            this.korisnik_dugme.Name = "korisnik_dugme";
            this.korisnik_dugme.Size = new System.Drawing.Size(169, 82);
            this.korisnik_dugme.TabIndex = 2;
            this.korisnik_dugme.Text = "Korisnik";
            this.korisnik_dugme.UseVisualStyleBackColor = true;
            this.korisnik_dugme.Click += new System.EventHandler(this.korisnik_dugme_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 427);
            this.Controls.Add(this.korisnik_dugme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.administracija_dugme);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button administracija_dugme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button korisnik_dugme;
    }
}

