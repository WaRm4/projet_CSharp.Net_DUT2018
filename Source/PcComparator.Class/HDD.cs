using System.ComponentModel.DataAnnotations;

namespace PcComparator.Class
{
    /// <summary>
    /// Disque dur HDD, hérite de la classe DisqueDur.
    /// </summary>
    public class HDD : DisqueDur
    {
        /// <summary>
        /// Taille d'un Hdd.
        /// </summary>
        private float taille;
        [Required]
        public float Taille
        {
            get { return taille; }
            set
            {
                taille = value;
                OnPropertyChanged(nameof(Taille));
            }
        }

        /// <summary>
        /// Constructeur d'un Hdd.
        /// </summary>
        /// <param name="prix"></param>
        /// <param name="marque"></param>
        /// <param name="modele"></param>
        /// <param name="imagelien"></param>
        /// <param name="description"></param>
        /// <param name="capacite"></param>
        /// <param name="vitesseLect"></param>
        /// <param name="vitesseEcr"></param>
        /// <param name="taille"></param>
        public HDD(float prix, string marque, string modele, string imagelien, string description, int capacite, int vitesseLect, int vitesseEcr, float taille) : base(prix, marque, modele, imagelien, description, capacite, vitesseLect, vitesseEcr)
        {
            Taille = taille;
        }

        /// <summary>
        /// Constructeur vide d'un Hdd, sert pour la sérialisation.
        /// </summary>
        public HDD()
        { }

        /// <summary>
        /// Redéfinition du ToString d'un Hdd, décrit un Hdd par le ToString d'un disque dur, plus sa Taille.
        /// </summary>
        /// <returns>string de la forme : ToString(DisqueDur) Taille "</returns>
        public override string ToString()
        {
            return base.ToString() + Taille + "\"";
        }

        /// <summary>
        /// Redéfinition du Equals d'un hdd.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Booléen pour savoir si le hdd et l'objet sont égaux.</returns>
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                return this.Equals(obj as HDD);
            }
            return false;
        }

        /// <summary>
        /// Redéfinition du Equals d'un hdd, avec en paramètre un hdd.
        /// </summary>
        /// <param name="h"></param>
        /// <returns>Booléen pour savoir si les deux hdd sont égaux.</returns>
        public bool Equals(HDD h)
        {
            if (this.Taille == h.Taille)
                return true;
            return false;
        }

        /// <summary>
        /// Redéfinition du Hashcode d'un hdd par un Id unique.
        /// </summary>
        /// <returns>Id unique du type Guid</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
