
namespace Projet_S4
{
    partial class Histogramme
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
            this.ComboBoxChoix = new System.Windows.Forms.ComboBox();
            this.BtnGenerer = new System.Windows.Forms.Button();
            this.BtnRetour = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComboBoxChoix
            // 
            this.ComboBoxChoix.FormattingEnabled = true;
            this.ComboBoxChoix.Items.AddRange(new object[] {
            "Coco",
            "Lac",
            "Lena",
            "Image Test 1",
            "Image Test 2",
            "Image Test 3"});
            this.ComboBoxChoix.Location = new System.Drawing.Point(235, 212);
            this.ComboBoxChoix.Name = "ComboBoxChoix";
            this.ComboBoxChoix.Size = new System.Drawing.Size(255, 21);
            this.ComboBoxChoix.TabIndex = 0;
            this.ComboBoxChoix.Text = "Choisissez l\'image sur laquelle faire l\'histogramme";
            this.ComboBoxChoix.SelectedIndexChanged += new System.EventHandler(this.ComboBoxChoix_SelectedIndexChanged);
            // 
            // BtnGenerer
            // 
            this.BtnGenerer.Location = new System.Drawing.Point(360, 526);
            this.BtnGenerer.Name = "BtnGenerer";
            this.BtnGenerer.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerer.TabIndex = 1;
            this.BtnGenerer.Text = "Générer";
            this.BtnGenerer.UseVisualStyleBackColor = true;
            this.BtnGenerer.Click += new System.EventHandler(this.BtnGenerer_Click);
            // 
            // BtnRetour
            // 
            this.BtnRetour.Location = new System.Drawing.Point(173, 525);
            this.BtnRetour.Name = "BtnRetour";
            this.BtnRetour.Size = new System.Drawing.Size(75, 23);
            this.BtnRetour.TabIndex = 2;
            this.BtnRetour.Text = "Retour";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Click += new System.EventHandler(this.BtnRetour_Click);
            // 
            // Histogramme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.BtnRetour);
            this.Controls.Add(this.BtnGenerer);
            this.Controls.Add(this.ComboBoxChoix);
            this.Name = "Histogramme";
            this.Text = "Histogramme";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxChoix;
        private System.Windows.Forms.Button BtnGenerer;
        private System.Windows.Forms.Button BtnRetour;
    }
}