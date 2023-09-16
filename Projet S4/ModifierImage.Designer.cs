
namespace Projet_S4
{
    partial class ModifierImage
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
            this.BtnGenerer = new System.Windows.Forms.Button();
            this.BtnRetour = new System.Windows.Forms.Button();
            this.CbChoixImage = new System.Windows.Forms.ComboBox();
            this.CbChoixModif = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBoxNom = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnGenerer
            // 
            this.BtnGenerer.Location = new System.Drawing.Point(364, 415);
            this.BtnGenerer.Name = "BtnGenerer";
            this.BtnGenerer.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerer.TabIndex = 0;
            this.BtnGenerer.Text = "Générer";
            this.BtnGenerer.UseVisualStyleBackColor = true;
            this.BtnGenerer.Click += new System.EventHandler(this.BtnGenerer_Click);
            // 
            // BtnRetour
            // 
            this.BtnRetour.Location = new System.Drawing.Point(205, 415);
            this.BtnRetour.Name = "BtnRetour";
            this.BtnRetour.Size = new System.Drawing.Size(75, 23);
            this.BtnRetour.TabIndex = 1;
            this.BtnRetour.Text = "Retour";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Click += new System.EventHandler(this.BtnRetour_Click);
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
            this.CbChoixImage.Location = new System.Drawing.Point(285, 151);
            this.CbChoixImage.Name = "CbChoixImage";
            this.CbChoixImage.Size = new System.Drawing.Size(121, 21);
            this.CbChoixImage.TabIndex = 2;
            this.CbChoixImage.Text = "Saisir une image";
            // 
            // CbChoixModif
            // 
            this.CbChoixModif.FormattingEnabled = true;
            this.CbChoixModif.Items.AddRange(new object[] {
            "Noir et blanc ",
            "Nuances de gris",
            "Rotation 45",
            "Rotation 90",
            "Rotation 135",
            "Miroir",
            "Miroir vertical",
            "Negatif",
            "Modifier la taille"});
            this.CbChoixModif.Location = new System.Drawing.Point(516, 151);
            this.CbChoixModif.Name = "CbChoixModif";
            this.CbChoixModif.Size = new System.Drawing.Size(121, 21);
            this.CbChoixModif.TabIndex = 3;
            this.CbChoixModif.Text = "Saisir une action";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nom du fichier :";
            // 
            // TxtBoxNom
            // 
            this.TxtBoxNom.Location = new System.Drawing.Point(75, 152);
            this.TxtBoxNom.Name = "TxtBoxNom";
            this.TxtBoxNom.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxNom.TabIndex = 7;
            this.TxtBoxNom.Text = "Default";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(672, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(669, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ratio :";
            // 
            // ModifierImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TxtBoxNom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbChoixModif);
            this.Controls.Add(this.CbChoixImage);
            this.Controls.Add(this.BtnRetour);
            this.Controls.Add(this.BtnGenerer);
            this.Name = "ModifierImage";
            this.Text = "ModifierImage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGenerer;
        private System.Windows.Forms.Button BtnRetour;
        private System.Windows.Forms.ComboBox CbChoixImage;
        private System.Windows.Forms.ComboBox CbChoixModif;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBoxNom;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}