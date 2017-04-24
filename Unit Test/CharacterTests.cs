using System;
using App11.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/**
 * This class will only test things unique to the character class.
 * For tests on the functionality of things inherited from Fighter.cs, check MonsterTests.cs
 * **/

namespace Unit_Test
{
    [TestClass]
    public class CharacterTests
    {

        Character testCharacter = new Character(10, 10, 10, 10, 10);

        [TestMethod]
        public void AwardExpWorks()
        {
            testCharacter.AwardExp(50);
            Assert.AreEqual(testCharacter.Experience, 50);
        }

        [TestMethod]
        public void LevelUpWorksWhenItShould()
        {
            testCharacter.AwardExp(1100);
            Assert.AreEqual(testCharacter.Level, 11);
        }
        [TestMethod]
        //works if character level is 0
        public void LevelUpDoesNotWorkWhen0EXP()
        {
            testCharacter.AwardExp(0);
            Assert.AreEqual(testCharacter.Level, 0);
        }
        [TestMethod]
        public void AwardExpandLevelUpWorks()
        {
            testCharacter.Experience += 50;
            testCharacter.AwardExp(51);
            Assert.AreEqual(testCharacter.Level, 1);

        }

        [TestMethod]
        public void CharacterNameAssignmentWorks()
        {
            testCharacter.Name = "Test Character";
            Assert.AreEqual(testCharacter.Name, "Test Character");
        }
    }
}
