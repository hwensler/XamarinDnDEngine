using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Unit_Tests
{
    [TestFixture(Platform.Android)]

    public class Tests
    {
        /**
         * A test test. The simplest case.
         * **/
        [Test]
        public void DoesOneEqualOne (){
            Assert.AreEqual(1, 1, "1 equals 1");

        }
    }
}

