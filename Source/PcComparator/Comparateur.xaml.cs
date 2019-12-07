using MahApps.Metro.Controls;
using PcComparator.Class;
using PcComparator.Facade;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace PcComparator
{
    /// <summary>
    /// Logique d'interaction pour Comparateur.xaml
    /// </summary>
    public partial class Comparateur : MetroWindow, INotifyPropertyChanged
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

        private Badged BadgeComp { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public Comparateur(Manager m, Badged badge)
        {
            InitializeComponent();
            DataContext = this;
            this.M = m;
            BadgeComp = badge;

            if (M.ListeComparateur.Count() == 0)
            {
                vide.Visibility = Visibility.Visible;
                vider.IsEnabled = false;
            }
            else
            if (M.ListeComparateur[0].GetType() == typeof(RAM))
                ContentControl1.Content = new RAM();
            else if(M.ListeComparateur[0].GetType() == typeof(CPU))
                ContentControl1.Content = new CPU();
            else if (M.ListeComparateur[0].GetType() == typeof(GPU))
                ContentControl1.Content = new GPU();
            else if (M.ListeComparateur[0].GetType() == typeof(HDD))
                ContentControl1.Content = new HDD();
            else if (M.ListeComparateur[0].GetType() == typeof(SSD))
                ContentControl1.Content = new SSD();
            else if (M.ListeComparateur[0].GetType() == typeof(CM))
                ContentControl1.Content = new CM();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            M.SupprimerComparateur((Composant)ListViewComp.SelectedItem);
            supprimer.IsEnabled = false;
            if (M.ListeComparateur.Count() == 0)
            {
                vide.Visibility = Visibility.Visible;
                vider.IsEnabled = false;
            }
            BadgeComp.Badge = M.ListeComparateur.Count();
        }

        private void Vider_Click(object sender, RoutedEventArgs e)
        {
            M.ListeComparateur.Clear();
            vide.Visibility = Visibility.Visible;
            supprimer.IsEnabled = false;
            vider.IsEnabled = false;
            BadgeComp.Badge = M.ListeComparateur.Count();
        }

        private void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListViewComp.SelectedItem == null)
                supprimer.IsEnabled = false;
            supprimer.IsEnabled = true;
        }

        private void Root_Closed(object sender, System.EventArgs e)
        {

        }
    }
}
