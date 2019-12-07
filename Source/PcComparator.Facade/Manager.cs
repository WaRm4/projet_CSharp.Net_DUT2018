using PcComparator.Class;
using PcComparator.Persistance;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PcComparator.Facade
{
    /// <summary>
    /// Façade l'application, fait l'intermédiaire entre la vue (PcComparator.WPF) et le métier(PcComparator.Class) en prenant les mêmes méthodes qu'une bibliothèque.
    /// </summary>
    public class Manager : INotifyPropertyChanged
    {
        /// <summary>
        /// Bibliothèque de l'application, qui contient la liste globale des composants.
        /// </summary>
        public Bibliotheque Bibli { get; private set; }

        /// <summary>
        /// Persistance utilisée pour charger et sauvegarder les données.
        /// </summary>
        private readonly IComposant pers;

        /// <summary>
        /// Liste globale des composants, raccourci de Bibli.ListComp.
        /// </summary>
        public ObservableCollection<Composant> ListeComp { get; private set; }

        /// <summary>
        /// Liste qui contient les élements dans le panier, raccourci de panier.listePanier.
        /// </summary>
        public ObservableCollection<Composant> ListePanier { get; private set; }

        /// <summary>
        /// Liste qui contient les élements dans le comparateur, raccourci de comparateur.listeComparateur.
        /// </summary>
        public ObservableCollection<Composant> ListeComparateur { get; private set; }

        /// <summary>
        /// Message d'introduction de l'application, raccourci de Bibli.Intro.
        /// </summary>
        public string Intro { get; private set; }


        /// <summary>
        /// Elément sélectionné dans la liste.
        /// </summary>
        private Composant selectedItem;

        public Composant SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Event servant à implémenter INotifyPropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Méthode servant à implémenter INotifyPropertyChanged.
        /// </summary>
        /// <param name="info"></param>
        private void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        /// <summary>
        /// Constructeur d'un Manager, charge les données et rempli les listes à sont initialisation.
        /// </summary>
        /// <param name="p"></param>
        public Manager(IComposant p)
            {
                pers = p;
                LireBibli();
                ListeComp = Bibli.ListeComposants;
                ListePanier = Bibli.p.ListePanier;
                ListeComparateur = Bibli.c.ListeComparateur;
                Intro = Bibli.Intro;
            }

        /// <summary>
        /// Méthode pour charger une Bibliothèque à partir d'une persistance.
        /// </summary>
        public void LireBibli()
        {
            Bibli = pers.LireBibli();
        }

        /// <summary>
        /// Méthode pour sauvegarder les données de la bibliothèque avec la persistance.
        /// </summary>
        public void Sauvegarder()
        {
            pers.Sauvegarder(Bibli);
        }

        /// <summary>
        /// Méthode pour ajouter un composant à la liste globale.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Booléen pour savoir si le composant à bien été ajouté.</returns>
        public bool AjoutComposant(Composant c)
        {
            return Bibli.Ajouter(c);
        }

        /// <summary>
        /// Méthode pour supprimer un composant de la liste globale.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Booléen pour savoir si le composant à bien été supprimé.</returns>
        public bool SupprimerComposant(Composant c)
        {
            return Bibli.Supprimer(c);
        }

        /// <summary>
        /// Méthode pour ajouter un composant au panier.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Booléen pour savoir si le composant à bien été ajouté.</returns>
        public bool AjoutPanier(Composant c)
        {
            return Bibli.p.AjouterPanier(c);
        }

        /// <summary>
        /// Méthode pour supprimer un composant du panier.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Booléen pour savoir si le composant à bien été supprimé.</returns>
        public bool SupprimerPanier(params Composant[] c)
        {
            return Bibli.p.SupprimerPanier(c);
        }

        /// <summary>
        /// Méthode pour ajouter un composant au Comparateur.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Booléen pour savoir si le composant à bien été ajouté.</returns>
        public bool AjoutComparateur(Composant c)
        {
            return Bibli.c.AjouterComparateur(c);
        }

        /// <summary>
        /// Méthode pour supprimer un composant du comparateur.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Booléen pour savoir si le composant à bien été supprimé.</returns>
        public bool SupprimerComparateur(Composant c)
        {
            return Bibli.c.SupprimerComparateur(c);
        }

        /// <summary>
        /// Méthode pour simuler une connexion.
        /// </summary>
        /// <param name="nom"></param>
        public void Connexion(string nom)
        {
            Bibli.Connexion(nom);
        }

        /// <summary>
        /// Méthode pour simuler une déconnexion.
        /// </summary>
        public void Deconnexion()
        {
            Bibli.Deconnexion();
        }
    }
}
