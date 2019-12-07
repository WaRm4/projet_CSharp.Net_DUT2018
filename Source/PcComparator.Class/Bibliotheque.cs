using System.Collections.ObjectModel;

namespace PcComparator.Class
{
    /// <summary>
    /// Bibliothèque de l'application, contient le panier, le comparateur, et la liste globale de composants.
    /// Elle stocke aussi la phrase d'intro de l'application et le nom de l'utilisateur. 
    /// </summary>
    public class Bibliotheque
    {
        /// <summary>
        /// message de la page d'accueil de l'application.
        /// </summary>
        public string Intro { get; private set; } = "Vous voici sur l'application PcComparator." + '\n' + "Appuyez sur un des boutons pour commencer";

        /// <summary>
        /// Liste globale de tous les composants.
        /// </summary>
        public ObservableCollection<Composant> ListeComposants { get; private set; }

        /// <summary>
        /// Panier de l'application, il contient une liste de composants qui ont été ajoutés au panier.
        /// </summary>
        public Panier p = new Panier();

        /// <summary>
        /// Comparateur de l'application, il contient une liste de composants qui ont été ajoutés au comparateur.
        /// </summary>
        public Comparateur c = new Comparateur();

        /// <summary>
        /// Nom de la personne "connecté"
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Constructeur d'une bibliothèque, qui contient une liste de tous les composants de l'application.
        /// Initialise un panier et un comparateur vides.
        /// </summary>
        /// <param name="listeComposants"></param>
        public Bibliotheque(ObservableCollection<Composant> listeComposants)
        {
            ListeComposants = listeComposants;
            p.ListePanier = new ObservableCollection<Composant>();
            c.ListeComparateur = new ObservableCollection<Composant>();
        }

        /// <summary>
        /// Méthode pour ajouter un composant à la liste globale.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>booléen pour savoir si l'ajout à fonctionné.</returns>
        public bool Ajouter(Composant c)
        {
            if (ListeComposants.Contains(c))
                return false;
            ListeComposants.Add(c);
            return true;
        }

        /// <summary>
        /// Méthode pour supprimer un composant de la liste globale.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>booléen pour savoir si la suppression à fonctionnée.</returns>
        public bool Supprimer(Composant c)
        {
            if (!ListeComposants.Contains(c))
                return false;
            ListeComposants.Remove(c);
            return true;
        }

        /// <summary>
        /// Simple méthode pour simuler une connexion.
        /// </summary>
        /// <param name="nom"></param>
        public void Connexion(string nom)
        {
            Name = nom;
        }

        /// <summary>
        /// Simple méthode pour simuler une déconnexion.
        /// </summary>
        public void Deconnexion()
        {
            Name = null;
        }
    }
}
