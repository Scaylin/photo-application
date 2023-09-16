
namespace Projet_S4
{
    partial class QR
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
            this.TextBoxSaisie = new System.Windows.Forms.TextBox();
            this.LabelDesc = new System.Windows.Forms.Label();
            this.BtnRetour = new System.Windows.Forms.Button();
            this.BtnGenerer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxNom = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBoxSaisie
            // 
            this.TextBoxSaisie.Location = new System.Drawing.Point(366, 180);
            this.TextBoxSaisie.Name = "TextBoxSaisie";
            this.TextBoxSaisie.Size = new System.Drawing.Size(337, 20);
            this.TextBoxSaisie.TabIndex = 0;
            this.TextBoxSaisie.Text = "HELLO WORLD";
            this.TextBoxSaisie.TextChanged += new System.EventHandler(this.TextBoxSaisie_TextChanged);
            // 
            // LabelDesc
            // 
            this.LabelDesc.AutoSize = true;
            this.LabelDesc.Location = new System.Drawing.Point(70, 187);
            this.LabelDesc.Name = "LabelDesc";
            this.LabelDesc.Size = new System.Drawing.Size(152, 13);
            this.LabelDesc.TabIndex = 1;
            this.LabelDesc.Text = "Que souhaitez vous encoder ?";
            // 
            // BtnRetour
            // 
            this.BtnRetour.Location = new System.Drawing.Point(147, 526);
            this.BtnRetour.Name = "BtnRetour";
            this.BtnRetour.Size = new System.Drawing.Size(75, 23);
            this.BtnRetour.TabIndex = 2;
            this.BtnRetour.Text = "Retour";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Click += new System.EventHandler(this.BtnRetour_Click);
            // 
            // BtnGenerer
            // 
            this.BtnGenerer.Location = new System.Drawing.Point(366, 526);
            this.BtnGenerer.Name = "BtnGenerer";
            this.BtnGenerer.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerer.TabIndex = 3;
            this.BtnGenerer.Text = "Générer";
            this.BtnGenerer.UseVisualStyleBackColor = true;
            this.BtnGenerer.Click += new System.EventHandler(this.BtnGenerer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Saisissez un nom à l\'image";
            // 
            // TextBoxNom
            // 
            this.TextBoxNom.Location = new System.Drawing.Point(366, 272);
            this.TextBoxNom.Name = "TextBoxNom";
            this.TextBoxNom.Size = new System.Drawing.Size(337, 20);
            this.TextBoxNom.TabIndex = 5;
            this.TextBoxNom.Text = "QRCode";
            // 
            // QR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.TextBoxNom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnGenerer);
            this.Controls.Add(this.BtnRetour);
            this.Controls.Add(this.LabelDesc);
            this.Controls.Add(this.TextBoxSaisie);
            this.Name = "QR";
            this.Text = "QR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxSaisie;
        private System.Windows.Forms.Label LabelDesc;
        private System.Windows.Forms.Button BtnRetour;
        private System.Windows.Forms.Button BtnGenerer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxNom;
    }
}