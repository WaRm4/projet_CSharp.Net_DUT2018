using PcComparator.Class;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace PcComparator.Persistance
{
    /// <summary>
    /// Persistance qui charge les données de base enregistrées dans un fichier Xml, et les sauvegarde dans un autre fichier Xml, qui sert dans DonneeXml.
    /// </summary>
    public class DonneeComposant : IComposant
    {
        /// <summary>
        /// Serializer.
        /// </summary>
        private XmlSerializer serializerListComposant = new XmlSerializer(typeof(ObservableCollection<Composant>));
        
        /// <summary>
        /// Méthode pour lire et remplir une Bibliothèque à partir d'un fichier Xml.
        /// </summary>
        /// <returns>Bibliothèque.</returns>
        public Bibliotheque LireBibli()
        {
            ObservableCollection<Composant> deserialized;
            using (Stream stream = File.OpenRead(@"donnees\List_ComposantsDeBase.xml"))
            {
                deserialized = serializerListComposant.Deserialize(stream) as ObservableCollection<Composant>;
            }
            return new Bibliotheque(deserialized);
        }

        /// <summary>
        /// Méthode pour sauvegarder la liste de composants de la Bibliothèque dans un fichier Xml.
        /// </summary>
        /// <param name="bibli"></param>
        public void Sauvegarder(Bibliotheque bibli)
        {
            using (Stream stream = File.Create(@"donnees/List_Composants_1.xml"))
            {
                serializerListComposant.Serialize(stream, bibli.ListeComposants);
            }
        }
    }
}
