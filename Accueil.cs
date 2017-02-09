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
    public partial class Accueil : Form {

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Accueil() {
            InitializeComponent();
            Create_ToolTips();
        }

        /// <summary>
        /// Méthode déclenchée lors du clic sur le bouton "Commencer". Vérifie si le nom du joueur est bien entré. Si oui, on ouvre le menu. Si non, on redemande d'entrer un nom.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) {
            string strNomJoueur = cbxJoueur.Text;
            // Si le nom du joueur est vide (ou si c'est le message d'erreur), on demande à entrer un nom
            if (strNomJoueur == "" || strNomJoueur == "Entre un nom de joueur !") {
                cbxJoueur.ForeColor = Color.Red;
                cbxJoueur.Text = "Entre un nom de joueur !";
            }
            // Si le nom n'est pas vide, on ouvre le menu en passant le nom dans le constructeur
            else {
                Menu f = new Menu(strNomJoueur);
                this.Hide();
                f.ShowDialog();
                // Ré-affiche l'accueil lorsque le menu est fermé
                this.Show();
            }
        }

        /// <summary>
        /// Evènement qui permet de déclencher, avec la touche Enter, un clic sur le bouton "Commencer" sans avoir le focus sur le bouton
        /// </summary>
        /// <param name="sender">Objet qui déclenche l'évènement</param>
        /// <param name="e">Touche qui a été appuyée pour déclencher l'évènement</param>
        private void OnKeyDownHandler(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return) {
                // On met le focus sur le bouton, pour que le focus ne soit plus sur la textbox (cela permet de pouvoir rappeler la méthode "OnEnter" si on veut retaper du texte)
                btnValider.Focus();
                btnValider.PerformClick();
            }
        }

        /// <summary>
        /// Méthode déclenchée lors du déroulement de la liste. Permet de récupérer tous les noms d'utilisateurs dans le fichier de sauvegarde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaJ_Liste_Joueurs(object sender, EventArgs e) {
            // On efface toute la liste actuelle
            cbxJoueur.Items.Clear();

            // On vérifie si le fichier de sauvegarde existe
            string dirPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "data");
            string filePath = Path.Combine(dirPath, "playerscore.csv");
            if (File.Exists(filePath)) {
                // Ouverture du fichier
                StreamReader file = new StreamReader(filePath);

                // On parcours le fichier
                string line;
                while ((line = file.ReadLine()) != null) {
                    string[] splitLine = line.Split(';');
                    // On ajoute le nom du joueur dans la liste
                    cbxJoueur.Items.Add(splitLine[0]);
                }
                // On ferme le flux
                file.Close();
            }
        }

        /// <summary>
        /// Méthode qui se déclenche lors qu'on place le focus sur la checkbox de sélection de joueur. Permet notamment d'effacer le message d'erreur en cliquant dessus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_OnEnter(object sender, EventArgs e) {
            cbxJoueur.Text = "";
            cbxJoueur.ForeColor = Color.Black;
        }

        /// <summary>
        ///  Méthode déclenchée lors du clic sur le bouton "Quitter". Permet de demander la confirmation avant de fermer l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }


        /// <summary>
        /// Méthode qui demande une confirmation à la fermeture de la form
        /// </summary>
        /// <returns>Retourne true si l'utilisateur accepte la fermeture de la form. Sinon renvoie false</returns>
        private bool Exit_Confirmation() {
            DialogResult result = MessageBox.Show("Es-tu sûr de vouloir quitter l'application ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// Méthode déclenchée lorsque la Form est sur le point de se fermer. Permet d'appeler une fonction qui demande une confirmation de fermeture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_Close(object sender, FormClosingEventArgs e) {
            if (Exit_Confirmation() == false) {
                e.Cancel = true;
            }
            else {
                // Suppression du fichier temporaire du manuel utilisateur
                File.Delete(@"C:\temp\ManuelUtilisateur_RepetiteurLivrets.pdf");
            }
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
            toolTip.SetToolTip(this.btnValider, "Commencer la partie avec le joueur entré");
            toolTip.SetToolTip(this.btnExit, "Ferme l'application");
            toolTip.SetToolTip(this.cbxJoueur, "Entre ou choisis ton nom de joueur");
        }
    }
}
