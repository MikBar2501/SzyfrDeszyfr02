namespace SzyfrDeszyfr
{
    partial class SzyfrowanieDeszyfrowanie
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSzyfr = new System.Windows.Forms.Button();
            this.btnDeszyfr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbAES = new System.Windows.Forms.RadioButton();
            this.rbMINIAES = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnSzyfr
            // 
            this.btnSzyfr.Enabled = false;
            this.btnSzyfr.Location = new System.Drawing.Point(12, 130);
            this.btnSzyfr.Name = "btnSzyfr";
            this.btnSzyfr.Size = new System.Drawing.Size(121, 23);
            this.btnSzyfr.TabIndex = 0;
            this.btnSzyfr.Text = "Szyfrowanie";
            this.btnSzyfr.UseVisualStyleBackColor = true;
            this.btnSzyfr.Click += new System.EventHandler(this.BtnSzyfr_Click);
            // 
            // btnDeszyfr
            // 
            this.btnDeszyfr.Enabled = false;
            this.btnDeszyfr.Location = new System.Drawing.Point(139, 130);
            this.btnDeszyfr.Name = "btnDeszyfr";
            this.btnDeszyfr.Size = new System.Drawing.Size(123, 23);
            this.btnDeszyfr.TabIndex = 1;
            this.btnDeszyfr.Text = "Deszyfrowanie";
            this.btnDeszyfr.UseVisualStyleBackColor = true;
            this.btnDeszyfr.Click += new System.EventHandler(this.BtnDeszyfr_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ścieżka do pliku:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 30);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(250, 20);
            this.txtPath.TabIndex = 3;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(12, 104);
            this.txtKey.MaxLength = 4;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(250, 20);
            this.txtKey.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Klucz:";
            // 
            // rbAES
            // 
            this.rbAES.AutoSize = true;
            this.rbAES.Location = new System.Drawing.Point(51, 56);
            this.rbAES.Name = "rbAES";
            this.rbAES.Size = new System.Drawing.Size(46, 17);
            this.rbAES.TabIndex = 6;
            this.rbAES.TabStop = true;
            this.rbAES.Text = "AES";
            this.rbAES.UseVisualStyleBackColor = true;
            this.rbAES.CheckedChanged += new System.EventHandler(this.RbAES_CheckedChanged);
            // 
            // rbMINIAES
            // 
            this.rbMINIAES.AutoSize = true;
            this.rbMINIAES.Location = new System.Drawing.Point(159, 56);
            this.rbMINIAES.Name = "rbMINIAES";
            this.rbMINIAES.Size = new System.Drawing.Size(64, 17);
            this.rbMINIAES.TabIndex = 7;
            this.rbMINIAES.TabStop = true;
            this.rbMINIAES.Text = "miniAES";
            this.rbMINIAES.UseVisualStyleBackColor = true;
            this.rbMINIAES.CheckedChanged += new System.EventHandler(this.RbMINIAES_CheckedChanged);
            // 
            // SzyfrowanieDeszyfrowanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 165);
            this.Controls.Add(this.rbMINIAES);
            this.Controls.Add(this.rbAES);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeszyfr);
            this.Controls.Add(this.btnSzyfr);
            this.Name = "SzyfrowanieDeszyfrowanie";
            this.Text = "SzyfrowanieDeszyfrowanie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSzyfr;
        private System.Windows.Forms.Button btnDeszyfr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbAES;
        private System.Windows.Forms.RadioButton rbMINIAES;
    }
}

