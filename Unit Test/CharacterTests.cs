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
        public void TestMethod1()
        {
        }
    }
}
