namespace RepetiteurLivrets
{
    partial class Menu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPartie = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtn7H = new System.Windows.Forms.RadioButton();
            this.rbtn6H = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnDifficile = new System.Windows.Forms.RadioButton();
            this.rbtnMoyen = new System.Windows.Forms.RadioButton();
            this.rbtnFacile = new System.Windows.Forms.RadioButton();
            this.lblJoueurText = new System.Windows.Forms.Label();
            this.lblNbPartieText = new System.Windows.Forms.Label();
            this.lblScoreText = new System.Windows.Forms.Label();
            this.lblJoueur = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblNbPartie = new System.Windows.Forms.Label();
            this.btnChangementJoueur = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAide = new System.Windows.Forms.Button();
            this.lblClasseText = new System.Windows.Forms.Label();
            this.lblDifficulteText = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPartie
            // 
            this.btnPartie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPartie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPartie.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartie.Location = new System.Drawing.Point(12, 307);
            this.btnPartie.Name = "btnPartie";
            this.btnPartie.Size = new System.Drawing.Size(310, 50);
            this.btnPartie.TabIndex = 1;
            this.btnPartie.Text = "Démarrer la partie";
            this.btnPartie.UseVisualStyleBackColor = false;
            this.btnPartie.Click += new System.EventHandler(this.btnPartie_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbtn7H);
            this.panel1.Controls.Add(this.rbtn6H);
            this.panel1.Location = new System.Drawing.Point(12, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 67);
            this.panel1.TabIndex = 3;
            // 
            // rbtn7H
            // 
            this.rbtn7H.AutoSize = true;
            this.rbtn7H.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn7H.Location = new System.Drawing.Point(13, 34);
            this.rbtn7H.Name = "rbtn7H";
            this.rbtn7H.Size = new System.Drawing.Size(246, 24);
            this.rbtn7H.TabIndex = 1;
            this.rbtn7H.Text = "7ème HarmoS | 8ème HarmoS";
            this.rbtn7H.UseVisualStyleBackColor = true;
            // 
            // rbtn6H
            // 
            this.rbtn6H.AutoSize = true;
            this.rbtn6H.Checked = true;
            this.rbtn6H.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn6H.Location = new System.Drawing.Point(13, 4);
            this.rbtn6H.Name = "rbtn6H";
            this.rbtn6H.Size = new System.Drawing.Size(246, 24);
            this.rbtn6H.TabIndex = 0;
            this.rbtn6H.TabStop = true;
            this.rbtn6H.Text = "5ème HarmoS | 6ème HarmoS";
            this.rbtn6H.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rbtnDifficile);
            this.panel2.Controls.Add(this.rbtnMoyen);
            this.panel2.Controls.Add(this.rbtnFacile);
            this.panel2.Location = new System.Drawing.Point(12, 253);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 34);
            this.panel2.TabIndex = 4;
            // 
            // rbtnDifficile
            // 
            this.rbtnDifficile.AutoSize = true;
            this.rbtnDifficile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDifficile.Location = new System.Drawing.Point(222, 3);
            this.rbtnDifficile.Name = "rbtnDifficile";
            this.rbtnDifficile.Size = new System.Drawing.Size(78, 24);
            this.rbtnDifficile.TabIndex = 2;
            this.rbtnDifficile.Text = "Difficile";
            this.rbtnDifficile.UseVisualStyleBackColor = true;
            // 
            // rbtnMoyen
            // 
            this.rbtnMoyen.AutoSize = true;
            this.rbtnMoyen.Checked = true;
            this.rbtnMoyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnMoyen.Location = new System.Drawing.Point(112, 3);
            this.rbtnMoyen.Name = "rbtnMoyen";
            this.rbtnMoyen.Size = new System.Drawing.Size(74, 24);
            this.rbtnMoyen.TabIndex = 1;
            this.rbtnMoyen.TabStop = true;
            this.rbtnMoyen.Text = "Moyen";
            this.rbtnMoyen.UseVisualStyleBackColor = true;
            // 
            // rbtnFacile
            // 
            this.rbtnFacile.AutoSize = true;
            this.rbtnFacile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnFacile.Location = new System.Drawing.Point(13, 3);
            this.rbtnFacile.Name = "rbtnFacile";
            this.rbtnFacile.Size = new System.Drawing.Size(69, 24);
            this.rbtnFacile.TabIndex = 0;
            this.rbtnFacile.Text = "Facile";
            this.rbtnFacile.UseVisualStyleBackColor = true;
            // 
            // lblJoueurText
            // 
            this.lblJoueurText.AutoSize = true;
            this.lblJoueurText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoueurText.Location = new System.Drawing.Point(3, 5);
            this.lblJoueurText.Name = "lblJoueurText";
            this.lblJoueurText.Size = new System.Drawing.Size(66, 20);
            this.lblJoueurText.TabIndex = 5;
            this.lblJoueurText.Text = "Joueur :";
            // 
            // lblNbPartieText
            // 
            this.lblNbPartieText.AutoSize = true;
            this.lblNbPartieText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbPartieText.Location = new System.Drawing.Point(3, 25);
            this.lblNbPartieText.Name = "lblNbPartieText";
            this.lblNbPartieText.Size = new System.Drawing.Size(147, 20);
            this.lblNbPartieText.TabIndex = 6;
            this.lblNbPartieText.Text = "Nombre de parties :";
            // 
            // lblScoreText
            // 
            this.lblScoreText.AutoSize = true;
            this.lblScoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreText.Location = new System.Drawing.Point(3, 45);
            this.lblScoreText.Name = "lblScoreText";
            this.lblScoreText.Size = new System.Drawing.Size(59, 20);
            this.lblScoreText.TabIndex = 7;
            this.lblScoreText.Text = "Score :";
            // 
            // lblJoueur
            // 
            this.lblJoueur.AutoSize = true;
            this.lblJoueur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoueur.Location = new System.Drawing.Point(66, 5);
            this.lblJoueur.Name = "lblJoueur";
            this.lblJoueur.Size = new System.Drawing.Size(100, 20);
            this.lblJoueur.TabIndex = 8;
            this.lblJoueur.Text = "NomJoueur";
            this.lblJoueur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(55, 45);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(65, 20);
            this.lblScore.TabIndex = 8;
            this.lblScore.Text = "Score%";
            // 
            // lblNbPartie
            // 
            this.lblNbPartie.AutoSize = true;
            this.lblNbPartie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbPartie.Location = new System.Drawing.Point(146, 25);
            this.lblNbPartie.Name = "lblNbPartie";
            this.lblNbPartie.Size = new System.Drawing.Size(70, 20);
            this.lblNbPartie.TabIndex = 8;
            this.lblNbPartie.Text = "NbPartie";
            // 
            // btnChangementJoueur
            // 
            this.btnChangementJoueur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangementJoueur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangementJoueur.Location = new System.Drawing.Point(7, 68);
            this.btnChangementJoueur.Name = "btnChangementJoueur";
            this.btnChangementJoueur.Size = new System.Drawing.Size(143, 26);
            this.btnChangementJoueur.TabIndex = 1;
            this.btnChangementJoueur.Text = "Changer de joueur";
            this.btnChangementJoueur.UseVisualStyleBackColor = true;
            this.btnChangementJoueur.Click += new System.EventHandler(this.btnChangementJoueur_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(196, 68);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(106, 26);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "RESET SCORE";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnAide);
            this.panel3.Controls.Add(this.lblJoueurText);
            this.panel3.Controls.Add(this.lblScore);
            this.panel3.Controls.Add(this.lblNbPartie);
            this.panel3.Controls.Add(this.btnReset);
            this.panel3.Controls.Add(this.lblScoreText);
            this.panel3.Controls.Add(this.btnChangementJoueur);
            this.panel3.Controls.Add(this.lblJoueur);
            this.panel3.Controls.Add(this.lblNbPartieText);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(310, 104);
            this.panel3.TabIndex = 9;
            // 
            // btnAide
            // 
            this.btnAide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAide.Location = new System.Drawing.Point(245, 5);
            this.btnAide.Name = "btnAide";
            this.btnAide.Size = new System.Drawing.Size(57, 26);
            this.btnAide.TabIndex = 9;
            this.btnAide.Text = "Aide";
            this.btnAide.UseVisualStyleBackColor = true;
            this.btnAide.Click += new System.EventHandler(this.Help_Click);
            // 
            // lblClasseText
            // 
            this.lblClasseText.AutoSize = true;
            this.lblClasseText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasseText.Location = new System.Drawing.Point(9, 129);
            this.lblClasseText.Name = "lblClasseText";
            this.lblClasseText.Size = new System.Drawing.Size(129, 17);
            this.lblClasseText.TabIndex = 10;
            this.lblClasseText.Text = "Choix de la classe :";
            // 
            // lblDifficulteText
            // 
            this.lblDifficulteText.AutoSize = true;
            this.lblDifficulteText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifficulteText.Location = new System.Drawing.Point(9, 233);
            this.lblDifficulteText.Name = "lblDifficulteText";
            this.lblDifficulteText.Size = new System.Drawing.Size(70, 17);
            this.lblDifficulteText.TabIndex = 10;
            this.lblDifficulteText.Text = "Difficulté :";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 370);
            this.Controls.Add(this.lblDifficulteText);
            this.Controls.Add(this.lblClasseText);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPartie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Répétiteur de livrets - Menu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPartie;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtn7H;
        private System.Windows.Forms.RadioButton rbtn6H;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnDifficile;
        private System.Windows.Forms.RadioButton rbtnMoyen;
        private System.Windows.Forms.RadioButton rbtnFacile;
        private System.Windows.Forms.Label lblJoueurText;
        private System.Windows.Forms.Label lblNbPartieText;
        private System.Windows.Forms.Label lblScoreText;
        private System.Windows.Forms.Label lblJoueur;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblNbPartie;
        private System.Windows.Forms.Button btnChangementJoueur;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblClasseText;
        private System.Windows.Forms.Label lblDifficulteText;
        private System.Windows.Forms.Button btnAide;
    }
}

