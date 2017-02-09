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

namespace RepetiteurLivrets {
    /// <summary>
    /// Première Form du programme. Affiche le menu
    /// </summary>
    public partial class Menu : Form {
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Menu() {
            InitializeComponent();
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="NomJoueur">String contenant le nom du joueur</param>
        public Menu(string NomJoueur) {
            InitializeComponent();
            lblJoueur.Text = NomJoueur;
            MiseAJourAffichage();
            Create_ToolTips();
        }

        /// <summary>
        /// Méthode qui regroupe la création de toutes les infobulles de la form
        /// </summary>
        private void Create_ToolTips() {
            // Création d'un objet ToolTip
            ToolTip toolTip = new ToolTip();

            // Mise en place du délai des tooltips
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            // on force le tooltip à s'afficher même si le focus n'est pas sur la form
            toolTip.ShowAlways = true;

            // Mise en place des différentes infobulles
            toolTip.SetToolTip(this.rbtn6H,"Livrets de 1 à 9");
            toolTip.SetToolTip(this.rbtn7H, "Livrets de 1 à 12");
            toolTip.SetToolTip(this.rbtnFacile, "10 questions plus lentes");
            toolTip.SetToolTip(this.rbtnMoyen, "20 questions rapides");
            toolTip.SetToolTip(this.rbtnDifficile, "30 questions très rapides\r\nPour les champions des livrets !");
            toolTip.SetToolTip(this.btnChangementJoueur, "Retourne sur l'accueil pour changer de joueur");
            toolTip.SetToolTip(this.btnPartie, "Lance une nouvelle série de questions avec les paramètres sélectionnés");
            toolTip.SetToolTip(this.btnReset, "Efface toutes les statistiques pour le joueur actuel\r\nATTENTION: Cette action est irréversible!");
            toolTip.SetToolTip(this.btnAide, "Ouvre le manuel utilisateur");
        }

        /// <summary>
        /// Méthode déclenchée lors du click sur le bouton "Démarrer" pour lancer une nouvelle partie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPartie_Click(object sender, EventArgs e) {
           Partie p = new Partie();

            // On set la partie en fonction du niveau
            if (rbtn6H.Checked) {
                p.Niveau = "6H";
            }
            else if (rbtn7H.Checked) {
                p.Niveau = "7H";
            }

            // On set la partie en fonction de la difficulté choisie
            if (rbtnFacile.Checked) {
                p.Difficulte = "Facile";
                p.NbQuestion = 10;
            }
            else if (rbtnMoyen.Checked) {
                p.Difficulte = "Moyen";
                p.NbQuestion = 20;
            }
            else if (rbtnDifficile.Checked) {
                p.Difficulte = "Difficile";
                p.NbQuestion = 30;
            }

            // On indique le joueur qui lance la partie
            p.Joueur = lblJoueur.Text;

            // On démarre la partie en passant les paramètres
            Questionnaire NouvellePartie = new Questionnaire(p);
            // Affichage de la fenêtre de partie
            this.Hide();
            NouvellePartie.ShowDialog();
            // La Form se réaffiche lorsque la Form appelée par "ShowDialog" est fermée.
            this.Show();
            MiseAJourAffichage();

        }

        /// <summary>
        /// Méthode qui met à jour l'affichage des informations à propos du joueur en allant les chercher dans le fichier de sauvegarde
        /// </summary>
        private void MiseAJourAffichage() {
            string strNomJoueur = lblJoueur.Text;

            // Création, si besoin, du dossier qui contient les données des joueurs
            string dirPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "data");
            if (!Directory.Exists(dirPath)) {
                DirectoryInfo di = Directory.CreateDirectory(dirPath);
            }

            // Création, si besoin, du fichier qui contient les stats des joueurs
            string filePath = Path.Combine(dirPath, "playerscore.csv");
            if (!File.Exists(filePath)) {
                File.Create(filePath).Close();
            }
            // Ouverture du fichier à la recherche du nom de joueur
            StreamReader file = new StreamReader(filePath);

