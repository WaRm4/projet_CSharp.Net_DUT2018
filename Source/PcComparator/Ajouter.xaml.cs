using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using PcComparator.Class;
using PcComparator.Facade;
using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace PcComparator
{
    /// <summary>
    /// Logique d'interaction pour Ajouter.xaml
    /// </summary>
    public partial class Ajouter : MetroWindow
    {
        public Manager M { get; set; }

        public Ajouter(Manager m)
        {
            InitializeComponent();
            this.M = m;
        }

        public void Valider_Click(object sender, RoutedEventArgs e)
        {
            int count = M.ListeComp.Count;
            if (string.IsNullOrEmpty(Prix.text.Text) || string.IsNullOrEmpty(Marque.Text) || string.IsNullOrEmpty(Modele.Text) || string.IsNullOrEmpty(Description.Text) || 
                string.IsNullOrEmpty(Test.Text) || string.IsNullOrEmpty(Test1.Text) || string.IsNullOrEmpty(Test2.Text) || string.IsNullOrEmpty(Test3.Text))
            {
                this.ShowMessageAsync("Erreur", "Veuillez remplir tous les champs");
            }
            else
            {
                if (float.TryParse(Prix.text.Text, out float valeur))
                {
                    if (selecteur.SelectedIndex == 0)
                        AjouterRam();
                    if (selecteur.SelectedIndex == 1)
                        AjouterCpu();
                    if (selecteur.SelectedIndex == 2)
                        AjouterGpu();
                    if (selecteur.SelectedIndex == 3)
                        AjouterHdd();
                    if (selecteur.SelectedIndex == 4)
                        AjouterSsd();
                    if (selecteur.SelectedIndex == 5)
                        AjouterCm();
                }
                else
                {
                    this.ShowMessageAsync("Erreur","Veuillez remplir une valeur correcte pour le Prix");
                    Prix.text.Text = null;
                }
                if (count != M.ListeComp.Count)
                {
                    M.Sauvegarder();
                    Close();
                }
            }
        }



        private void AjouterRam()
        {
            if (int.TryParse(Test.Text, out int valeur))
            {
                if (int.TryParse(Test1.Text, out valeur))
                {
                    if (int.TryParse(Test2.Text, out valeur))
                    {
                        if (int.TryParse(Test3.Text, out valeur))
                        {
                            M.AjoutComposant(new RAM(float.Parse(Prix.text.Text), Marque.Text, Modele.Text, ImageLien.Text, Description.Text, int.Parse(Test.Text), int.Parse(Test1.Text), int.Parse(Test2.Text), int.Parse(Test3.Text)));
                        }
                        else
                        {
                            this.ShowMessageAsync("Erreur", "Veuillez remplir correctement le CAS");
                            Test3.Text = null;
                        }
                    }
                    else
                    {
                        this.ShowMessageAsync("Erreur", "Veuillez remplir correctement la fréquence");
                        Test2.Text = null;
                    }
                }
                else
                {
                    this.ShowMessageAsync("Erreur", "Veuillez remplir correctement le nombre de barrettes");
                    Test1.Text = null;
                }
            }
            else
            {
                this.ShowMessageAsync("Erreur", "Veuillez remplir correctement la capacité");
                Test.Text = null;
            }
        }


        private void AjouterCpu()
        {
            if (int.TryParse(Test.Text, out int valeur))
            {
                if (int.TryParse(Test1.Text, out valeur))
                {
                    if (int.TryParse(Test2.Text, out valeur))
                    {
                        M.AjoutComposant(new CPU(float.Parse(Prix.text.Text), Marque.Text, Modele.Text, ImageLien.Text, Description.Text, int.Parse(Test.Text), int.Parse(Test1.Text), int.Parse(Test2.Text)));
                    }
                    else
                    {
                        this.ShowMessageAsync("Erreur", "Veuillez remplir correctement le nombre de Threads");
                        Test2.Text = null;
                    }
                }
                else
                {
                    this.ShowMessageAsync("Erreur", "Veuillez remplir correctement le nombre de Coeurs");
                    Test1.Text = null;
                }
            }
            else
            {
                this.ShowMessageAsync("Erreur", "Veuillez remplir correctement la Fréquence");
                Test.Text = null;
            }
        }


        private void AjouterGpu()
        {
            if (int.TryParse(Test.Text, out int valeur))
            {
                M.AjoutComposant(new GPU(float.Parse(Prix.text.Text), Marque.Text, Modele.Text, ImageLien.Text, Description.Text, int.Parse(Test.Text)));
            }
            else
            {
                this.ShowMessageAsync("Erreur", "Veuillez remplir correctement la Mémoire");
                Test.Text = null;
            }
        }


        private void AjouterHdd()
        {
            if (int.TryParse(Test.Text, out int valeur))
            {
                if (int.TryParse(Test1.Text, out valeur))
                {
                    if (int.TryParse(Test2.Text, out valeur))
                    {
                        if (int.TryParse(Test3.Text, out valeur))
                        {
                            M.AjoutComposant(new HDD(float.Parse(Prix.text.Text), Marque.Text, Modele.Text, ImageLien.Text, Description.Text, int.Parse(Test.Text), int.Parse(Test2.Text), int.Parse(Test3.Text), float.Parse(Test1.Text)));
                        }
                        else
                        {
                            this.ShowMessageAsync("Erreur", "Veuillez remplir correctement la vitesse d'écriture");
                            Test3.Text = null;
                        }
                    }
                    else
                    {
                        this.ShowMessageAsync("Erreur", "Veuillez remplir correctement la vitesse de lecture");
                        Test2.Text = null;
                    }
                }
                else
                {
                    this.ShowMessageAsync("Erreur", "Veuillez remplir correctement la taille");
                    Test1.Text = null;
                }
            }
            else
            {
                this.ShowMessageAsync("Erreur", "Veuillez remplir correctement la capacité");
                Test.Text = null;
            }
        }


        private void AjouterSsd()
        {
            if (int.TryParse(Test.Text, out int valeur))
            {
                if (int.TryParse(Test2.Text, out valeur))
                {
                    if (int.TryParse(Test3.Text, out valeur))
                    {
                        M.AjoutComposant(new SSD(float.Parse(Prix.text.Text), Marque.Text, Modele.Text, ImageLien.Text, Description.Text, int.Parse(Test.Text), int.Parse(Test2.Text), int.Parse(Test3.Text), Test1.Text));
                    }
                    else
                    {
                        this.ShowMessageAsync("Erreur", "Veuillez remplir correctement la vitesse d'écriture");
                        Test3.Text = null;
                    }
                }
                else
                {
                    this.ShowMessageAsync("Erreur", "Veuillez remplir correctement la vitesse de lecture");
                    Test2.Text = null;
                }
            }
            else
            {
                this.ShowMessageAsync("Erreur", "Veuillez remplir correctement la capacité");
                Test.Text = null;
            }
        }


        private void AjouterCm()
        {
            M.AjoutComposant(new CM(float.Parse(Prix.text.Text), Marque.Text, Modele.Text, ImageLien.Text, Description.Text, Test.Text, Test1.Text, Test2.Text, Test3.Text));
        }



        private void Selecteur_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            test.Visibility = Visibility.Visible;
            test1.Visibility = Visibility.Visible;
            test2.Visibility = Visibility.Visible;
            test3.Visibility = Visibility.Visible;

            Test.Visibility = Visibility.Visible;
            Test1.Visibility = Visibility.Visible;
            Test2.Visibility = Visibility.Visible;
            Test3.Visibility = Visibility.Visible;

            if (selecteur.SelectedIndex == 0)
            {
                test.Text = "Capacité";
                test1.Text = "Nombre de Barrettes";
                test2.Text = "Fréquence";
                test3.Text = "CAS";
            }
            if (selecteur.SelectedIndex == 1)
            {
                test.Text = "Fréquence";
                test1.Text = "Nombre de Coeurs";
                test2.Text = "Nombre de Threads";
                Test3.Text = " ";
                test3.Visibility = Visibility.Hidden;
                Test3.Visibility = Visibility.Hidden;
            }
            if (selecteur.SelectedIndex == 2)
            {
                test.Text = "Mémoire";
                test1.Text = "Format";
                test2.Text = "Chipset";
                test3.Text = "Frequence";
                test1.Visibility = Visibility.Hidden;
                test2.Visibility = Visibility.Hidden;
                test3.Visibility = Visibility.Hidden;
                Test1.Text = " ";
                Test2.Text = " ";
                Test3.Text = " ";
                Test1.Visibility = Visibility.Hidden;
                Test2.Visibility = Visibility.Hidden;
                Test3.Visibility = Visibility.Hidden;
            }
            if (selecteur.SelectedIndex == 3)
            {
                test.Text = "Capacité";
                test1.Text = "Taille";
                test2.Text = "Vitesse de lecture";
                test3.Text = "Vitesse d'écriture";
            }
            if (selecteur.SelectedIndex == 4)
            {
                test.Text = "Capacité";
                test1.Text = "Connectique";
                test2.Text = "Vitesse de lecture";
                test3.Text = "Vitesse d'écriture";
            }
            if (selecteur.SelectedIndex == 5)
            {
                test.Text = "Socket";
                test1.Text = "Format";
                test2.Text = "Chipset";
                test3.Text = "Frequence";
            }
        }

        private void Parcourir_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selectionnez une image dans ce dossier";
            ofd.Filter = "images files (*.png)|*.png|images files (*.jpg)|*.jpg|images files (*.jpeg)|*.jpeg|All files (*.*)|*.*";
            ofd.InitialDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\images";
            ofd.ShowDialog();
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ImageLien.Text = @"images\" + Path.GetFileName(ofd.FileName);
        }
    }
}
