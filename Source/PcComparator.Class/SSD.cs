using System.ComponentModel.DataAnnotations;

namespace PcComparator.Class
{
    /// <summary>
    /// Disque dur Ssd, hérite de DisqueDur.
    /// </summary>
    public class SSD : DisqueDur
    {
        /// <summary>
        /// Connectique d'un Ssd.
        /// </summary>
        private string connectique;
        [Required]
        public string Connectique
        {
            get { return connectique; }
            set
            {
                connectique = value;
                OnPropertyChanged(nameof(Connectique));
            }
        }

        /// <summary>
        /// Constructeur d'un Ssd.
        /// </summary>
        /// <param name="prix"></param>
        /// <param name="marque"></param>
        /// <param name="modele"></param>
        /// <param name="imagelien"></param>
        /// <param name="description"></param>
        /// <param name="capacite"></param>
        /// <param name="vitesseLect"></param>
        /// <param name="vitesseEcr"></param>
        /// <param name="connectique"></param>
        public SSD(float prix, string marque, string modele, string imagelien, string description, int capacite, int vitesseLect, int vitesseEcr, string connectique) : base(prix, marque, modele, imagelien, description, capacite, vitesseLect, vitesseEcr)
        {
            Connectique = connectique;
        }

        /// <summary>
        /// Constructeur vide d'un Ssd, sert à la sérialisation.
        /// </summary>
        public SSD()
        { }

        /// <summary>
        /// Redéfinition du ToString d'un Ssd, décrit un Ssd par le ToString d'un Disque dur plus sa connectique. 
        /// </summary>
        /// <returns>string de la forme : ToString(DisqueDur) Connectique</returns>
        public override string ToString()
        {
            return base.ToString() + Connectique;
        }

        /// <summary>
        /// Redéfinition du Equals d'un Ssd.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Booléen pour savoir si un Ssd et un objet sont égaux.</returns>
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                return this.Equals(obj as SSD);
            }
            return false;
        }

        /// <summary>
        /// Redéfinition du Equals d'un Ssd, avec en paramètre un Ssd.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Booléen pour savoir si deux Ssd sont égaux.</returns>
        public bool Equals(SSD s)
        {
            if (this.Connectique == s.Connectique)
                return true;
            return false;
        }

        /// <summary>
        /// Redéfinition du Hashcode d'un Ssd, par un Id unique.
        /// </summary>
        /// <returns>Id unique du type Guid.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
