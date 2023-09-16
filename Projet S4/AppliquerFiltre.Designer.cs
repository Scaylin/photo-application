
namespace Projet_S4
{
    partial class AppliquerFiltre
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
            this.CbChoixImage = new System.Windows.Forms.ComboBox();
            this.CbFiltre = new System.Windows.Forms.ComboBox();
            this.BtnGenerer = new System.Windows.Forms.Button();
            this.BtnRetour = new System.Windows.Forms.Button();
            this.TxtBoxNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CbChoixImage
            // 
            this.CbChoixImage.FormattingEnabled = true;
            this.CbChoixImage.Items.AddRange(new object[] {
            "Coco",
            "Lac",
            "Lena",
            "Image Test 1",
            "Image Test 2",
            "Image Test 3"});
            this.CbChoixImage.Location = new System.Drawing.Point(299, 170);
            this.CbChoixImage.Name = "CbChoixImage";
            this.CbChoixImage.Size = new System.Drawing.Size(121, 21);
            this.CbChoixImage.TabIndex = 0;
            this.CbChoixImage.Text = "Saisir une image";
            this.CbChoixImage.SelectedIndexChanged += new System.EventHandler(this.CbChoixImage_SelectedIndexChanged);
            // 
            // CbFiltre
            // 
            this.CbFiltre.FormattingEnabled = true;
            this.CbFiltre.Items.AddRange(new object[] {
            "Flou léger",
            "Flou ",
            "Contours Couleurs",
            "Contours NB",
            "Repoussage"});
            this.CbFiltre.Location = new System.Drawing.Point(557, 170);
            this.CbFiltre.Name = "CbFiltre";
            this.CbFiltre.Size = new System.Drawing.Size(121, 21);
            this.CbFiltre.TabIndex = 1;
            this.CbFiltre.Text = "Saisir un filtre";
            // 
            // BtnGenerer
            // 
            this.BtnGenerer.Location = new System.Drawing.Point(362, 415);
            this.BtnGenerer.Name = "BtnGenerer";
            this.BtnGenerer.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerer.TabIndex = 2;
            this.BtnGenerer.Text = "Générer";
            this.BtnGenerer.UseVisualStyleBackColor = true;
            this.BtnGenerer.Click += new System.EventHandler(this.BtnGenerer_Click);
            // 
            // BtnRetour
            // 
            this.BtnRetour.Location = new System.Drawing.Point(180, 415);
            this.BtnRetour.Name = "BtnRetour";
            this.BtnRetour.Size = new System.Drawing.Size(75, 23);
            this.BtnRetour.TabIndex = 3;
            this.BtnRetour.Text = "Retour";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Click += new System.EventHandler(this.BtnRetour_Click);
            // 
            // TxtBoxNom
            // 
            this.TxtBoxNom.Location = new System.Drawing.Point(74, 170);
            this.TxtBoxNom.Name = "TxtBoxNom";
            this.TxtBoxNom.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxNom.TabIndex = 4;
            this.TxtBoxNom.Text = "Default";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nom du fichier :";
            // 
            // AppliquerFiltre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBoxNom);
            this.Controls.Add(this.BtnRetour);
            this.Controls.Add(this.BtnGenerer);
            this.Controls.Add(this.CbFiltre);
            this.Controls.Add(this.CbChoixImage);
            this.Name = "AppliquerFiltre";
            this.Text = "AppliquerFiltre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbChoixImage;
        private System.Windows.Forms.ComboBox CbFiltre;
        private System.Windows.Forms.Button BtnGenerer;
        private System.Windows.Forms.Button BtnRetour;
        private System.Windows.Forms.TextBox TxtBoxNom;
        private System.Windows.Forms.Label label1;
    }
}