using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Speech.Synthesis;

namespace RepetiteurLivrets {

    /// <summary>
    /// Form qui affiche les résultats du questionnaire
    /// </summary>
    public partial class Resultats : Form {

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Resultats() {
            InitializeComponent();
        }

        /// <summary>
        /// Constructeur qui prend en paramètre la liste des questions qui ont été posées, et la liste des réponses données.
        /// </summary>
        /// <param name="listeQuestions">Tableau contenant les objets Question qui ont été posées dans la partie</param>
        /// <param name="listeReponses">Tableau contenant les objets Reponse qui ont été données dans la partie</param>
        /// <param name="partieEffectuee">Objet contenant les paramètres de la partie (difficulté, nom du joueur, etc)</param>
        public Resultats(Question[] listeQuestions, Reponse[] listeReponses, Partie partieEffectuee) {
            InitializeComponent();

            // On lance un timer qui permet d'avoir un délai sur l'activation du bouton de fermeture de la Form
            tmrDelai.Start();

            // On définit la taille de la fenêtre et de la textbox en fonction du nombre de questions
            rtxtResultats.Width = 420;
            this.Width = rtxtResultats.Width + 40;
            rtxtResultats.Left = this.ClientSize.Width / 2 - (rtxtResultats.Width / 2);
            rtxtResultats.Height = 10 + listeQuestions.Length * 10;

            // On replace correctement tous les éléments
            this.Height = rtxtResultats.Height + pnlElemBas.Height + 50;
            pnlElemBas.Top = rtxtResultats.Height + 10;
            pnlElemBas.Left = this.ClientSize.Width / 2 - (pnlElemBas.Width / 2);

            // On clear la zone d'affichage des résultats au cas où
            rtxtResultats.Clear();

            // Compteur de bonnes réponses
            int iNbCorrect = 0;

            // On vérifie toutes les réponses et on affiche la question avec le bon formattage:
            // Rouge = Mauvaise réponse
            // Vert = Bonne réponse
            for (int i = 0; i < listeQuestions.Length; i++) {
                Question q = listeQuestions[i];
                Reponse r = listeReponses[i];

                string a = q.Mult1.ToString();
                string b = q.Mult2.ToString();
                string c = q.Produit.ToString();

                // Vérification du résultat
                bool bReponseCorrect = CheckReponse(r);

                int iNumQuestion = i + 1;

                // Affichage du numéro de question avec la bonne couleur
                if (bReponseCorrect) {
                    AppendText(rtxtResultats, Color.Green, String.Format("{0} {1,-2}: ", "Question", iNumQuestion));
                    // Incrémentation du nb de bonnes réponses
                    iNbCorrect++;
                }
                else {
                    AppendText(rtxtResultats, Color.Red, String.Format("{0} {1,-2}: ", "Question", iNumQuestion));
                }

                // Affichage du multiple 1
                if ((q.Trou == 1 || q.Trou == 4) && !bReponseCorrect) {
                    AppendText(rtxtResultats, Color.Red, a);
                }
                else if ((q.Trou == 1 || q.Trou == 4) && bReponseCorrect) {
                    AppendText(rtxtResultats, Color.Green, a);
                }
                else if (q.Trou != 1 && q.Trou != 4) {
                    AppendText(rtxtResultats, Color.Empty, a);
                }

                AppendText(rtxtResultats, Color.Empty, " x ");

                // Affichage du multiple 2
                if ((q.Trou == 2 || q.Trou == 4) && !bReponseCorrect) {
                    AppendText(rtxtResultats, Color.Red, b);
                }
                else if ((q.Trou == 2 || q.Trou == 4) && bReponseCorrect) {
                    AppendText(rtxtResultats, Color.Green, b);
                }
                else if (q.Trou != 2 && q.Trou != 4) {
                    AppendText(rtxtResultats, Color.Empty, b);
                }

                AppendText(rtxtResultats, Color.Empty, " = ");

                // Affichage du produit
                if (q.Trou == 3 && !bReponseCorrect) {
                    AppendText(rtxtResultats, Color.Red, c);
                }
                else if (q.Trou == 3 && bReponseCorrect) {
                    AppendText(rtxtResultats, Color.Green, c);
                }
                else if (q.Trou != 3) {
                    AppendText(rtxtResultats, Color.Empty, c);
                }

                // Ajout d'un retour à la ligne si on est pas à la dernière ligne
                if (iNumQuestion < listeQuestions.Length && iNumQuestion % 2 == 0) {
                    rtxtResultats.AppendText("\r\n");
                }
                // Tabulation pour création 2 colonnes
                else {
                    rtxtResultats.AppendText("\t");
                }
            }

            // Affichage du nombre de bonnes réponses et du pourcentage de réussite
            lblNbBonneRep.Text = Convert.ToString(iNbCorrect) + " / " + Convert.ToString(listeQuestions.Length);
            int iPourcentage = Convert.ToInt32(Convert.ToDouble(iNbCorrect) / Convert.ToDouble(listeQuestions.Length) * 100);
            lblPourcentage.Text = iPourcentage + "%";

            // Changement de couleur d'affichage en fonction du pourcentage
            if (iPourcentage >= 75) {
                lblPourcentage.ForeColor = Color.Green;
                ReadText("Tu es un vrai dingo des plages!");
            }
            else if (iPourcentage >= 50) {
                lblPourcentage.ForeColor = Color.Orange;
                ReadText("Je pense que tu peux mieux faire.");
            }
            else if (iPourcentage >= 30) {
                lblPourcentage.ForeColor = Color.DarkOrange;
                ReadText("Tu as encore besoin de t'entrainer");
            }
            else {
                lblPourcentage.ForeColor = Color.Red;
                ReadText("Bravo, tu travailleras au Mac donald toute ta vie");
            }

            // Enregistrement des résultats dans le fichier du joueur
            EnregistrerScore(partieEffectuee.Joueur, iNbCorrect, listeQuestions.Length);
        }

