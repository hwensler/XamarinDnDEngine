using System;
using App11.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test
{
    [TestClass]
    public class MonsterTests
    {
        Monster testMonster = new Monster(1, 1, 1, 1, 1);

        [TestMethod]
        public void GetMonsterStrengthWorks()
        {
            Assert.AreEqual(testMonster.Strength, 1);
        }
    }
}
