using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace RepetiteurLivrets {
    /// <summary>
    /// Form qui affiche les questions de la partie en cours
    /// </summary>
    public partial class Questionnaire : Form {
        
        // Variables globales à la classe
        Question[] listeQuestions;
        Reponse[] listeReponses;
        Partie partieEnCours;
        int iQTimer;
        static System.Globalization.CultureInfo ci;
        static SpeechRecognitionEngine sre;
        bool bReconnaissanceActivee = false;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Questionnaire() {
            InitializeComponent();
        }

        /// <summary>
        /// Constructeur de la Form2
        /// </summary>
        /// <param name="p">Objet "Partie" qui contient les attributs d'une partie (difficulté, classe)</param>
        public Questionnaire(Partie p) {
            InitializeComponent();
            // On crée la liste de questions en fonction des paramètres
            listeQuestions = CreerQuestions(p);
            // On crée la liste vide de réponses
            listeReponses = new Reponse[listeQuestions.Length];
            // On assigne le paramètre partie à la variable partie
            partieEnCours = p;
            // On initialise la reconnaissance vocale
            InitRecognition();

            // On cache chaque contrôle avant de donner le top
            tbxMult1.Visible = false;
            tbxMult2.Visible = false;
            tbxProduit.Visible = false;
            lblEgal.Visible = false;
            lblNumQuestion.Visible = false;
            lblNumQuestionMax.Visible = false;
            lblNumQuestionText.Visible = false;
            lblQTimer.Visible = false;
            lblX.Visible = false;
            btnAccept.Visible = false;
            lblQTimerText.Visible = false;
            pgbTimer.Visible = false;
            lblListening.Visible = false;
            cbxReconnaissance.Visible = false;

            // On affiche le nb de questions max dans un contrôle
            lblNumQuestionMax.Text = listeQuestions.Length.ToString();

            // On définit le temps à disposition pour chaque question et on modifie le titre de la form
            if (p.Difficulte == "Facile") {
                iQTimer = 150;
                this.Text = "Partie en mode facile";
            }
            else if (p.Difficulte == "Moyen") {
                iQTimer = 100;
                this.Text = "Partie en mode moyen";
            }
            else if (p.Difficulte == "Difficile") {
                iQTimer = 50;
                this.Text = "Partie en mode difficile";
            }

            // Initialisation de la progress bar du temps restant
            pgbTimer.Maximum = iQTimer;
            pgbTimer.Value = iQTimer;

            // On place le décompte au milieu de la form
            lblStartTimer.Left = this.ClientSize.Width / 2 - lblStartTimer.Width / 2;
            lblStartTimer.Top = this.ClientSize.Height / 2 - lblStartTimer.Height / 2;
            // On lance le décompte avant le début de la partie
            tmrDecompte.Start();

        }

        /// <summary>
        /// Evènement qui permet de déclencher, avec la touche Enter, un clic sur le bouton "Prochaine question" sans avoir le focus sur le bouton
        /// </summary>
        /// <param name="sender">Objet qui déclenche l'évènement</param>
        /// <param name="e">Touche qui a été appuyée pour déclencher l'évènement</param>
        private void OnKeyDownHandler(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return) {
                // Dans le cas où on doit remplir 2 cases (Mult1 et Mult2),
                // on veut pouvoir passer du premier au deuxième avec enter
                if (tbxMult1.Focused && tbxMult2.ReadOnly == false && tbxMult2.Text == "") {
                    tbxMult2.SelectAll();
                    tbxMult2.Focus();
                }
                else {
                    btnAccept.PerformClick();
                }
            }
            // Lancement de la reconnaissance vocale lorsque F1 est enfoncé et qu'il n'écoute pas déjà
            else if (e.KeyCode == Keys.ShiftKey && !cbxReconnaissance.Checked) {
                StartListening();
            } 
        }

        private void Questionnaire_KeyUp(object sender, KeyEventArgs e) {
            // Arrêt de la reconnaissance vocale
            if (e.KeyCode == Keys.ShiftKey && !cbxReconnaissance.Checked) {
                StopListening();
            }
        }

        /// <summary>
        /// Méthode qui exécute toutes les actions nécessaires au début de partie (mise en place des éléments de la forme notamment)
        /// A la fin, déclenche la première question
        /// </summary>
        private void DebutPartie() {
            // On affiche tous les contrôles
            tbxMult1.Visible = true;
            tbxMult2.Visible = true;
            tbxProduit.Visible = true;
            lblEgal.Visible = true;
            lblNumQuestion.Visible = true;
            lblNumQuestionMax.Visible = true;
            lblNumQuestionText.Visible = true;
            lblQTimer.Visible = true;
            lblX.Visible = true;
            btnAccept.Visible = true;
            lblQTimerText.Visible = true;
            pgbTimer.Visible = true;
            if (bReconnaissanceActivee)
                cbxReconnaissance.Visible = true;

            // On démarre le timer pour les questions
            lblQTimer.Text = String.Format("{0:0.0}",(Convert.ToDouble(iQTimer)/10));
            lblQTimer.ForeColor = Color.Black;
            pgbTimer.Value = iQTimer;

            tmrQuestion.Start();

            // On affiche la première question
            NextQuestion();
            
        }

        /// <summary>
        /// Méthode qui permet l'affichage dans les textbox de la prochaine question de la liste
        /// </summary>
        /// <returns>Retourne true en cas de réussite d'affichage, sinon, renvoie false</returns>
        private void NextQuestion() {
            int iNumQuestion = Convert.ToInt32(lblNumQuestion.Text);
            Question q = listeQuestions[iNumQuestion - 1];

            // On désactive chaque textbox
            tbxMult1.ReadOnly = true;
            tbxMult2.ReadOnly = true;
            tbxProduit.ReadOnly = true;

            string a = q.Mult1.ToString();
            string b = q.Mult2.ToString();
            string c = q.Produit.ToString();

            // Affichage des textbox en fonction du trou, pour l'entrée des réponses
            switch (q.Trou) {
                case 1:
                    a = "";
                    tbxMult1.ReadOnly = false;
                    tbxMult1.SelectAll();
                    tbxMult1.Focus();
                    break;
                case 2:
                    b = "";
                    tbxMult2.ReadOnly = false;
                    tbxMult2.SelectAll();
                    tbxMult2.Focus();
                    break;
                case 3:
                    c = "";
                    tbxProduit.ReadOnly = false;
                    tbxProduit.SelectAll();
                    tbxProduit.Focus();
                    break;
                case 4:
                    a = "";
                    b = "";
                    tbxMult1.ReadOnly = false;
                    tbxMult2.ReadOnly = false;
                    tbxMult1.SelectAll();
                    tbxMult1.Focus();
                    break;
            }

            // Affichage dans chaque textbox
            tbxMult1.Text = a;
            tbxMult2.Text = b;
            tbxProduit.Text = c;

            ReadQuestion(q);
        }

        /// <summary>
        /// Méthode permettant de créer la liste de questions à partir des options choisies pour la partie
        /// </summary>
        /// <param name="p">Object partie, contenant les attributs d'une partie (difficulté, classe)</param>
        /// <returns>Retourne un tableau d'objets Questions</returns>
        private Question[] CreerQuestions(Partie p) {
            // On crée le tableau de questions avec la bonne taille
            Question[] listeQuestions = new Question[p.NbQuestion];

            // On définit le multiple maximum en fonction du niveau choisi
            // 9 pour les élèves jusqu'à 6 HarmoS
            // 12 pour les élèves jusqu'à 7 HarmoS
            int iMaxMult = 0; ;
            if (p.Niveau == "6H") {
                iMaxMult = 9;
            }
            else if (p.Niveau == "7H") {
                iMaxMult = 12;
            }

            // Générateur de nombre aléatoire dont on a besoin
            Random rnd = new Random();

            // On parcours ce tableau et on génère les questions
            for (int i = 0; i < listeQuestions.Length; i++) {
                Question q = new Question();
                q.Mult1 = RandomPondere(iMaxMult, rnd);
                q.Mult2 = RandomPondere(iMaxMult, rnd);
                q.Produit = q.Mult1 * q.Mult2;

                // On génère également l'endroit du "trou"
                // C'est-à-dire où l'utilisateur doit entrer sa réponse
                // 1 : Multiple1, 2 : Multiple2, 3: Produit, 4: Les deux multiples
                q.Trou = rnd.Next(1,5);

                // On ajoute la question au tableau
                listeQuestions[i] = q;
            }
            // Retour du tableau rempli
            return listeQuestions;
        }

        /// <summary>
        /// Méthode déclenchée à chaque tick du compteur de départ. Permet de lancer la partie à l'expiration du temps
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrDecompte_Tick(object sender, EventArgs e) {
            int iTimer = Convert.ToInt32(lblStartTimer.Text);
            if (iTimer <= 1) {
                DebutPartie();
                lblStartTimer.Visible = false;
                tmrDecompte.Stop();
            }
            else {
                iTimer--;
                lblStartTimer.Text = iTimer.ToString();
            } 
        }

        /// <summary>
        /// Méthode déclenchée à chaque tick du compteur des questions. A l'expiration, passe à la prochaine question.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrQuestion_Tick(object sender, EventArgs e) {
            int iTimer = pgbTimer.Value;
            if (iTimer <= 1) {
                // On passe à la question suivante
                btnAccept_Click(btnAccept,e);
            }
            else {
                iTimer--;
                // Affichage des secondes avec les dixièmes
                lblQTimer.Text = String.Format("{0:0.0}", (Convert.ToDouble(iTimer) / 10));
                // On change la couleur du texte du temps restant s'il reste moins de 3 sec
                if (iTimer <= 30) {
                    lblQTimer.ForeColor = Color.Red;
                }
                // Changement de la valeur de la progress bar
                pgbTimer.Value = iTimer;
            }
        }

        /// <summary>
        /// Méthode permettant de retourner un entier de la réponse donnée par l'utilisateur dans une textbox. Si l'entrée n'est pas un entier, elle est considérée comme nulle (0)
        /// </summary>
        /// <param name="tbx">Textbox dans laquelle récupérer le text à tester</param>
        /// <returns>Retourne un entier quelle que soit le type d'entrée</returns>
        private int EntreeReponse(TextBox tbx) {
            int iReponse;
            if (!int.TryParse(tbx.Text, out iReponse)) {
                iReponse = 0;
            }
            return iReponse;
        }

        /// <summary>
        /// Méthode déclenchée lors du clic sur le bouton btnAccept (Question suivante)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e) {
            // On incrémente le numéro de la question
            int iNumQuestion = Convert.ToInt32(lblNumQuestion.Text);
            lblNumQuestion.Text = Convert.ToString(iNumQuestion + 1);

            // On reset le timer
            tmrQuestion.Stop();
            tmrQuestion.Start();
            lblQTimer.Text = (iQTimer/10).ToString();
            lblQTimer.ForeColor = Color.Black;
            pgbTimer.Value = iQTimer;

            Reponse r = new Reponse();
            // On stocke la réponse
            r.Mult1 = EntreeReponse(tbxMult1);
            r.Mult2 = EntreeReponse(tbxMult2);
            r.Produit = EntreeReponse(tbxProduit);
            listeReponses[iNumQuestion - 1] = r;

            // On affiche la prochaine question
            // S'il en reste
            if (iNumQuestion + 1 <= listeQuestions.Length) {             
                NextQuestion();
            }
            else {
                tmrQuestion.Stop();
                Resultats AfficheResultats = new Resultats(listeQuestions, listeReponses, partieEnCours);
                this.Hide();
                AfficheResultats.ShowDialog();
                AfficheResultats.Focus();
                this.Close();
            }
        }

        /// <summary>
        /// Méthode permettant de générer un nombre pseudo-aléatoire en fonction, tout en évitant les multiples trop faciles comme le 1 et le 10
        /// </summary>
        /// <param name="iMax">Nombre entier maximal possible du nombre aléatoire</param>
        /// <param name="rnd">Objet Random initialisé en dehors de la méthode</param>
        /// <returns>Retourne un nombre entier pseudo aléatoire</returns>
        private int RandomPondere(int iMax, Random rnd) {
            int iValTemp;
            int iChance;
            int iVal = 0;

            do {
                // On génère un nombre temporaire
                iValTemp = rnd.Next(1, iMax + 1);

                switch (iValTemp) {
                    // Multiples faciles
                    case 1:
                    case 10:
                        // On divise de 2/3 les chances d'avoir un multiple facile
                        if ((iChance = rnd.Next(1,4)) < 3){
                            iVal = iValTemp;
                        }
                        break;
                    // Multiples "moyens-faciles"
                    case 2:
                    // case 3: //Décommenter pour ajouter à la liste ces multiples
                    // case 5:
                        // On divise de 4/5 les chances d'avoir un multiple "moyen-facile"
                        if ((iChance = rnd.Next(1,6)) < 5) {
                            iVal = iValTemp;
                        }
                        break;
                    // Autres multiples
                    default:
                        iVal = iValTemp;
                        break;
                }
            } while (iVal == 0) ;
            return iVal;
        }

        /// <summary>
        /// Méthode qui lance un TextToSpeech qui lit la question passée en paramètre
        /// </summary>
        /// <param name="q">Object question à lire</param>
        private void ReadQuestion(Question q) {
            SpeechSynthesizer s = new SpeechSynthesizer();
            s.SelectVoice("ScanSoft Virginie_Dri40_16kHz");
            s.Volume = 100;  // 0...100
            s.Rate = 0;     // -10...10

            string a = q.Mult1.ToString();
            string b = q.Mult2.ToString();
            string c = q.Produit.ToString();

            switch (q.Trou){
                case 1:
                    a = "combien";
                    break;
                case 2:
                    b = "combien";
                    break;
                case 3:
                    c = "combien";
                    break;
                case 4:
                    a = "combien";
                    b = "combien";
                    break;
            }

            string strTTS = a + " fois " + b  + " égal " + c + "!";
            s.SpeakAsyncCancelAll();
            s.SpeakAsync(strTTS);
        }

        /// <summary>
        /// Méthode qui initialise le moteur de reconnaissance vocale
        /// </summary>
        public void InitRecognition() {
            ci = new System.Globalization.CultureInfo("fr-FR");
            sre = new SpeechRecognitionEngine(ci);
            // Active la reconnaissance vocale si un micro est configuré
            try {
                sre.SetInputToDefaultAudioDevice();
                bReconnaissanceActivee = true;
            }
            // Sinon désactive la reconnaissance vocale
            catch {
                bReconnaissanceActivee = false;
            }

            if (bReconnaissanceActivee) {                
                sre.SpeechRecognized += sre_SpeechRecognized;
                // Charge la grammaire de la réponse
                sre.LoadGrammarAsync(GetResponseGrammar());
                // Charge la grammaire des commandes
                sre.LoadGrammarAsync(GetCommandsGrammar());
            }
        }

        /// <summary>
        /// Event handler déclenché lorsque le moteur de reconnaissance vocale a reconnu une grammaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e) {
            string txt = e.Result.Text;
            float conf = e.Result.Confidence;
            if (conf < 0.65) return;
            this.Invoke(new MethodInvoker(() =>
            {
                // Vérifie si c'est une commande ou si c'est une réponse
                switch (txt) {
                    case "effacer":
                        EffacerChamps();
                        break;
                    case "stop":
                        this.Close();
                        break;
                    case "next":
                        btnAccept.PerformClick();
                        break;
                    default:
                        RemplirChamps(txt);
                        btnAccept.Focus();
                        break;
                }
            }));
        }

        /// <summary>
        /// Méthode qui remplit les textbox avec la réponse donnée sous forme de string
        /// </summary>
        /// <param name="reponse">String contenant la réponse sous forme X FOIS Y EGAL Z</param>
        private void RemplirChamps(string reponse) {
            // La réponse est sous forme "X FOIS Y EGAL Z"
            string[] splitReponse = reponse.Split(' ');

            string m1 = splitReponse[0];
            string m2 = splitReponse[2];
            string p = splitReponse[4];

            if (!tbxMult1.ReadOnly)
                tbxMult1.Text = m1;
            if (!tbxMult2.ReadOnly)
                tbxMult2.Text = m2;
            if (!tbxProduit.ReadOnly)
                tbxProduit.Text = p;
        }

        /// <summary>
        /// Méthode qui lance l'écoute de la reconnaissance vocale
        /// </summary>
        private void StartListening() {
            if (!lblListening.Visible && bReconnaissanceActivee) {
                sre.RecognizeAsync(RecognizeMode.Multiple);
                lblListening.Visible = true;
            }
        }

        /// <summary>
        /// Méthode qui arrête l'écoute de la reconnaissance vocale
        /// </summary>
        private void StopListening() {
            if (lblListening.Visible && bReconnaissanceActivee) {
                sre.RecognizeAsyncCancel();
                lblListening.Visible = false;
            }   
        }

        /// <summary>
        /// Méthode qui retourne la grammaire nécessaire à la reconnaissance vocale d'une réponse sous la forme suivante : nb FOIS nb EGAL nb
        /// </summary>
        /// <returns>Grammaire de la réponse</returns>
        private Grammar GetResponseGrammar() {
            // Définition des multiples maximums pour mieux cibler la reconnaissance
            int iMaxMult = 0;
            if (partieEnCours.Niveau == "6H") {
                iMaxMult = 9;
            }
            else if (partieEnCours.Niveau == "7H"){
                iMaxMult = 12;
            }

            // Création des listes de nombres
            string[] numbers = new string[iMaxMult+1];
            string[] bigNumbers = new string[(iMaxMult*iMaxMult)+1];

            for (int i = 0; i < numbers.Length; ++i) {
                numbers[i] = i.ToString();
            }

            for (int i = 0; i < bigNumbers.Length; ++i) {
                bigNumbers[i] = i.ToString();
            }

            Choices ch_Numbers = new Choices(numbers);
            Choices ch_BigNumbers = new Choices(bigNumbers);

            GrammarBuilder gb_result = new GrammarBuilder();
            gb_result.Append(ch_Numbers);
            gb_result.Append("fois");
            gb_result.Append(ch_Numbers);
            gb_result.Append("égal");
            gb_result.Append(ch_BigNumbers);

            Grammar g_result = new Grammar(gb_result);
            return g_result;
        }

        /// <summary>
        /// Méthode qui retourne la grammaire avec toutes les commandes vocales disponibles
        /// </summary>
        /// <returns>Retourne la grammaire des commandes</returns>
        private Grammar GetCommandsGrammar() {
            GrammarBuilder gb_result = new GrammarBuilder();
            string[] commands = new string[] {"next", "effacer", "stop"};
            Choices ch_commands = new Choices(commands);
            gb_result = ch_commands;

            Grammar g_result = new Grammar(gb_result);
            return g_result;
        }

        /// <summary>
        /// Méthode qui efface les entrées de l'utilisateur dans les champs possibles
        /// </summary>
        private void EffacerChamps() {
            if (!tbxMult1.ReadOnly)
                tbxMult1.Text = "";
            if (!tbxMult2.ReadOnly)
                tbxMult2.Text = "";
            if (!tbxProduit.ReadOnly)
                tbxProduit.Text = "";
        }

        /// <summary>
        /// Méthode déclenchée lors du changement d'état de la checkbox. Permet d'activer ou désactiver la reconnaissance vocale continue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxReconnaissance_CheckedChanged(object sender, EventArgs e) {
            if (cbxReconnaissance.Checked) {
                StartListening();
            }
            else {
                StopListening();
            }
        }
    }
}
