using Microsoft.VisualStudio.TestTools.UnitTesting;
using defilectureWebApiRest.Models.Equipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace defilectureWebApiRest.Models.Equipe.Tests
{
    [TestClass()]
    public class EquipeDataProviderTests
    {
        [TestMethod()]
        public void GetEquipesTest()
        {
            Console.WriteLine("Test de la méthode GetEquipes");
            Assert.AreEqual(8,EquipeDataProvider.GetEquipes().Count());
        }
    }
}