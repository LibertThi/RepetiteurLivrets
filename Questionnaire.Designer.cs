namespace RepetiteurLivrets
{
    partial class Questionnaire
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
            this.tmrDecompte = new System.Windows.Forms.Timer(this.components);
            this.lblNumQuestionText = new System.Windows.Forms.Label();
            this.tbxMult1 = new System.Windows.Forms.TextBox();
            this.tbxMult2 = new System.Windows.Forms.TextBox();
            this.tbxProduit = new System.Windows.Forms.TextBox();
            this.lblX = new System.Windows.Forms.Label();
            this.lblEgal = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblNumQuestion = new System.Windows.Forms.Label();
            this.lblQTimer = new System.Windows.Forms.Label();
            this.lblStartTimer = new System.Windows.Forms.Label();
            this.tmrQuestion = new System.Windows.Forms.Timer(this.components);
            this.lblQTimerText = new System.Windows.Forms.Label();
            this.lblNumQuestionMax = new System.Windows.Forms.Label();
            this.pgbTimer = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // tmrDecompte
            // 
            this.tmrDecompte.Interval = 1000;
            this.tmrDecompte.Tick += new System.EventHandler(this.tmrDecompte_Tick);
            // 
            // lblNumQuestionText
            // 
            this.lblNumQuestionText.AutoSize = true;
            this.lblNumQuestionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumQuestionText.Location = new System.Drawing.Point(24, 13);
            this.lblNumQuestionText.Name = "lblNumQuestionText";
            this.lblNumQuestionText.Size = new System.Drawing.Size(198, 25);
            this.lblNumQuestionText.TabIndex = 1;
            this.lblNumQuestionText.Text = "Question n° :        sur ";
            // 
            // tbxMult1
            // 
            this.tbxMult1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxMult1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMult1.Location = new System.Drawing.Point(54, 58);
            this.tbxMult1.MaxLength = 2;
            this.tbxMult1.Name = "tbxMult1";
            this.tbxMult1.Size = new System.Drawing.Size(60, 45);
            this.tbxMult1.TabIndex = 0;
            this.tbxMult1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxMult2
            // 
            this.tbxMult2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxMult2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMult2.Location = new System.Drawing.Point(193, 58);
            this.tbxMult2.MaxLength = 2;
            this.tbxMult2.Name = "tbxMult2";
            this.tbxMult2.Size = new System.Drawing.Size(60, 45);
            this.tbxMult2.TabIndex = 1;
            this.tbxMult2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxProduit
            // 
            this.tbxProduit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxProduit.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxProduit.Location = new System.Drawing.Point(339, 58);
            this.tbxProduit.MaxLength = 3;
            this.tbxProduit.Name = "tbxProduit";
            this.tbxProduit.Size = new System.Drawing.Size(60, 45);
            this.tbxProduit.TabIndex = 2;
            this.tbxProduit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.Location = new System.Drawing.Point(138, 65);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(32, 31);
            this.lblX.TabIndex = 3;
            this.lblX.Text = "X";
            // 
            // lblEgal
            // 
            this.lblEgal.AutoSize = true;
            this.lblEgal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEgal.Location = new System.Drawing.Point(281, 65);
            this.lblEgal.Name = "lblEgal";
            this.lblEgal.Size = new System.Drawing.Size(30, 31);
            this.lblEgal.TabIndex = 3;
            this.lblEgal.Text = "=";
            // 
            // btnAccept
            // 
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(235, 123);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(164, 48);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Suivant";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblNumQuestion
            // 
            this.lblNumQuestion.AutoSize = true;
            this.lblNumQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumQuestion.Location = new System.Drawing.Point(149, 13);
            this.lblNumQuestion.Name = "lblNumQuestion";
            this.lblNumQuestion.Size = new System.Drawing.Size(23, 25);
            this.lblNumQuestion.TabIndex = 1;
            this.lblNumQuestion.Text = "1";
            this.lblNumQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQTimer
            // 
            this.lblQTimer.AutoSize = true;
            this.lblQTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQTimer.Location = new System.Drawing.Point(166, 120);
            this.lblQTimer.Name = "lblQTimer";
            this.lblQTimer.Size = new System.Drawing.Size(34, 25);
            this.lblQTimer.TabIndex = 5;
            this.lblQTimer.Text = "10";
            this.lblQTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStartTimer
            // 
            this.lblStartTimer.AutoSize = true;
            this.lblStartTimer.Font = new System.Drawing.Font("Arial Rounded MT Bold", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTimer.ForeColor = System.Drawing.Color.Red;
            this.lblStartTimer.Location = new System.Drawing.Point(430, 23);
            this.lblStartTimer.Name = "lblStartTimer";
            this.lblStartTimer.Size = new System.Drawing.Size(144, 154);
            this.lblStartTimer.TabIndex = 6;
            this.lblStartTimer.Text = "3";
            // 
            // tmrQuestion
            // 
            this.tmrQuestion.Tick += new System.EventHandler(this.tmrQuestion_Tick);
            // 
            // lblQTimerText
            // 
            this.lblQTimerText.AutoSize = true;
            this.lblQTimerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQTimerText.Location = new System.Drawing.Point(23, 120);
            this.lblQTimerText.Name = "lblQTimerText";
            this.lblQTimerText.Size = new System.Drawing.Size(148, 25);
            this.lblQTimerText.TabIndex = 7;
            this.lblQTimerText.Text = "Temps restant :";
            // 
            // lblNumQuestionMax
            // 
            this.lblNumQuestionMax.AutoSize = true;
            this.lblNumQuestionMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumQuestionMax.Location = new System.Drawing.Point(212, 13);
            this.lblNumQuestionMax.Name = "lblNumQuestionMax";
            this.lblNumQuestionMax.Size = new System.Drawing.Size(23, 25);
            this.lblNumQuestionMax.TabIndex = 1;
            this.lblNumQuestionMax.Text = "1";
            this.lblNumQuestionMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgbTimer
            // 
            this.pgbTimer.Location = new System.Drawing.Point(28, 148);
            this.pgbTimer.Name = "pgbTimer";
            this.pgbTimer.Size = new System.Drawing.Size(172, 23);
            this.pgbTimer.Step = 1;
            this.pgbTimer.TabIndex = 8;
            this.pgbTimer.Value = 100;
            // 
            // Questionnaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 192);
            this.Controls.Add(this.pgbTimer);
            this.Controls.Add(this.lblQTimerText);
            this.Controls.Add(this.lblStartTimer);
            this.Controls.Add(this.lblQTimer);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblEgal);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.tbxProduit);
            this.Controls.Add(this.tbxMult2);
            this.Controls.Add(this.tbxMult1);
            this.Controls.Add(this.lblNumQuestionMax);
            this.Controls.Add(this.lblNumQuestion);
            this.Controls.Add(this.lblNumQuestionText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Questionnaire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Partie";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmrDecompte;
        private System.Windows.Forms.Label lblNumQuestionText;
        private System.Windows.Forms.TextBox tbxMult1;
        private System.Windows.Forms.TextBox tbxMult2;
        private System.Windows.Forms.TextBox tbxProduit;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblEgal;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblNumQuestion;
        private System.Windows.Forms.Label lblQTimer;
        private System.Windows.Forms.Label lblStartTimer;
        private System.Windows.Forms.Timer tmrQuestion;
        private System.Windows.Forms.Label lblQTimerText;
        private System.Windows.Forms.Label lblNumQuestionMax;
        private System.Windows.Forms.ProgressBar pgbTimer;
    }
}