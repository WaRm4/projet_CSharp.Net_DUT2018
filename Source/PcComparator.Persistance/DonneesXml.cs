using PcComparator.Class;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace PcComparator.Persistance
{
    /// <summary>
    /// Persistance qui charge et sauvegarde les données dans le même fichier Xml.
    /// </summary>
    public class DonneesXml : IComposant
    {
        /// <summary>
        /// Serializer.
        /// </summary>
        XmlSerializer serializerListComposant = new XmlSerializer(typeof(ObservableCollection<Composant>));

        /// <summary>
        /// Méthode pour Lire et remplir une bibliothèque à partir d'un fichier Xml.
        /// </summary>
        /// <returns></returns>
        public Bibliotheque LireBibli()
        {
            ObservableCollection<Composant> deserialized;
            using (Stream stream = File.OpenRead(/*Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "/PcComparatorData/*/ "donnees/List_Composants_1.xml"))
            {
                deserialized = serializerListComposant.Deserialize(stream) as ObservableCollection<Composant>;
            }
            return new Bibliotheque(deserialized);
        }

        /// <summary>
        /// Méthode pour sauvegarder la liste de composants de la bibliothèque dans le fichier Xml.
        /// </summary>
        /// <param name="bibli"></param>
        public void Sauvegarder(Bibliotheque bibli)
        {
            using (Stream stream = File.Create(/*Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "/PcComparatorData/*/ "donnees/List_Composants_1.xml"))
            {
                serializerListComposant.Serialize(stream, bibli.ListeComposants);
            }
        }
    }
}

//Ce qui est commenté servait à l'accès des fichiers dans ProgramData cependant si le setup n'était pas lancé une première fois cela ne fonctionnait pas. De plus il y avait un problème de 
// droits lors de l'écriture sur le fichier.