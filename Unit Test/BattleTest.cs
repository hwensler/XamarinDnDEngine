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
            charTeam.Enqueue(new Character(10, 10, 10, 1, 10));
            charTeam.Enqueue(new Character(10, 10, 10, 2, 10));
            charTeam.Enqueue(new Character(10, 10, 10, 3, 10));
            charTeam.Enqueue(new Character(10, 10, 10, 4, 10));
        }

        [TestMethod]
        public void TestTeamSize()
        {
            //when creating the team in the game class, we should have an array that we fill in based on index for
            //the stack order. once we have all 4 array elements made we can push to the team Queue.
            
           
            //
            // TODO: Add test logic here
            //
        }

        [TestMethod]
        public void MonsterTeamSizeCorrect()
        {
            initCharTeam();
            Battle testBattle = new Battle(charTeam);
            Assert.AreEqual(testBattle.monstQueueSize(), 4);

        }
    }
}
