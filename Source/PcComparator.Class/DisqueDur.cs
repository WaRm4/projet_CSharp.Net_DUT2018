using System.ComponentModel.DataAnnotations;

namespace PcComparator.Class
{
    /// <summary>
    /// Disque dur, hérite de la classe Composant.
    /// </summary>
    public abstract class DisqueDur : Composant 
    {
        /// <summary>
        /// Capacité d'un disque dur.
        /// </summary>
        private int capacite;
        [Required]
        public int Capacite
        {
            get { return capacite; }
            set
            {
                capacite = value;
                OnPropertyChanged(nameof(Capacite));
            }
        }

        /// <summary>
        /// Vitesse de lecture d'un dique dur.
        /// </summary>
        private int vitesseLect;
        [Required]
        public int VitesseLect
        {
            get { return vitesseLect; }
            set
            {
                vitesseLect = value;
                OnPropertyChanged(nameof(VitesseLect));
            }
        }

        /// <summary>
        /// Vitesse d'écriture d'un disque dur.
        /// </summary>
        private int vitesseEcr;
        [Required]
        public int VitesseEcr
        {
            get { return vitesseEcr; }
            set
            {
                vitesseEcr = value;
                OnPropertyChanged(nameof(VitesseEcr));
            }
        }

        /// <summary>
        /// Constructeur d'un Disque dur.
        /// </summary>
        /// <param name="prix"></param>
        /// <param name="marque"></param>
        /// <param name="modele"></param>
        /// <param name="imagelien"></param>
        /// <param name="description"></param>
        /// <param name="capacite"></param>
        /// <param name="vitesseLect"></param>
        /// <param name="vitesseEcr"></param>
        public DisqueDur(float prix, string marque, string modele, string imagelien, string description, int capacite, int vitesseLect, int vitesseEcr) : base(prix, marque, modele, imagelien, description)
        {
            Capacite = capacite;
            VitesseLect = vitesseLect;
            VitesseEcr = vitesseEcr;
        }

        /// <summary>
        /// Constructeur vide d'un disque dur, sert pour la sérialisation.
        /// </summary>
        public DisqueDur()
        { }

        /// <summary>
        /// Redéfinition du ToString d'un disque dur, décrit un disque dur par le ToString d'un composant plus sa capcité, sa vitesse de lecture et sa vitesse d'écriture.
        /// </summary>
        /// <returns>string de la forme : ToString(composant) Capacité go vitesse de lecture Mo/s vitesse d'écriture Mo/s</returns>
        public override string ToString()
        {
            return base.ToString() + Capacite + "go " + VitesseLect + "Mo/s " + VitesseEcr + "Mo/s ";
        }

        /// <summary>
        /// Redéfinition du Equals d'un disque dur.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Booléen pour savoir si le disque dur et l'objet sont égaux.</returns>
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                return this.Equals(obj as DisqueDur);
            }
            return false;
        }

        /// <summary>
        /// Redéfinition du Equals d'un disque dur, avec en paramètre un disque dur.
        /// </summary>
        /// <param name="d"></param>
        /// <returns>Booléen pour savoir les deux disques dur sont égaux.</returns>
        public bool Equals(DisqueDur d)
        {
            if (this.Capacite == d.Capacite && this.VitesseEcr == d.VitesseEcr && this.VitesseLect == d.VitesseLect)
                return true;
            return false;
        }

        /// <summary>
        /// Redéfinition du Hashcode d'un disque dur par un Id unique.
        /// </summary>
        /// <returns>Id unique du type Guid</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
