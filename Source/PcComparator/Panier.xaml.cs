using MahApps.Metro.Controls;
using PcComparator.Class;
using PcComparator.Facade;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PcComparator
{
    /// <summary>
    /// Logique d'interaction pour Panier.xaml
    /// </summary>
    public partial class Panier : MetroWindow, INotifyPropertyChanged
    {
        public Manager M { get; private set; }

        private Composant selectedItem;

        public Composant SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        private Badged BadgePanier { get; set; }

        private float prixtot;

        public float Prixtot
        {
            get { return prixtot; }
            set {
                prixtot = value;
                OnPropertyChanged(nameof(Prixtot));
                }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public Panier(Manager m, Badged badge)
        {
            InitializeComponent();
            DataContext = this;
            this.M = m;
            BadgePanier = badge;

            foreach (Composant c in M.ListePanier)
            {
                Prixtot = Prixtot + c.Prix;
            }
            if (M.ListePanier.Count() == 0)
            {
                vide.Visibility = Visibility.Visible;
                vider.IsEnabled = false;
            }
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            Composant[] composants = new Composant[M.ListePanier.Count()];
            int i = 0;
            foreach(Composant c in listViewPanier.SelectedItems)
            {
                composants[i] = c;
                i++;
                Prixtot = Prixtot - c.Prix;
            }
            
            M.SupprimerPanier((Composant[])composants);
            supprimer.IsEnabled = false;
            BadgePanier.Badge = M.ListePanier.Count();
            if (M.ListePanier.Count() == 0)
            {
                vide.Visibility = Visibility.Visible;
                vider.IsEnabled = false;
            }
        }

        private void Vider_Click(object sender, RoutedEventArgs e)
        {
            M.ListePanier.Clear();
            Prixtot = 0;
            vide.Visibility = Visibility.Visible;
            vider.IsEnabled = false;
            supprimer.IsEnabled = false;
            BadgePanier.Badge = M.ListePanier.Count();
        }

        private void ListViewPanier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewPanier.SelectedItem == null)
                supprimer.IsEnabled = false;
            supprimer.IsEnabled = true;
        }
    }
}
