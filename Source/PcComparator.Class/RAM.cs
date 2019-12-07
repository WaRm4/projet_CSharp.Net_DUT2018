using System.ComponentModel.DataAnnotations;

namespace PcComparator.Class
{
    /// <summary>
    /// Mémoire vive (Ram), hérite de la classe Composant.
    /// </summary>
    public class RAM : Composant
    {
        /// <summary>
        /// Capacité d'une Ram.
        /// </summary>
        private int capacite;
        [Required]
        public int Capacite
        {
            get { return capacite; }
            set {
                capacite = value;
                base.OnPropertyChanged(nameof(Capacite));
                }
        }

        /// <summary>
        /// Nombre de barrettes d'une Ram.
        /// </summary>
        private int nbBarettes;
        [Required]
        public int NbBarettes
        {
            get { return nbBarettes; }
            set {
                nbBarettes = value;
                base.OnPropertyChanged(nameof(NbBarettes));
            }
        }

        /// <summary>
        /// Fréquence d'une Ram.
        /// </summary>
        private int frequence;
        [Required]
        public int Frequence
        {
            get { return frequence; }
            set {
                frequence = value;
                base.OnPropertyChanged(nameof(Frequence));
                }
        }

        /// <summary>
        /// Cas d'une Ram.
        /// </summary>
        private int cas;
        [Required]
        public int Cas
        {
            get { return cas; }
            set {
                cas = value;
                base.OnPropertyChanged(nameof(Cas));
            }
        }

        /// <summary>
        /// Constructeur d'une Ram.
        /// </summary>
        /// <param name="prix"></param>
        /// <param name="marque"></param>
        /// <param name="modele"></param>
        /// <param name="imagelien"></param>
        /// <param name="description"></param>
        /// <param name="capacite"></param>
        /// <param name="nbBarettes"></param>
        /// <param name="frequence"></param>
        /// <param name="cas"></param>
        public RAM(float prix, string marque, string modele, string imagelien, string description, int capacite, int nbBarettes, int frequence, int cas) : base(prix, marque, modele, imagelien, description)
        {
            
            Capacite = capacite;
            NbBarettes = nbBarettes;
            Frequence = frequence;
            Cas = cas;
        }

        /// <summary>
        /// Constrcuteur vide d'une Ram, sert pour la sérialisation.
        /// </summary>
        public RAM()
        { }

        /// <summary>
        /// Redéfinition du ToString d'une Ram, décrit une ram par le ToString d'un composant, plus sa capacité, son nombre de barrettes, sa fréquence et son Cas.
        /// </summary>
        /// <returns>string de la forme : ToString(Composant) Capacité go Nombre de barrette barrette(s) Fréquence Mhz Cas Cas</returns>
        public override string ToString()
        {
            return base.ToString()+Capacite+" go "+NbBarettes+" barette(s) "+Frequence+"Mhz "+" Cas "+Cas;
        }

        /// <summary>
        /// Redéfinition du Equals d'une Ram, avec en paramètre une Ram.
        /// </summary>
        /// <param name="r"></param>
        /// <returns>Booléen pour savoir si les deux ram sont égales.</returns>
        public bool Equals(RAM r)
        {
            if (this.Capacite == r.Capacite && this.NbBarettes == r.NbBarettes && this.Frequence == r.Frequence && this.Cas == r.Cas)
                return true;
            return false;
        }

        /// <summary>
        /// Redéfinitoin du Equals d'une Ram.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Booléen pour savoir si la ram et l'objet sont égaux.</returns>
        public override bool Equals(object obj)
        {
            if(base.Equals(obj))
            {
                return this.Equals(obj as RAM);
            }
            return false;
        }

        /// <summary>
        /// Redéfinition du Hashcode d'une ram, par un Id unique.
        /// </summary>
        /// <returns>Id unique du type Guid</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
