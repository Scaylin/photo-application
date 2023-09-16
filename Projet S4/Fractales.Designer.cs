
namespace Projet_S4
{
    partial class Fractales
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LabelDonnerNom = new System.Windows.Forms.Label();
            this.CBTypeFractale = new System.Windows.Forms.ComboBox();
            this.BtnRetour = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "500x500",
            "1000x1000",
            "2000x2000",
            "4000x4000",
            "8000x8000"});
            this.comboBox1.Location = new System.Drawing.Point(515, 180);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(145, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Choisissez la dimension";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Location = new System.Drawing.Point(335, 508);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerate.TabIndex = 1;
            this.BtnGenerate.Text = "Générer";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 181);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // LabelDonnerNom
            // 
            this.LabelDonnerNom.AutoSize = true;
            this.LabelDonnerNom.Location = new System.Drawing.Point(59, 152);
            this.LabelDonnerNom.Name = "LabelDonnerNom";
            this.LabelDonnerNom.Size = new System.Drawing.Size(82, 13);
            this.LabelDonnerNom.TabIndex = 3;
            this.LabelDonnerNom.Text = "Donnez un nom";
            this.LabelDonnerNom.Click += new System.EventHandler(this.LabelDonnerNom_Click);
            // 
            // CBTypeFractale
            // 
            this.CBTypeFractale.FormattingEnabled = true;
            this.CBTypeFractale.Items.AddRange(new object[] {
            "Mandelbrot",
            "-0.63 + 0.67 i",
            "-0.76 + 0.12 i",
            "-0.6 + 0.6 i",
            "0.35 + 0.05 i",
            "-1",
            "-2",
            "Buddhabrot"});
            this.CBTypeFractale.Location = new System.Drawing.Point(280, 180);
            this.CBTypeFractale.Name = "CBTypeFractale";
            this.CBTypeFractale.Size = new System.Drawing.Size(145, 21);
            this.CBTypeFractale.TabIndex = 4;
            this.CBTypeFractale.Text = "Choisissez la fractale";
            this.CBTypeFractale.SelectedIndexChanged += new System.EventHandler(this.CBTypeFractale_SelectedIndexChanged);
            // 
            // BtnRetour
            // 
            this.BtnRetour.Location = new System.Drawing.Point(74, 507);
            this.BtnRetour.Name = "BtnRetour";
            this.BtnRetour.Size = new System.Drawing.Size(75, 23);
            this.BtnRetour.TabIndex = 5;
            this.BtnRetour.Text = "Retour";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Click += new System.EventHandler(this.BtnRetour_Click);
            // 
            // Fractales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.BtnRetour);
            this.Controls.Add(this.CBTypeFractale);
            this.Controls.Add(this.LabelDonnerNom);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnGenerate);
            this.Controls.Add(this.comboBox1);
            this.Name = "Fractales";
            this.Text = "Fractales";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label LabelDonnerNom;
        private System.Windows.Forms.ComboBox CBTypeFractale;
        private System.Windows.Forms.Button BtnRetour;
    }
}