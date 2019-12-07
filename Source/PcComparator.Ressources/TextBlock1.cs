using System.Windows;
using System.Windows.Controls;

namespace PcComparator.Ressources
{
    /// <summary>
    /// TextBlock custom pour que les textblocks aient la même police et la même taille.
    /// </summary>
    public class TextBlock1 : TextBlock
    {
        public static readonly DependencyProperty CustomProperty;

        static TextBlock1()
        {
            CustomProperty = DependencyProperty.Register("custom", typeof(int), typeof(TextBlock1));

        }
    }
}
