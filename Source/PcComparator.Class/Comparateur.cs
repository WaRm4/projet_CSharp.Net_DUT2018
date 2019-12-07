using System.Collections.ObjectModel;

namespace PcComparator.Class
{
    /// <summary>
    /// Comparateur de l'application, contient la liste de composants ajoutés à ce comparateur.
    /// </summary>
    public class Comparateur
    {
        /// <summary>
        /// Liste qui contient les composants présents dans le comparateur.
        /// </summary>
        public ObservableCollection<Composant> ListeComparateur { get; set; }

        /// <summary>
        /// Méthode pour ajouter un composant au comparateur.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>booléen pour savoir si l'ajout à fonctionné.</returns>
        public bool AjouterComparateur(Composant c)
        {
            if (ListeComparateur.Contains(c))
                return false;
            ListeComparateur.Add(c);
            return true;
        }

        /// <summary>
        /// Méthode pour supprimer un composant du comparateur.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>booléen pour savoir si la suppression à fonctionnée.</returns>
        public bool SupprimerComparateur(Composant c)
        {
            if (!ListeComparateur.Contains(c))
                return false;
            ListeComparateur.Remove(c);
            return true;
        }
    }
}
