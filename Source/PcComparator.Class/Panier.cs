using System.Collections.ObjectModel;

namespace PcComparator.Class
{
    /// <summary>
    /// Panier de l'application, contient une liste de composants ajoutés au panier.
    /// </summary>
    public class Panier
    {
        /// <summary>
        /// Liste des composants ajoutés au panier.
        /// </summary>
        public ObservableCollection<Composant> ListePanier { get; set; }

        /// <summary>
        /// Méthode pour ajouter un composant au panier.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Booléen pour savoir si le composant à bien été ajouté ou non.</returns>
        public bool AjouterPanier(Composant c)
        {
            if (ListePanier.Contains(c))
                return false;
            ListePanier.Add(c);
            return true;
        }

        /// <summary>
        /// Méthode pour supprimer un ou plusieurs composants du panier, grâce à params.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Booléen pour savoir si le ou les composants ont bien été ajoutés.</returns>
        public bool SupprimerPanier(params Composant[] c)
        {
            foreach (Composant comp in c)
            {
                if (!ListePanier.Contains(comp))
                    return false;
                ListePanier.Remove(comp);
            }
            return true;
        }
    }
}
