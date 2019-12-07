using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace PcComparator.Class
{
    /// <summary>
    /// Composant, classe mère de n'importe quel composant.
    /// Cette classe est abstraite car on ne veut pas pouvoir instancioer un composant : un composant est obligé d'avoir un type, comme une RAM par exemple.
    /// </summary>
    [XmlInclude(typeof(RAM))]
    [XmlInclude(typeof(CM))]
    [XmlInclude(typeof(CPU))]
    [XmlInclude(typeof(GPU))]
    [XmlInclude(typeof(HDD))]
    [XmlInclude(typeof(SSD))]
    [XmlInclude(typeof(DisqueDur))]
    public abstract class Composant : INotifyPropertyChanged, IDataErrorInfo
    {
        /// <summary>
        /// Identifiant unique pour chaque composant, sert pour redéfinir le hashcode car il y avait un problème avec les hashcodes quand on modifiait un composant.
        /// </summary>
        protected readonly Guid Id = Guid.NewGuid();

        /// <summary>
        /// Prix d'un composant.
        /// </summary>
        private float prix;
        [XmlAttribute(AttributeName = "prix")]
        [Required]
        public float Prix
        {
            get { return prix; }
            set {
                prix = value;
                OnPropertyChanged(nameof(Prix));
            }
        }

        /// <summary>
        /// Marque d'un composant.
        /// </summary>
        private string marque { get; set; }
        [XmlAttribute(AttributeName = "marque")]
        [Required]
        public string Marque
        {
            get { return marque; }
            set
            {
                marque = value;
                OnPropertyChanged(nameof(Marque));
            }
        }

        /// <summary>
        /// Modèle d'un composant.
        /// </summary>
        private string modele { get; set; }
        [XmlAttribute(AttributeName = "modele")]
        [Required]
        public string Modele
        {
            get { return modele; }
            set
            {
                modele = value;
                OnPropertyChanged(nameof(Modele));
            }
        }

        /// <summary>
        /// Lien de l'image d'un composant.
        /// </summary>
        private string imageLien { get; set; }
        [XmlAttribute(AttributeName = "lien_Image")]
        public string ImageLien
        {
            get { return imageLien; }
            set
            {
                imageLien = value;
                OnPropertyChanged(nameof(ImageLien));
            }
        }

        /// <summary>
        /// Desciption d'un composant.
        /// </summary>
        private string description;
        [XmlAttribute(AttributeName = "description")]
        [Required]
        public string Description
        {
            get { return description; }
            set {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        /// <summary>
        /// Type du composant (Ram,Cpu,Gpu,Hdd,Ssd,ou Cm)
        /// </summary>
        [XmlAttribute(AttributeName = "Type")]
        public string TypeCompo { get; set; }

        /// <summary>
        /// Event pour implémenter INotifyPropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Méthode pour implémenter INotifyPropertyChanged.
        /// </summary>
        /// <param name="info"></param>
        public void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        /// <summary>
        /// Constructeur d'un composant, défini une image par défaut si le lien ne marche pas ou est null.
        /// Défini aussi le type de composant.
        /// </summary>
        /// <param name="prix"></param>
        /// <param name="marque"></param>
        /// <param name="modele"></param>
        /// <param name="imageLien"></param>
        /// <param name="description"></param>
        public Composant(float prix, string marque, string modele, string imageLien, string description)
        {
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\images\" + imageLien;
            Prix = prix;
            Marque = marque;
            Modele = modele;
            Description = description;
            TypeCompo = this.GetType().ToString();
            TypeCompo = TypeCompo.Substring(19, TypeCompo.Length - 19);
            if (File.Exists(path))
                ImageLien = @"images\" + imageLien;
            else
                ImageLien = @"images\Defaut.jpg";
        }

        /// <summary>
        /// Constructeur d'un composant vide, pour la sérialisation.
        /// </summary>
        public Composant()
        { }

        /// <summary>
        /// Redéfinition du ToString d'un composant, decrit un composant par sa marque, son modele et son prix
        /// </summary>
        /// <returns>string de type : Marque Modele Prix €</returns>
        public override string ToString()
        {
            return Marque+" "+Modele+" "+Prix+"€ ";
        }

        /// <summary>
        /// Méthode pour implémenter IDataErrorInfo.
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                var validationResults = new List<ValidationResult>();

                if (Validator.TryValidateProperty(
                    GetType().GetProperty(columnName).GetValue(this)
                    , new ValidationContext(this)
                    {
                        MemberName = columnName
                    }
                    , validationResults))
                    return null;

                return validationResults.First().ErrorMessage;
            }
        }

        /// <summary>
        /// Sert à l'implémentation de IDataErrorInfo.
        /// </summary>
        public string Error { get; }

        //public override int GetHashCode()
        //{
        //    return Id.GetHashCode();
        //}

        /// <summary>
        /// Redéfinition du hashcode d'un composant, avec un Guid car un hashcode fait sois-même ne fonctionnait pas avec la modification d'un composant.
        /// </summary>
        /// <returns>Identifiant unique de type Guid.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Redéfinition du Equals d'un composant, avec en paramètre un composant.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>booléen pour savoir si les deux composants sont égaux.</returns>
        public bool Equals(Composant c)
        {
            if (this.Marque == c.Marque && this.Modele==c.Modele && this.Prix==c.Prix)
                return true;
            return false;
        }

        /// <summary>
        /// Redéfinition du Equals d'un composant.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>booléen pour savoir si le composant et l'objet sont égaux.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this == obj)
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            return this.Equals(obj as Composant);
        }
    }
}
