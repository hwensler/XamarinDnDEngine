using System;
using App11.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test
{
    [TestClass]
    public class MonsterTests
    {
        Monster testMonster = new Monster(10, 10, 10, 10, 10, 10);

        //just testing a getter
        [TestMethod]
        public void GetMonsterStrengthWorks()
        {
            Assert.AreEqual(testMonster.Strength, 1);
        }

        //test doing an amount of damage to the defender
        [TestMethod]
        public void ChangeHPWorks()
        {
            testMonster.ChangeHP(1);
            Assert.AreEqual(testMonster.HitPoints, 11);
        }
    }
}
