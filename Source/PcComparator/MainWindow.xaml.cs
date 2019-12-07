using System.Windows;
using System.Windows.Controls;
using PcComparator.Class;
using PcComparator.Persistance;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Diagnostics;
using PcComparator.Facade;
using System.IO;
using System;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Linq;

namespace PcComparator
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {
        public Manager M { get; private set; }

        private int I { get; set; } = 0;
        private int J { get; set; } = 0;
        
        private ListBox ListeAffichee { get; set; }

        private Visibility affichageVisibilite;

        public Visibility AffichageVisibilite
        {
            get { return affichageVisibilite; }
            set
            {
                affichageVisibilite = value;
                OnPropertyChanged("AffichageVisibilite");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Random ran = new Random();
            int chiffre = ran.Next(0, 6);
            ChoixBarre(chiffre);
            LoadPB();

            DataContext = this;
            M = new Manager(new DonneesXml());
            //m = new Manager(new DonneeComposant());

            badgeComp.Badge = M.ListeComp.Count();
            badgePanier.Badge = M.ListePanier.Count();
            
            TextDebut.Text = M.Intro;
        }

        private void LoadPB()
        {
            Duration dur = new Duration(TimeSpan.FromSeconds(2));
            DoubleAnimation db = new DoubleAnimation(100, dur);
            pb1.BeginAnimation(ProgressBar.ValueProperty, db);
        }

        private void Pb1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pb1.Value == pb1.Maximum)
            {
                pb1.Value = pb1.Maximum;
                entrer.Visibility = Visibility.Visible;
                Appli.Visibility = Visibility.Visible;
                entrer.IsEnabled = true;
                labelEntrer.Visibility = Visibility.Visible;
            }
        }

        private void ChoixBarre(int i)
        {
            string image = "ram.png";

            if (i == 0)
                image = "ram.png";
            if (i == 1)
                image = "ssd.png";
            if (i == 2)
                image = "hdd.png";
            if (i == 3)
                image = "cm.png";
            if (i == 4)
                image = "cpu.png";
            if (i == 5)
                image = "gpu.png";

            imageBarre.ImageSource = new BitmapImage(new Uri(@"images/" + image, UriKind.Relative));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListeAffichee = (ListBox)sender;

            if (!string.IsNullOrWhiteSpace(M.Bibli.Name))
            {
                Supprimer.IsEnabled = true;
                Modifier.IsEnabled = true;
                Ajouter.IsEnabled = true;
            }
            if (ListeAffichee.SelectedItem != null)
            {
                AffichageVisibilite = Visibility.Visible;
                AjouterComparateur.IsEnabled = true;
                AjouterPanier.IsEnabled = true;
                triMarque.IsEnabled = true;
                triPrix.IsEnabled = true;
                if(userControl1.Visibility==Visibility.Visible)
                    VerificationImage();
            }
            else
            {
                AffichageVisibilite = Visibility.Collapsed;
                AjouterComparateur.IsEnabled = false;
                AjouterPanier.IsEnabled = false;
                triMarque.IsEnabled = false;
                triPrix.IsEnabled = false;
            }
            
        }

       
        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            TextDebut.Visibility = Visibility.Collapsed;
            ListRam.Visibility = Visibility.Collapsed;
            ListCpu.Visibility = Visibility.Collapsed;
            ListGpu.Visibility = Visibility.Collapsed;
            ListHdd.Visibility = Visibility.Collapsed;
            ListSsd.Visibility = Visibility.Collapsed;
            ListCm.Visibility = Visibility.Collapsed;

            chargement.Visibility = Visibility.Collapsed;

            descriptionComp.Visibility = Visibility.Visible;
            userControl1.Visibility = Visibility.Collapsed;
            ValiderModification.Visibility = Visibility.Collapsed;

            ListesSelectionNulle();

            AffichageVisibilite = Visibility.Collapsed;
            Supprimer.IsEnabled = false;
            Modifier.IsEnabled = false;

            if (!string.IsNullOrWhiteSpace(M.Bibli.Name))
                Ajouter.IsEnabled = true;

            if (((Button)sender).Name == "Ram")
            {
                ListRam.Visibility = Visibility.Visible;
                ListRam.SelectedIndex = 0;
            }
            if (((Button)sender).Name == "Cpu")
            {
                ListCpu.Visibility = Visibility.Visible;
                ListCpu.SelectedIndex = 0;
            }
            if (((Button)sender).Name == "Gpu")
            {
                ListGpu.Visibility = Visibility.Visible;
                ListGpu.SelectedIndex = 0;
            }
            if (((Button)sender).Name == "Hdd")
            {
                ListHdd.Visibility = Visibility.Visible;
                ListHdd.SelectedIndex = 0;
            }
            if (((Button)sender).Name == "Ssd")
            {
                ListSsd.Visibility = Visibility.Visible;
                ListSsd.SelectedIndex = 0;
            }
            if (((Button)sender).Name == "Cm")
            {
                ListCm.Visibility = Visibility.Visible;
                ListCm.SelectedIndex = 0;
            }

            M.ListeComparateur.Clear();
            if((int)badgeComp.Badge != 0)
                badgeComp.Badge = M.ListeComparateur.Count();
        }



        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (!M.SupprimerComposant(M.SelectedItem))
                this.ShowMessageAsync("Erreur", "le composant n'a pas pu etre supprimé");
            if(M.SupprimerPanier(M.SelectedItem))
                badgePanier.Badge = M.ListePanier.Count();
            if(M.SupprimerComparateur(M.SelectedItem))
                badgeComp.Badge = M.ListeComparateur.Count();
            M.Sauvegarder();
            Supprimer.IsEnabled = false;
            Modifier.IsEnabled = false;
            ListesSelectionNulle();
        }

        private void ListesSelectionNulle()
        {
            ListRam.SelectedItem = null;
            ListCpu.SelectedItem = null;
            ListGpu.SelectedItem = null;
            ListHdd.SelectedItem = null;
            ListSsd.SelectedItem = null;
            ListCm.SelectedItem = null;
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            Ajouter w = new Ajouter(M);
            descriptionComp.Visibility = Visibility.Visible;
            descriptionComp2.Visibility = Visibility.Visible;
            userControl1.Visibility = Visibility.Collapsed;
            ValiderModification.Visibility = Visibility.Collapsed;
            w.Show();
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            descriptionComp.Visibility = Visibility.Collapsed;
            descriptionComp2.Visibility = Visibility.Collapsed;
            userControl1.Visibility = Visibility.Visible;
            ValiderModification.Visibility = Visibility.Visible;
        }

        private void ValiderModification_Click(object sender, RoutedEventArgs e)
        {
            descriptionComp.Visibility = Visibility.Visible;
            descriptionComp2.Visibility = Visibility.Visible;
            userControl1.Visibility = Visibility.Collapsed;
            ValiderModification.Visibility = Visibility.Collapsed;
            VerificationImage();
            M.Sauvegarder();
        }

        private void VerificationImage()
        {
            var path = M.SelectedItem.ImageLien;
            if (!File.Exists(path))
                M.SelectedItem.ImageLien = @"images\Defaut.jpg";
        }

        private void BouttonConnexion_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxConnexion.Text))
               this.ShowMessageAsync("Erreur", "veuillez entrer un pseudo");
            else
            {
                M.Connexion(TextBoxConnexion.Text);
                TextBoxConnexion.Visibility = Visibility.Collapsed;
                BouttonConnexion.Visibility = Visibility.Collapsed;
                TextBlockConnexion.Text = "vous êtes connecté en tant que : " + M.Bibli.Name;
                TextBlockConnexion.Visibility = Visibility.Visible;
                BouttonDeconnexion.Visibility = Visibility.Visible;
                infoConnexion.Visibility = Visibility.Collapsed;
                popup.Text = "Vous êtes connecté";
                BeginStoryboard((Storyboard)Appli.Resources["MonStoryBoard"]);
                BeginStoryboard((Storyboard)Appli.Resources["MonStoryBoard2"]);
            }
        }

        private void BouttonDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            M.Deconnexion();
            TextBoxConnexion.Text = "";
            TextBoxConnexion.Visibility = Visibility.Visible;
            BouttonConnexion.Visibility = Visibility.Visible;
            TextBlockConnexion.Visibility = Visibility.Collapsed;
            BouttonDeconnexion.Visibility = Visibility.Collapsed;
            infoConnexion.Visibility = Visibility.Visible;
            Supprimer.IsEnabled = false;
            Modifier.IsEnabled = false;
            Ajouter.IsEnabled = false;
            popup.Text = "Vous êtes déconnecté";
            BeginStoryboard((Storyboard)Appli.Resources["MonStoryBoard"]);
            BeginStoryboard((Storyboard)Appli.Resources["MonStoryBoard2"]);
        }

        private void TextBoxConnexion_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
                BouttonConnexion.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        //FILTRES POUR LES LISTES DANS LA VUE
        private void CollectionViewSource_Filter(object sender, System.Windows.Data.FilterEventArgs e)
        {
            Composant c = e.Item as Composant;
            if (c != c as RAM)
                e.Accepted = false;
        }
        private void CollectionViewSource_Filter_2(object sender, System.Windows.Data.FilterEventArgs e)
        {
            Composant c = e.Item as Composant;
            if (c != c as CPU)
                e.Accepted = false;
        }
        private void CollectionViewSource_Filter_3(object sender, System.Windows.Data.FilterEventArgs e)
        {
            Composant c = e.Item as Composant;
            if (c != c as GPU)
                e.Accepted = false;
        }
        private void CollectionViewSource_Filter_4(object sender, System.Windows.Data.FilterEventArgs e)
        {
            Composant c = e.Item as Composant;
            if (c != c as HDD)
                e.Accepted = false;
        }
        private void CollectionViewSource_Filter_5(object sender, System.Windows.Data.FilterEventArgs e)
        {
            Composant c = e.Item as Composant;
            if (c != c as SSD)
                e.Accepted = false;
        }
        private void CollectionViewSource_Filter_6(object sender, System.Windows.Data.FilterEventArgs e)
        {
            Composant c = e.Item as Composant;
            if (c != c as CM)
                e.Accepted = false;
        }

        //Methode dès que l'application est chargée 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ListeAffichee.SelectedItem != null)
                ListeAffichee.SelectedItem = null;
            badgePanier.Badge = M.ListePanier.Count();
            badgeComp.Badge = M.ListeComparateur.Count();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.materiel.net/recherche/" + M.SelectedItem.Marque + " " + M.SelectedItem.Modele);
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.ldlc.com/recherche/" + M.SelectedItem.Marque + " " + M.SelectedItem.Modele);
        }

        private void Hyperlink_Click_2(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.topachat.com/pages/recherche.php?cat=accueil&etou=0&mc=" + M.SelectedItem.Marque + " " + M.SelectedItem.Modele);
        }

 
        private void Panier_Click(object sender, RoutedEventArgs e)
        {
            Panier p = new Panier(M,badgePanier);
            p.Show();
        }

        private void AjouterPanier_Click(object sender, RoutedEventArgs e)
        {
            if (!M.AjoutPanier(M.SelectedItem))
                this.ShowMessageAsync("Erreur","le composant est déjà dans le panier");
            else
            {
                popup.Text = "L'item à bien été ajouté";
                BeginStoryboard((Storyboard)Appli.Resources["MonStoryBoard"]);
                BeginStoryboard((Storyboard)Appli.Resources["MonStoryBoard2"]);
                badgePanier.Badge = M.ListePanier.Count() ;
            }
        }

        private void Comparateur_Click(object sender, RoutedEventArgs e)
        {
            Comparateur c = new Comparateur(M, badgeComp);
            c.Show();
        }

        private void AjouterComparateur_Click(object sender, RoutedEventArgs e)
        {
            if(!M.AjoutComparateur(M.SelectedItem))
                this.ShowMessageAsync("Erreur", "le composant est déjà dans le comparateur");
            else
            {
                popup.Text = "L'item à bien été ajouté";
                BeginStoryboard((Storyboard)Appli.Resources["MonStoryBoard"]);
                BeginStoryboard((Storyboard)Appli.Resources["MonStoryBoard2"]);
                badgeComp.Badge = M.ListeComparateur.Count();
            }
        }

        private void TriMarque_Click(object sender, RoutedEventArgs e)
        {
            ListeAffichee.Items.SortDescriptions.Clear();
            if (I == 0)
            {
                ListeAffichee.Items.SortDescriptions.Add(new SortDescription("Marque", ListSortDirection.Ascending));
                I=1;
            }
            else
            {
                I = 0;
                ListeAffichee.Items.SortDescriptions.Add(new SortDescription("Marque", ListSortDirection.Descending));
                I=0;
            }
        }

        private void TriPrix_Click(object sender, RoutedEventArgs e)
        {
            ListeAffichee.Items.SortDescriptions.Clear();
            if (J == 0)
            {
                ListeAffichee.Items.SortDescriptions.Add(new SortDescription("Prix", ListSortDirection.Ascending));
                J = 1;
            }
            else
            {
                ListeAffichee.Items.SortDescriptions.Add(new SortDescription("Prix", ListSortDirection.Descending));
                J = 0;
            }
        }

        private void Entrer_Click(object sender, RoutedEventArgs e)
        {
            entrer.IsEnabled = false;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            M.Sauvegarder();
        }

        private void DB_Click(object sender, RoutedEventArgs e)
        {
            M.ListeComparateur.Clear();
            M.ListePanier.Clear();
            Manager mana = new Manager(new DonneeComposant());
            M.ListeComp.Clear();
            foreach (Composant c in mana.ListeComp)
            {
                if (!M.ListeComp.Contains(c))
                    M.AjoutComposant(c);
            }
            popup.Text = "Les composants de base sont chargés";
            BeginStoryboard((Storyboard)Appli.Resources["MonStoryBoard"]);
            BeginStoryboard((Storyboard)Appli.Resources["MonStoryBoard2"]);
            badgePanier.Badge = M.ListePanier.Count();
            badgeComp.Badge = M.ListeComparateur.Count();
        }
    }
}
