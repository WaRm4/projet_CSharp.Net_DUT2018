using System.ComponentModel.DataAnnotations;

namespace PcComparator.Class
{
    /// <summary>
    /// Processeur, hérite de la classe Composant.
    /// </summary>
    public class CPU : Composant
    {
        /// <summary>
        /// Fréquence d'un processeur.
        /// </summary>
        private float frequence;
        [Required]
        public float Frequence
        {
            get { return frequence; }
            set
            {
                frequence = value;
                OnPropertyChanged(nameof(Frequence));
            }
        }

        /// <summary>
        /// Nombre de coeurs d'un processeur.
        /// </summary>
        private int nbCoeur;
        [Required]
        public int NbCoeur
        {
            get { return nbCoeur; }
            set
            {
                nbCoeur = value;
                OnPropertyChanged(nameof(NbCoeur));
            }
        }

        /// <summary>
        /// Nombre de threads d'un processeur.
        /// </summary>
        private int nbThread;
        [Required]
        public int NbThread
        {
            get { return nbThread; }
            set
            {
                nbThread = value;
                OnPropertyChanged(nameof(NbThread));
            }
        }

        /// <summary>
        /// Constructeur d'un processeur.
        /// </summary>
        /// <param name="prix"></param>
        /// <param name="marque"></param>
        /// <param name="modele"></param>
        /// <param name="imagelien"></param>
        /// <param name="description"></param>
        /// <param name="frequence"></param>
        /// <param name="nbCoeur"></param>
        /// <param name="nbThread"></param>
        public CPU(float prix, string marque, string modele, string imagelien, string description, float frequence, int nbCoeur, int nbThread) : base(prix, marque, modele, imagelien, description)
        {
            Frequence = frequence;
            NbCoeur = nbCoeur;
            NbThread = nbThread;
        }

        /// <summary>
        /// Constructeur vide d'un processeur, sert pour la sérialisation.
        /// </summary>
        public CPU()
        { }

        /// <summary>
        /// Redéfinition du ToString d'un processeur, Décrit un processeur par le ToString d'un composant plus sa fréquence, son nombre de coeur et son nombre de threads.
        /// </summary>
        /// <returns>string de la forme : ToString(Composant) Fréquence Nombre de coeurs Nombre de threads</returns>
        public override string ToString()
        {
            return base.ToString()+Frequence+"GHz "+NbCoeur+" Cores "+NbThread+" Threads";
        }

        /// <summary>
        /// Redéfinition du Equals d'un processeur.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Booléen pour savoir si le processeur et l'objet sont égaux.</returns>
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                return this.Equals(obj as CPU);
            }
            return false;
        }

        /// <summary>
        /// Redéfinition du Equals d'un processeur, avec en paramètre un processeur.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Booléen pour savoir si les processeurs sont égaux.</returns>
        public bool Equals(CPU c)
        {
            if (this.Frequence == c.Frequence && this.NbCoeur == c.NbCoeur && this.NbThread == c.NbThread)
                return true;
            return false;
        }

        /// <summary>
        /// Redéfinition du Hashcode d'un processeurpar un Id unique.
        /// </summary>
        /// <returns>Id unique du type Guid</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
