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
        //not a test method
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
            //will need mock database to test with monsters
            Queue<Fighter> charQueue = new Queue<Fighter>();
            for (int i = 0; i < 4; i++)
            {
                charQueue.Enqueue(new Character(10, 10, 5 + i, i + 1, 10,0));
            }
            BattleController testBattle = new BattleController(charQueue);
            Assert.AreEqual(testBattle.charQueueSize(), 4);
        }

        [TestMethod]
        public void MonsterTeamSizeCorrect()
        {
            initCharTeam();
            BattleController testBattle = new BattleController(charTeam);
            Assert.AreEqual(testBattle.monstQueueSize(), 4);

        }
        //test that Battle Init returns a struct
        [TestMethod]
        public void BattleClassReturnsStruct()
        {
            //will need mock database to test with monsters
            Queue<Fighter> charQueue = new Queue<Fighter>();
            for (int i = 0; i < 4; i++)
            {
                charQueue.Enqueue(new Character(10, 10, 5 + i, i + 1, 10, 0));
            }

            BattleController testBattle = new BattleController(charQueue);
            Results testResult = testBattle.initBattle();
            Assert.IsNotNull(testResult);
        }

        //Monsters win if passed empty hero queue
        [TestMethod]
        public void EmptyCharQueuMonstWin()
        {
            //will need mock database to test with monsters
            Queue<Fighter> charQueue = new Queue<Fighter>();
            BattleController testBattle = new BattleController(charQueue);
            Results testResult = testBattle.initBattle();
            Assert.IsFalse(testResult.charsWon);
        }
        //test that Battle Init returns a struct that has a not Null score
        [TestMethod]
        public void BattleClassReturnsStructwithNonNullScore()
        {
            //will need mock database to test with monsters
            Queue<Fighter> charQueue = new Queue<Fighter>();
            for (int i = 0; i < 4; i++)
            {
                charQueue.Enqueue(new Character(10, 10, 5 + i, i + 1, 10, 0));
            }

            BattleController testBattle = new BattleController(charQueue);
            Results testResult = testBattle.initBattle();
            Assert.IsNotNull(testResult.points);
        }
        [TestMethod]
        public void damageIsGreaterThanOrEqualZero()
        {
            //battleoutput interfering with the unit test.
            BattleController testBattle = new BattleController();
            bool damage =
                testBattle.testBattleLogic(
                    new Character(10, 10, 5, 1, 10, 0), 
                    new Monster(10, 10, 5, 1, 10, 0));
            Assert.IsTrue(damage);
        }
        [TestMethod]
        public void BattleQueueisSorted()
        {
            //will need mock database to test with monsters
            Queue<Fighter> charQueue = new Queue<Fighter>();
            for (int i = 0; i < 4; i++)
            {
                charQueue.Enqueue(new Character(10, 10, 5 + i, i + 1, 10, 0));
            }

            BattleController testBattle = new BattleController(charQueue);
            bool isSorted = testBattle.testSetOrder();
            Assert.IsTrue(isSorted);
        }
    }
}
