using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App11.Models;

namespace Unit_Test
{
    /// <summary>
    /// Summary description for BattleTest
    /// </summary>
    [TestClass]
    public class BattleTest
    {
        Queue<Fighter> charTeam = new Queue<Fighter>();

        //initCharTeam to simulate the fact that we will have the char Queue created in the Game class.
        private void initCharTeam()
        {
            charTeam.Enqueue(new Character(10, 10, 10, 1, 10,0));
            charTeam.Enqueue(new Character(10, 10, 10, 2, 10,0));
            charTeam.Enqueue(new Character(10, 10, 10, 3, 10,0));
            charTeam.Enqueue(new Character(10, 10, 10, 4, 10,0));
        }

        [TestMethod]
        public void TestTeamSize()
        {
            Queue<Fighter> charQueue = new Queue<Fighter>();
            for (int i = 0; i < 4; i++)
            {
                charQueue.Enqueue(new Character(10, 10, 5 + i, i + 1, 10,0));
            }
            Battle testBattle = new Battle(charQueue);
            Assert.AreEqual(testBattle.charQueueSize(), 4);
        }

        [TestMethod]
        public void MonsterTeamSizeCorrect()
        {
            initCharTeam();
            Battle testBattle = new Battle(charTeam);
            Assert.AreEqual(testBattle.monstQueueSize(), 4);

        }
        //test that Battle Init returns a struct
        [TestMethod]
        public void BattleClassReturnsStruct()
        {
            Queue<Fighter> charQueue = new Queue<Fighter>();
            for (int i = 0; i < 4; i++)
            {
                charQueue.Enqueue(new Character(10, 10, 5 + i, i + 1, 10, 0));
            }

            Battle testBattle = new Battle(charQueue);
            Results testResult = testBattle.initBattle();
            Assert.IsNotNull(testResult);
        }

        //Monsters win if passed empty hero queue
        [TestMethod]
        public void EmptyCharQueuMonstWin()
        {
            Queue<Fighter> charQueue = new Queue<Fighter>();
            Battle testBattle = new Battle(charQueue);
            Results testResult = testBattle.initBattle();
            Assert.IsFalse(testResult.charsWon);
        }
        //test that Battle Init returns a struct that has a not Null score
        [TestMethod]
        public void BattleClassReturnsStructwithNonNullScore()
        {
            Queue<Fighter> charQueue = new Queue<Fighter>();
            for (int i = 0; i < 4; i++)
            {
                charQueue.Enqueue(new Character(10, 10, 5 + i, i + 1, 10, 0));
            }

            Battle testBattle = new Battle(charQueue);
            Results testResult = testBattle.initBattle();
            Assert.IsNotNull(testResult.points);
        }
        [TestMethod]
        public void damageIsGreaterThanOrEqualZero()
        {
            Battle testBattle = new Battle();
            bool damage =
                testBattle.testBattleLogic(
                    new Character(10, 10, 5, 1, 10, 0), 
                    new Monster(10, 10, 5, 1, 10, 0));
            Assert.IsTrue(damage);
        }
    }
}
