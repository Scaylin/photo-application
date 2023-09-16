
namespace Projet_S4
{
    partial class AppliMyImage
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
            this.BtnModifierUneImage = new System.Windows.Forms.Button();
            this.BtnHistogramme = new System.Windows.Forms.Button();
            this.BtnFractales = new System.Windows.Forms.Button();
            this.BtnQRCode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnStegano = new System.Windows.Forms.Button();
            this.BtnQuitter = new System.Windows.Forms.Button();
            this.BtnFiltre = new System.Windows.Forms.Button();
            this.btnInnovation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnModifierUneImage
            // 
            this.BtnModifierUneImage.Location = new System.Drawing.Point(104, 137);
            this.BtnModifierUneImage.Name = "BtnModifierUneImage";
            this.BtnModifierUneImage.Size = new System.Drawing.Size(120, 23);
            this.BtnModifierUneImage.TabIndex = 2;
            this.BtnModifierUneImage.Text = "Modifier une image";
            this.BtnModifierUneImage.UseVisualStyleBackColor = true;
            this.BtnModifierUneImage.Click += new System.EventHandler(this.BtnModifierUneImage_Click);
            // 
            // BtnHistogramme
            // 
            this.BtnHistogramme.Location = new System.Drawing.Point(104, 338);
            this.BtnHistogramme.Name = "BtnHistogramme";
            this.BtnHistogramme.Size = new System.Drawing.Size(120, 23);
            this.BtnHistogramme.TabIndex = 3;
            this.BtnHistogramme.Text = "Histogramme";
            this.BtnHistogramme.UseVisualStyleBackColor = true;
            this.BtnHistogramme.Click += new System.EventHandler(this.BtnHistogramme_Click);
            // 
            // BtnFractales
            // 
            this.BtnFractales.Location = new System.Drawing.Point(430, 239);
            this.BtnFractales.Name = "BtnFractales";
            this.BtnFractales.Size = new System.Drawing.Size(120, 23);
            this.BtnFractales.TabIndex = 4;
            this.BtnFractales.Text = "Fractales";
            this.BtnFractales.UseVisualStyleBackColor = true;
            this.BtnFractales.Click += new System.EventHandler(this.BtnFractales_Click);
            // 
            // BtnQRCode
            // 
            this.BtnQRCode.Location = new System.Drawing.Point(430, 338);
            this.BtnQRCode.Name = "BtnQRCode";
            this.BtnQRCode.Size = new System.Drawing.Size(120, 23);
            this.BtnQRCode.TabIndex = 5;
            this.BtnQRCode.Text = "QR Code";
            this.BtnQRCode.UseVisualStyleBackColor = true;
            this.BtnQRCode.Click += new System.EventHandler(this.BtnQRCode_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(521, 43);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bienvenue sur cette application";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 539);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Projet réalisé par Killian Lafaye";
            // 
            // BtnStegano
            // 
            this.BtnStegano.Location = new System.Drawing.Point(430, 137);
            this.BtnStegano.Name = "BtnStegano";
            this.BtnStegano.Size = new System.Drawing.Size(120, 23);
            this.BtnStegano.TabIndex = 8;
            this.BtnStegano.Text = "Steganographie";
            this.BtnStegano.UseVisualStyleBackColor = true;
            this.BtnStegano.Click += new System.EventHandler(this.BtnStegano_Click);
            // 
            // BtnQuitter
            // 
            this.BtnQuitter.Location = new System.Drawing.Point(104, 526);
            this.BtnQuitter.Name = "BtnQuitter";
            this.BtnQuitter.Size = new System.Drawing.Size(120, 23);
            this.BtnQuitter.TabIndex = 9;
            this.BtnQuitter.Text = "Quitter";
            this.BtnQuitter.UseVisualStyleBackColor = true;
            this.BtnQuitter.Click += new System.EventHandler(this.BtnQuitter_Click);
            // 
            // BtnFiltre
            // 
            this.BtnFiltre.Location = new System.Drawing.Point(104, 239);
            this.BtnFiltre.Name = "BtnFiltre";
            this.BtnFiltre.Size = new System.Drawing.Size(120, 23);
            this.BtnFiltre.TabIndex = 10;
            this.BtnFiltre.Text = "Appliquer un filtre ";
            this.BtnFiltre.UseVisualStyleBackColor = true;
            this.BtnFiltre.Click += new System.EventHandler(this.BtnFiltre_Click);
            // 
            // btnInnovation
            // 
            this.btnInnovation.Location = new System.Drawing.Point(430, 432);
            this.btnInnovation.Name = "btnInnovation";
            this.btnInnovation.Size = new System.Drawing.Size(120, 23);
            this.btnInnovation.TabIndex = 11;
            this.btnInnovation.Text = "Innovation";
            this.btnInnovation.UseVisualStyleBackColor = true;
            this.btnInnovation.Click += new System.EventHandler(this.btnInnovation_Click);
            // 
            // AppliMyImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnInnovation);
            this.Controls.Add(this.BtnFiltre);
            this.Controls.Add(this.BtnQuitter);
            this.Controls.Add(this.BtnStegano);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnQRCode);
            this.Controls.Add(this.BtnFractales);
            this.Controls.Add(this.BtnHistogramme);
            this.Controls.Add(this.BtnModifierUneImage);
            this.Name = "AppliMyImage";
            this.Text = "AppliMyImage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnModifierUneImage;
        private System.Windows.Forms.Button BtnHistogramme;
        private System.Windows.Forms.Button BtnFractales;
        private System.Windows.Forms.Button BtnQRCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnStegano;
        private System.Windows.Forms.Button BtnQuitter;
        private System.Windows.Forms.Button BtnFiltre;
        private System.Windows.Forms.Button btnInnovation;
    }
}