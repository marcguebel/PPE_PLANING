using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]//Exemple test
        public void TestAdditionner()
        {
            //Calculette c = new Calculette();
            //double r = c.additionner(4, 6);
            //Assert.AreEqual(r, 10, "Incoh�rence du r�sultat d'addition");
        }


        //Test de la class membre
        [TestMethod]
        public void TestPresentationMembre()// Appel de la m�thode pr�sentation 
        {
            Membre m = new Membre();
            m.presentation("nom", "prenom");
            Assert.AreEqual(m, "nom prenom", "Incoh�rence dans la pr�sentation");
        }
        [TestMethod]
        public void TestAoutMembreAUnEvenement()// test d'ajout d'un membre a un evenemnt
        {
            Membre m = new Membre();
            m.ajoutMembreAUnEvenement("Evenement Test");
            Assert.AreEqual(m, "Evenement Test", "Incoh�rence dans l'ajout d'un membre a un evenement");
        }



        //Test de la class Journee
        [TestMethod]
        public void TestAjoutMembreAunEvenement()// test d'ajout d'un membre a un evenemnt
        {
            Journee j = new Journee();
            j.listeEvenement.add("Test nom", "Test description");
            Assert.AreEqual(j, "", "Incoh�rence dans la pr�sentation");
        }




        //Test de la class DAO
        [TestMethod]
        public void TestCoBDD()// test de connexion
        {
            DAO d = new DAO();
            Assert.AreEqual(d, true, "Incoh�rence dans la pr�sentation");
        }





        //Test de la class terrain:
        [TestMethod]
        public void ()
        {
            DAO d = new DAO();
            Assert.AreEqual(d, true, "Incoh�rence dans la pr�sentation");
        }






    }
}
