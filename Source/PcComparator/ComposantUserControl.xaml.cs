using PcComparator.Class;
using System.Windows;
using System.Windows.Controls;

namespace PcComparator
{
    /// <summary>
    /// Logique d'interaction pour ComposantUserControl.xaml
    /// </summary>
    public partial class ComposantUserControl : UserControl
    {
        public static readonly DependencyProperty ComposantProperty;

        public Composant Composant
        {
            get
            {
                return GetValue(ComposantProperty) as Composant;
            }
            set
            {
                SetValue(ComposantProperty, value);
            }
        }

        public ComposantUserControl()
        {
            InitializeComponent();
        }

        static ComposantUserControl()
        {
            ComposantProperty = DependencyProperty.Register("Composant", typeof(Composant), typeof(ComposantUserControl));
        }
    }
}
