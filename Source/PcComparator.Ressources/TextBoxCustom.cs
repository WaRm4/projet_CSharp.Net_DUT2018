using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace PcComparator.Ressources
{
    /// <summary>
    /// Suivez les étapes 1a ou 1b puis 2 pour utiliser ce contrôle personnalisé dans un fichier XAML.
    ///
    /// Étape 1a) Utilisation de ce contrôle personnalisé dans un fichier XAML qui existe dans le projet actif.
    /// Ajoutez cet attribut XmlNamespace à l'élément racine du fichier de balisage où il doit 
    /// être utilisé :
    ///
    ///     xmlns:MyNamespace="clr-namespace:PcComparator.Ressources"
    ///
    ///
    /// Étape 1b) Utilisation de ce contrôle personnalisé dans un fichier XAML qui existe dans un autre projet.
    /// Ajoutez cet attribut XmlNamespace à l'élément racine du fichier de balisage où il doit 
    /// être utilisé :
    ///
    ///     xmlns:MyNamespace="clr-namespace:PcComparator.Ressources;assembly=PcComparator.Ressources"
    ///
    /// Vous devrez également ajouter une référence du projet contenant le fichier XAML
    /// à ce projet et regénérer pour éviter des erreurs de compilation :
    ///
    ///     Cliquez avec le bouton droit sur le projet cible dans l'Explorateur de solutions, puis sur
    ///     "Ajouter une référence"->"Projets"->[Sélectionnez ce projet]
    ///
    ///
    /// Étape 2)
    /// Utilisez à présent votre contrôle dans le fichier XAML.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    /// 
    ///TextBox custom avec des boutons + et - pour pouvoir augmenter ou baisser le chiffre présent dans la textbox.
    public class TextBoxCustom : TextBox
    {

        public static readonly DependencyProperty CustomProperty;

        public TextBox text;
        private Button button1;
        private Button button2;

        static TextBoxCustom()
        {
            CustomProperty = DependencyProperty.Register("custom", typeof(int), typeof(TextBoxCustom));

        }

        override
        public void OnApplyTemplate()
        {
            button1 = GetTemplateChild("b1") as Button;
            button2 = GetTemplateChild("b2") as Button;
            text = GetTemplateChild("t") as TextBox;

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            text.KeyDown += Text_KeyDown;
        }

        private void Text_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.F1)
                button1.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            if (e.Key == System.Windows.Input.Key.F2)
                button2.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            int valeur;
            if (int.TryParse(text.Text, out valeur))
            {
                int nombre = int.Parse(text.Text);
                nombre--;
                text.Text = nombre.ToString();
            }
            else
            {
                MessageBox.Show("Veuillez entrer un chiffre/nombre");
                text.Text = "";
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            int valeur;
            if (int.TryParse(text.Text, out valeur))
            {
                int nombre = int.Parse(text.Text);
                nombre++;
                text.Text = nombre.ToString();
            }
            else
            {
                MessageBox.Show("Veuillez entrer un chiffre/nombre");
                text.Text = "";
            }
        }
    }
}