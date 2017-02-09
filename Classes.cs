using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepetiteurLivrets {

    /// <summary>
    /// Classe qui permet de structurer une question de livrets sous la forme de 2 multiples, un produit, et un "trou" qui désigne l'emplacement de la lacune
    /// </summary>
    public class Question {
        // Attributs
        private int _mult1;
        private int _mult2;
        private int _produit;
        private int _trou;

        // Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Question() {
        }

        // Accesseurs
        public int Mult1 {
            get { return this._mult1; }
            set { this._mult1 = value; }
        }
        public int Mult2 {
            get { return this._mult2; }
            set { this._mult2 = value; }
        }
        public int Produit {
            get { return this._produit; }
            set { this._produit = value; }
        }
        public int Trou {
            get { return this._trou; }
            set { this._trou = value; }
        }
    }

    /// <summary>
    /// Classe qui permet de structurer la réponse donnée par l'utilisateur.
    /// </summary>
    public class Reponse {
        // Attributs
        private int _mult1;
        private int _mult2;
        private int _produit;

        // Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Reponse() {
        }

        // Accesseurs
        public int Mult1 {
            get { return this._mult1; }
            set { this._mult1 = value; }
        }
        public int Mult2 {
            get { return this._mult2; }
            set { this._mult2 = value; }
        }
        public int Produit {
            get { return this._produit; }
            set { this._produit = value; }
        }
    }

    /// <summary>
    /// Classe qui contient les paramètres de la partie
    /// </summary>
    public class Partie {
        // Attributs
        private int _nbQuestion;
        private string _difficulte;
        private string _niveau;
        private string _joueur;

        // Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Partie(){
        }

        // Accesseurs
        public int NbQuestion {
            get { return this._nbQuestion; }
            set { this._nbQuestion = value; }
        }

        public string Difficulte {
            get { return this._difficulte; }
            set { this._difficulte = value; }
        }

        public string Niveau {
            get { return this._niveau; }
            set { this._niveau = value; }
        }

        public string Joueur {
            get { return this._joueur; }
            set { this._joueur = value; }
        }
    }
}