            // On parcours le fichier
            string line;
            bool joueurTrouve = false;
            while ((line = file.ReadLine()) != null) {
                string[] splitLine = line.Split(';');
                // Vérifie si la ligne appartient au joueur (nom non sensible à la casse)
                if (splitLine[0].ToUpperInvariant() == strNomJoueur.ToUpperInvariant()) {
                    // Si le joueur est trouvé, on affiche ses scores
                    int iScore = Convert.ToInt32(Convert.ToDouble(splitLine[1]) / Convert.ToDouble(splitLine[2]) * 100);
                    lblScore.Text = Convert.ToString(iScore) + "%";

                    // Changement de la couleur du label en fonction du score
                    if (iScore >= 75) {
                        lblScore.ForeColor = Color.Green;
                    }
                    else if (iScore >= 50) {
                        lblScore.ForeColor = Color.Orange;
                    }
                    else if (iScore >= 30) {
                        lblScore.ForeColor = Color.DarkOrange;
                    }
                    else {
                        lblScore.ForeColor = Color.Red;
                    }

                    lblNbPartie.Text = splitLine[3];

                    // On indique que le joueur a été trouvé dans le fichier
                    joueurTrouve = true;
                }
            }
            // Si le joueur n'a pas été trouvé dans le fichier, on affiche un score vide
            if (!joueurTrouve) {
                lblScore.Text = "-";
                lblScore.ForeColor = Color.Black;
                lblNbPartie.Text = "0";
            }
            // On ferme le flux
            file.Close();
        }

        /// <summary>
        /// Méthode déclenchée lors du clic sur le bouton changement de joueur. Ferme cette form et recharge l'accueil (qui est en attente grâce à ShowDialog)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangementJoueur_Click(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        /// Méthode déclenchée lors du clic sur le bouton RESET. Reset les scores du joueur actuel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e) {

            string strNomJoueur = lblJoueur.Text;
            // On demande si l'utilisateur veut vraiment effacer les scores
            DialogResult r = MessageBox.Show("Veux-tu vraiment effacer les scores du joueur \"" + strNomJoueur + "\" ?\r\nCette action est irréversible.", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes) {
                // String qui contient le chemin vers le dossier data à la racine de l'exécutable
                string dirPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "data");
                // String qui contient le chemin du fichier de scores
                string filePath = Path.Combine(dirPath, "playerscore.csv");

                // On vérifie si le fichier existe. S'il n'existe pas, on ne fait rien.
                if (File.Exists(filePath)) {

                    // Crée un fichier temporaire. Attention à bien le fermer ensuite sinon on ne pourra pas écrire dedans
                    File.Create(filePath + "new").Close();

                    // Ouvre en lecture le fichier original
                    StreamReader sr = new StreamReader(filePath);
                    // Ouvre en écriture le nouveau fichier
                    StreamWriter sw = new StreamWriter(filePath + "new", true);

                    string line;

                    // Parcours chaque ligne du fichier
                    while ((line = sr.ReadLine()) != null) {
                        string[] splitLine = line.Split(';');
                        // Vérifie si la ligne appartient au joueur (nom non sensible à la casse)
                        if (splitLine[0].ToUpperInvariant() == strNomJoueur.ToUpperInvariant()) {
                            // On ne fait rien. (Le but est d'effacer la ligne du joueur.
                        }
                        // On recopie la ligne telle qu'elle si elle n'appartient pas au joueur
                        else {
                            sw.WriteLine(line);
                        }
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
                // On fait une mise à jour de l'affichage
                MiseAJourAffichage();
            }
        }

        /// <summary>
        /// Méthode déclenchée par le clic sur le bouton d'aide. Ouvre le manuel utilisateur en PDF des ressources du projet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Help_Click(object sender, EventArgs e) {
            try {
                // Création d'un fichier PDF temporaire à partir de la ressource
                String openPDFFile = @"c:\temp\ManuelUtilisateur_RepetiteurLivrets.pdf";
                File.WriteAllBytes(openPDFFile, Properties.Resources.ManuelUtilisateur);
                // Ouverture du PDF
                System.Diagnostics.Process.Start(openPDFFile);
            }
            // En cas d'erreur
            catch {
                MessageBox.Show("Erreur lors de l'ouverture du manuel utilisateur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
