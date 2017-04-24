using System;
using App11.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/**
 * This class tests Fighter class attributes through Monster class because
 * right now, Monster has no distinct operates and fighter class (as it is 
 * just a class to inheret from) contains no constructor.
 * **/

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

        //tests a setter
        [TestMethod]
        public void SetMonsterStrengthWorks()
        {
            testMonster.Strength = 15;
            Assert.AreEqual(testMonster.Strength, 15);
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

        //tests that stats are adjusted correctly
        [TestMethod]
        public void AdjustStatsWorks()
        {
            testMonster.AdjustStats(1, 0, 0);
            Assert.AreEqual(testMonster.Strength, 11);
        }

        //tests that IsAlive works
        [TestMethod]
        public void IsAliveWorksWhenHPGreaterThanZero()
        {
            Assert.IsTrue(testMonster.IsAlive());
        }

        [TestMethod]
        public void IsAliveWorksWhenHPEqualsZero()
        {
            Monster testMonster2 = new Monster(10, 10, 10, 10, 0, 10);
            Assert.IsFalse(testMonster2.IsAlive());
        }

        [TestMethod]
        public void IsAliveWorksWhenHPIsNegative()
        {
            Monster testMonster2 = new Monster(10, 10, 10, 10, -5, 10);
            Assert.IsFalse(testMonster2.IsAlive());
        }

        [TestMethod]
        public void MonsterNameAssignmentWorks()
        {
            testMonster.Name = "Test Monster";
            Assert.AreEqual(testMonster.Name, "Test Monster");
        }
    }
}