        /// <summary>
        /// Méthode permettant de vérifier une réponse
        /// </summary>
        /// <param name="r">Objet Reponse que l'on souhaite tester</param>
        /// <returns>Retourne true en cas de réponse correcte, sinon retourne false</returns>
        private bool CheckReponse(Reponse r) {
            bool bReponseCorrecte = true;

            if (r.Mult1 * r.Mult2 != r.Produit) {
                bReponseCorrecte = false;
            }

            return bReponseCorrecte;
        }

        /// <summary>
        /// Méthode qui enregistre dans le fichier de sauvegarde les scores du joueur en cours
        /// </summary>
        /// <param name="nomJoueur">Nom du joueur qui a lancé la partie</param>
        /// <param name="nbCorrect">Nombre de réponses correctes</param>
        /// <param name="nbQuestion">Nombre de questions qui ontété posées</param>
        private void EnregistrerScore(string nomJoueur, int nbCorrect, int nbQuestion) {
            // Création, si besoin, du dossier qui contient les données

            // String qui contient le chemin vers le dossier data à la racine de l'exécutable
            string dirPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "data");
            if (!Directory.Exists(dirPath)) {
                DirectoryInfo di = Directory.CreateDirectory(dirPath);
            }
            // Création, si besoin, du fichier qui contient les stats des joueurs. Attention à bien le fermer ensuite sinon on ne pourra pas le lire
            string filePath = Path.Combine(dirPath, "playerscore.csv");
            if (!File.Exists(filePath)) {
                File.Create(filePath).Close();
            }

            // Crée un fichier temporaire. Attention à bien le fermer ensuite sinon on ne pourra pas écrire dedans
            File.Create(filePath + "new").Close();

            // Ouvre en lecture le fichier original
            StreamReader sr = new StreamReader(filePath);
            // Ouvre en écriture le nouveau fichier
            StreamWriter sw = new StreamWriter(filePath + "new", true);

            string line;
            bool joueurTrouve = false;

            // Parcours chaque ligne du fichier
            while ((line = sr.ReadLine()) != null) {
                    string[] splitLine = line.Split(';');
                    // Vérifie si la ligne appartient au joueur (nom non sensible à la casse)
                    if (splitLine[0].ToUpperInvariant() == nomJoueur.ToUpperInvariant()) {
                        // On calcule le nouveau score
                        int newNbCorrect = Convert.ToInt32(splitLine[1]) + nbCorrect;
                        int newNbQuestion = Convert.ToInt32(splitLine[2]) + nbQuestion;
                        int newNbPartie = Convert.ToInt32(splitLine[3]) + 1;

                        // On écrit la ligne modifiée
                        sw.WriteLine(nomJoueur + ";" + newNbCorrect + ";" + newNbQuestion + ";" + newNbPartie);

                        // On indique que le joueur a été trouvé dans le fichier
                        joueurTrouve = true;
                    }
                    // On recopie la ligne telle qu'elle si elle n'appartient pas au joueur
                    else {
                        sw.WriteLine(line);
                    }
            }
            // Si le joueur n'a pas été trouvé dans le fichier, on écrit une nouvelle ligne à la fin du fichier
            if (!joueurTrouve){
                sw.WriteLine(nomJoueur + ";" + nbCorrect + ";" + nbQuestion + ";1");
            }

            // On ferme les deux flux
            sr.Close();
            sw.Close();

            // On efface le fichier original
            File.Delete(filePath);
            // On "renomme" le nouveau fichier
            File.Copy(filePath + "new", filePath);
            File.Delete(filePath + "new");
        }

        /// <summary>
        /// Méthode permettant d'ajouter du texte dans une RichTextBox avec une couleur donnée
        /// </summary>
        /// <param name="box">Nom de la RichTextBox dans laquelle on aimerait ajouter le texte</param>
        /// <param name="color">Couleur que l'on veut donner au texte</param>
        /// <param name="text">Chaine de caractère que l'on souhaite ajouter</param>
        private void AppendText(RichTextBox box, Color color, string text) {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;

            // Textbox may transform chars, so (end-start) != text.Length
            box.Select(start, end - start);
            {
                box.SelectionColor = color;
                // could set box.SelectionBackColor, box.SelectionFont too.
            }
            box.SelectionLength = 0; // clear
        }

        /// <summary>
        /// Méthode déclenchée en cas de clic sur le bouton "Retour" pour terminer la visualisation des résultats et retourner au menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetour_Click(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        /// Méthode déclenchée lors du tick (unique) du Timer. Au bout de 2 secondes, active le bouton de fermeture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrDelai_Tick(object sender, EventArgs e) {
            tmrDelai.Stop();
            btnRetour.Enabled = true;
            btnRetour.Focus();
        }

        private void ReadText(string TTS) {
            SpeechSynthesizer s = new SpeechSynthesizer();
            s.SelectVoice("ScanSoft Virginie_Dri40_16kHz");
            s.Volume = 100;  // 0...100
            s.Rate = 0;     // -10...10
            s.SpeakAsync(TTS);
        }
    }
}
