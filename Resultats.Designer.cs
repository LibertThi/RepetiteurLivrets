namespace RepetiteurLivrets
{
    partial class Resultats
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resultats));
            this.rtxtResultats = new System.Windows.Forms.RichTextBox();
            this.btnRetour = new System.Windows.Forms.Button();
            this.lblPourcentageText = new System.Windows.Forms.Label();
            this.lblNbBonnesRepText = new System.Windows.Forms.Label();
            this.lblNbBonneRep = new System.Windows.Forms.Label();
            this.lblPourcentage = new System.Windows.Forms.Label();
            this.pnlElemBas = new System.Windows.Forms.Panel();
            this.tmrDelai = new System.Windows.Forms.Timer(this.components);
            this.pnlElemBas.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxtResultats
            // 
            this.rtxtResultats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtResultats.Enabled = false;
            this.rtxtResultats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtResultats.Location = new System.Drawing.Point(12, 11);
            this.rtxtResultats.Name = "rtxtResultats";
            this.rtxtResultats.ReadOnly = true;
            this.rtxtResultats.Size = new System.Drawing.Size(412, 111);
            this.rtxtResultats.TabIndex = 1;
            this.rtxtResultats.Text = resources.GetString("rtxtResultats.Text");
            // 
            // btnRetour
            // 
            this.btnRetour.Enabled = false;
            this.btnRetour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetour.Location = new System.Drawing.Point(98, 72);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(231, 44);
            this.btnRetour.TabIndex = 2;
            this.btnRetour.Text = "Retour au menu";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // lblPourcentageText
            // 
            this.lblPourcentageText.AutoSize = true;
            this.lblPourcentageText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPourcentageText.Location = new System.Drawing.Point(95, 44);
            this.lblPourcentageText.Name = "lblPourcentageText";
            this.lblPourcentageText.Size = new System.Drawing.Size(171, 17);
            this.lblPourcentageText.TabIndex = 3;
            this.lblPourcentageText.Text = "Pourcentage de réussite :";
            // 
            // lblNbBonnesRepText
            // 
            this.lblNbBonnesRepText.AutoSize = true;
            this.lblNbBonnesRepText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbBonnesRepText.Location = new System.Drawing.Point(66, 10);
            this.lblNbBonnesRepText.Name = "lblNbBonnesRepText";
            this.lblNbBonnesRepText.Size = new System.Drawing.Size(200, 17);
            this.lblNbBonnesRepText.TabIndex = 3;
            this.lblNbBonnesRepText.Text = "Nombre de bonnes réponses :";
            // 
            // lblNbBonneRep
            // 
            this.lblNbBonneRep.AutoSize = true;
            this.lblNbBonneRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbBonneRep.Location = new System.Drawing.Point(267, 5);
            this.lblNbBonneRep.Name = "lblNbBonneRep";
            this.lblNbBonneRep.Size = new System.Drawing.Size(39, 29);
            this.lblNbBonneRep.TabIndex = 3;
            this.lblNbBonneRep.Text = "10";
            // 
            // lblPourcentage
            // 
            this.lblPourcentage.AutoSize = true;
            this.lblPourcentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPourcentage.Location = new System.Drawing.Point(268, 37);
            this.lblPourcentage.Name = "lblPourcentage";
            this.lblPourcentage.Size = new System.Drawing.Size(61, 29);
            this.lblPourcentage.TabIndex = 3;
            this.lblPourcentage.Text = "85%";
            // 
            // pnlElemBas
            // 
            this.pnlElemBas.Controls.Add(this.btnRetour);
            this.pnlElemBas.Controls.Add(this.lblPourcentage);
            this.pnlElemBas.Controls.Add(this.lblPourcentageText);
            this.pnlElemBas.Controls.Add(this.lblNbBonneRep);
            this.pnlElemBas.Controls.Add(this.lblNbBonnesRepText);
            this.pnlElemBas.Location = new System.Drawing.Point(12, 128);
            this.pnlElemBas.Name = "pnlElemBas";
            this.pnlElemBas.Size = new System.Drawing.Size(412, 125);
            this.pnlElemBas.TabIndex = 4;
            // 
            // tmrDelai
            // 
            this.tmrDelai.Interval = 2000;
            this.tmrDelai.Tick += new System.EventHandler(this.tmrDelai_Tick);
            // 
            // Resultats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 260);
            this.Controls.Add(this.pnlElemBas);
            this.Controls.Add(this.rtxtResultats);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Resultats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Résultats";
            this.pnlElemBas.ResumeLayout(false);
            this.pnlElemBas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtResultats;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.Label lblPourcentageText;
        private System.Windows.Forms.Label lblNbBonnesRepText;
        private System.Windows.Forms.Label lblNbBonneRep;
        private System.Windows.Forms.Label lblPourcentage;
        private System.Windows.Forms.Panel pnlElemBas;
        private System.Windows.Forms.Timer tmrDelai;
    }
}