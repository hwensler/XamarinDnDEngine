using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test
{
    [TestClass]
    public class UnitTest1
    {
        //this is a test method just to prove testing works!

        [TestMethod]
        public void doesOneEqualOne()
        {
            Assert.AreEqual(1, 1, "one isn't equal to one");
        }
    }
}
