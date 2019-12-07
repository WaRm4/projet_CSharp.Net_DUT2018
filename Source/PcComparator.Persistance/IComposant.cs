using PcComparator.Class;

namespace PcComparator.Persistance
{
    /// <summary>
    /// Interface pour définir plusieurs persistances.
    /// </summary>
    public interface IComposant
    {
        /// <summary>
        /// Méthode pour lire et remplir une bibliothèque.
        /// </summary>
        /// <returns></returns>
        Bibliotheque LireBibli();

        /// <summary>
        /// Méthode pour sauvegarder la liste de composants de la bibliothèque.
        /// </summary>
        /// <param name="bibli"></param>
        void Sauvegarder(Bibliotheque bibli);

    }
}
