using PcComparator.Class;
using System.Windows;
using System.Windows.Controls;

namespace PcComparator.Ressources
{
    /// <summary>
    /// TemplateSelector pour une liste ou bien un affichage différent en fonction du type de composant.
    /// </summary>
    public class ComposantTemplateSelector : DataTemplateSelector
    {
        public DataTemplate RamTemplate
        {
            get; set;
        }

        public DataTemplate CpuTemplate
        {
            get; set;
        }

        public DataTemplate GpuTemplate
        {
            get; set;
        }

        public DataTemplate HddTemplate
        {
            get; set;
        }

        public DataTemplate SsdTemplate
        {
            get; set;
        }

        public DataTemplate CmTemplate
        {
            get; set;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is RAM) return RamTemplate;
            if (item is CPU) return CpuTemplate;
            if (item is GPU) return GpuTemplate;
            if (item is HDD) return HddTemplate;
            if (item is SSD) return SsdTemplate;
            if (item is CM) return CmTemplate;
            return base.SelectTemplate(item, container);
        }
    }
}
