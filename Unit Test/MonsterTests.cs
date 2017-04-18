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
            Assert.AreEqual(testMonster.Strength, 10);
        }

        //test changing your own hp 
        [TestMethod]
        public void ChangeHPWorks()
        {
            testMonster.ChangeHP(1);
            Assert.AreEqual(testMonster.HitPoints, 11);
        }

        //test doing damage (to self, in this case)
        [TestMethod]

        public void DoDamageWorks()
        {
            testMonster.DoDamage(testMonster, 5);
            Assert.AreEqual(testMonster.HitPoints, 5);
        }
    }
}
