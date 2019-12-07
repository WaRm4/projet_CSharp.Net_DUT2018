using System.ComponentModel.DataAnnotations;

namespace PcComparator.Class
{
    /// <summary>
    /// Carte Graphique, hérite de la classe Composant.
    /// </summary>
    public class GPU : Composant
    {
        /// <summary>
        /// Mémoire d'une carte graphique.
        /// </summary>
        private float memoire;
        [Required]
        public float Memoire
        {
            get { return memoire; }
            set
            {
                memoire = value;
                OnPropertyChanged(nameof(Memoire));
            }
        }

        /// <summary>
        /// Constructeur d'une carte graphique.
        /// </summary>
        /// <param name="prix"></param>
        /// <param name="marque"></param>
        /// <param name="modele"></param>
        /// <param name="imagelien"></param>
        /// <param name="description"></param>
        /// <param name="memoire"></param>
        public GPU(float prix, string marque, string modele, string imagelien, string description, int memoire) : base(prix, marque, modele, imagelien, description)
        {
            Memoire = memoire;
        }

        /// <summary>
        /// Constructeur vide d'une carte graphique, sert a la sérialisation.
        /// </summary>
        public GPU()
        { }

        /// <summary>
        /// Redéfinition du ToString d'une carte graphique, décrit une carte graphique par le ToString d'un composant plus sa mémoire.
        /// </summary>
        /// <returns>string de la forme: ToString(Composant) Mémoire go</returns>
        public override string ToString()
        {
            return base.ToString() + Memoire+"go";
        }

        /// <summary>
        /// Redéfinition du Equals d'une carte graphique.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Booléen pour savoir si une carte graphique et un objet sont égaux.</returns>
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                return this.Equals(obj as GPU);
            }
            return false;
        }

        /// <summary>
        /// Redéfinition du Equals d'une carte graphique, avec en paramètre une carte graphique.
        /// </summary>
        /// <param name="g"></param>
        /// <returns>Booléen pour savoir si cartes grpahiques sont égales.</returns>
        public bool Equals(GPU g)
        {
            if (this.Memoire == g.Memoire)
                return true;
            return false;
        }

        /// <summary>
        /// Redéfintion du Hashcode d'une carte graphique par un Id unique.
        /// </summary>
        /// <returns>Id unique du type Guid</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
