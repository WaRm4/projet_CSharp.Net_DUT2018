using System.ComponentModel.DataAnnotations;

namespace PcComparator.Class
{
    /// <summary>
    /// Carte mère, hérite de la classe Composant.
    /// </summary>
    public class CM : Composant
    {
        /// <summary>
        /// Socket d'une carte mère.
        /// </summary>
        private string socket;
        [Required]
        public string Socket
        {
            get { return socket; }
            set
            {
                socket = value;
                OnPropertyChanged(nameof(Socket));
            }
        }

        /// <summary>
        /// Chipset d'une carte mère.
        /// </summary>
        private string chipset;
        [Required]
        public string Chipset
        {
            get { return chipset; }
            set
            {
                chipset = value;
                OnPropertyChanged(nameof(Chipset));
            }
        }

        /// <summary>
        /// Format d'une carte mère.
        /// </summary>
        private string format;
        [Required]
        public string Format
        {
            get { return format; }
            set
            {
                format = value;
                OnPropertyChanged(nameof(Format));
            }
        }

        /// <summary>
        /// Fréquence d'une carte mère.
        /// </summary>
        private string frequence;
        [Required]
        public string Frequence
        {
            get { return frequence; }
            set
            {
                frequence = value;
                OnPropertyChanged(nameof(Frequence));
            }
        }

        /// <summary>
        /// Constructeur d'une carte mère.
        /// </summary>
        /// <param name="prix"></param>
        /// <param name="marque"></param>
        /// <param name="modele"></param>
        /// <param name="imagelien"></param>
        /// <param name="description"></param>
        /// <param name="socket"></param>
        /// <param name="format"></param>
        /// <param name="chipset"></param>
        /// <param name="frequence"></param>
        public CM(float prix, string marque, string modele, string imagelien, string description, string socket, string format, string chipset, string frequence) : base(prix, marque, modele, imagelien, description)
        {
            Socket = socket;
            Format = format;
            Chipset = chipset;
            Frequence = frequence;
        }

        /// <summary>
        /// Constructeur vide d'une carte mère (pour la sérialisation)
        /// </summary>
        public CM()
        { }

        /// <summary>
        /// Redéfinition du ToString d'une carte mère. Décrit une carte mère par le Tostring d'un composant plus son socket, format, chipset et sa fréquence.
        /// </summary>
        /// <returns>string de type : ToString(Composant) Socket Format Chipset Fréquence</returns>
        public override string ToString()
        {
            return base.ToString() + Socket + " " + Format + " " + Chipset + " " + Frequence ;
        }

        /// <summary>
        /// Equals version objet d'une carte mère.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>booléen pour savoir si la carte mère et l'objet sont égaux.</returns>
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                return this.Equals(obj as CM);
            }
            return false;
        }

        /// <summary>
        /// Equals version CM d'une carte mère.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>booléen pour savoir si les deux cartes mères sont égales.</returns>
        public bool Equals(CM c)
        {
            if (this.Chipset == c.Chipset && this.Socket == c.Socket && this.Format == c.Format && this.Frequence == c.Frequence)
                return true;
            return false;
        }

        /// <summary>
        /// Redéfinition du hashcode d'une carte mère par un Id unique.
        /// </summary>
        /// <returns>Id unique du type Guid</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
