using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PcComparator.Class;
using PcComparator.Facade;
using PcComparator.Persistance;

namespace PcComparator.Tests
{
    /// <summary>
    /// Classe de test pour tester toutes les méthodes du Manager.
    /// </summary>
    [TestClass]
    public class TestManager
    {
        Manager m = new Manager(new DonneeListe());
        readonly int nombreDeCompo = 18;

        [TestMethod]
        public void TestChargementBibli()
        {
            Assert.AreEqual(nombreDeCompo, m.ListeComp.Count());
        }

        [TestMethod]
        public void TestAjout()
        {
            bool i = m.AjoutComposant(new GPU(150, "hjee", "ui", "ui", "fdj", 12));
            Assert.AreEqual(true, i);
            Assert.AreEqual(nombreDeCompo + 1, m.ListeComp.Count());
        }

        [TestMethod]
        public void TestSuppression()
        {
            m.AjoutComposant(new GPU(150, "hj", "ui", "ui", "fdj", 12));
            bool i = m.SupprimerComposant(new GPU(150, "hj", "ui", "ui", "fdj", 12));
            Assert.AreEqual(true, i);
            Assert.AreEqual(nombreDeCompo, m.ListeComp.Count());
        }

        [TestMethod]
        public void TestAjoutPanier()
        {
            bool i = m.AjoutPanier(new GPU(150, "hjee", "ui", "ui", "fdj", 12));
            Assert.AreEqual(true, i);
            Assert.AreEqual(1, m.ListePanier.Count());
        }

        [TestMethod]
        public void TestSuppressionPanier()
        {
            m.AjoutPanier(new GPU(150, "hj", "ui", "ui", "fdj", 12));
            bool i = m.SupprimerPanier(new GPU(150, "hj", "ui", "ui", "fdj", 12));
            Assert.AreEqual(true, i);
            Assert.AreEqual(0, m.ListePanier.Count());
        }

        [TestMethod]
        public void TestAjoutComparateur()
        {
            bool i = m.AjoutComparateur(new GPU(150, "hjee", "ui", "ui", "fdj", 12));
            Assert.AreEqual(true, i);
            Assert.AreEqual(1, m.ListeComparateur.Count());
        }

        [TestMethod]
        public void TestSuppressionComparateur()
        {
            m.AjoutComparateur(new GPU(150, "hj", "ui", "ui", "fdj", 12));
            bool i = m.SupprimerComparateur(new GPU(150, "hj", "ui", "ui", "fdj", 12));
            Assert.AreEqual(true, i);
            Assert.AreEqual(0, m.ListeComparateur.Count());
        }

        [TestMethod]
        public void TestConnexion()
        {
            string nom = "jean";
            m.Connexion(nom);
            Assert.AreEqual(nom, m.Bibli.Name);
        }

        [TestMethod]
        public void TestDeconnexion()
        {
            string nom = "jean";
            m.Connexion(nom);
            m.Deconnexion();
            Assert.AreEqual(null, m.Bibli.Name);
        }
    }
}

