using PcComparator.Class;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PcComparator.Persistance
{
    /// <summary>
    /// Première persistance, stub, instancie une liste pour pouvoir remplir une bibliothèque.
    /// Cette Liste est la même que celle sauvegardée dans le fichier contenant les données de base. 
    /// Sert princiaplement pour le projet de Test unitaire.
    /// </summary>
    public class DonneeListe : IComposant
    {
        /// <summary>
        /// Liste de composants de base.
        /// </summary>
        private static readonly List<Composant> ListComposant = new List<Composant>()
        {
        new RAM(150, "Corsair","vengeance","ram2.jpg", "bon pour de la bureautique",8,2,3666,15),
        new RAM(350, "GSkill", "TridentZ", "ram.png", "OVERKILL", 32, 2, 3666, 15),
        new RAM(150, "HyperX", "Predator", "ram3.jpg", "bon pour du gaming", 8, 2, 3666, 15),
        new CPU(150, "Intel core", "i9", "cpu.png", "OVERKILL", 4.5f, 4, 8),
        new CPU(350, "AMD", "Ryzen 5", "ryzen 5.jpg", "bon pour de la bureautique/gaming", 3.5f, 8, 16),
        new CPU(150, "Intel core", "i7", "i7.jpg", "bon pour du gaming", 4, 4, 8),
        new GPU(260, "Nvidia", "gtx 1050", "1050.jpg", "bon pour du gaming avec des graphismes bas", 4),
        new GPU(370, "Nvidia", "gtx 1070", "1070.jpg", "bon pour du gaming avec des graphismes moyens", 6),
        new GPU(450, "Nvidia", "gtx 1080ti", "gpu.png", "bon pour du gaming avec des graphismes très hauts", 8),
        new HDD(260, "Seagate", "barracuda", "hdd.png", "Bon HDD qui dur dans le temps", 1000,160,130,2.5f),
        new HDD(370, "Western Digital", "Blue", "western blue.jpg", "grande capacité de stockage", 2000, 150, 120, 2.5f),
        new HDD(450, "Western Digital", "Green", "western green.jpg", "bonne vitesse de lecture et ecriture", 1000, 100, 200, 3),
        new SSD(260, "Samsung", "960 evo", "960 evo.jpg", "un des meilleurs ssd m.2", 1000, 800, 600, "m.2"),
        new SSD(370, "Samsung", "860 evo", "860 evo.jpg", "bon ssd", 2000, 250, 220, "sata 3"),
        new SSD(450, "Kingston", "A400", "ssd.png", "meilleur ssd sata 3", 1000, 500, 450, "sata 3"),
        new CM(260, "MSI", "MEG", "msi meg.jpg", "Carte mere de gamer", "1151", "ATX", "Z390", "DDR4"),
        new CM(370, "Intel", "B360 gaming", "cm.png", "bon pour le jeu", "Am4", "micro-ATX", "AMD X470", "DDR4"),
        new CM(450, "ASUS", "tuf", "asus tuf.jpg", "bonne carte mere bas prix", "1151", "mini-ATX", "H310 express", "DDR3"),
        };

        /// <summary>
        /// Méthode pour lire et remplir la bibliothèque à partir d'une liste de composants.
        /// </summary>
        /// <returns></returns>
        public Bibliotheque LireBibli()
        {
            return new Bibliotheque(new ObservableCollection<Composant>(ListComposant));
        }

        /// <summary>
        /// Méthode pour sauvegarder, n'existe pas, car on ne se sert de cette persistance seulement pour le test unitaire.
        /// </summary>
        /// <param name="bibli"></param>
        public void Sauvegarder(Bibliotheque bibli)
        {
        }
    }
}
