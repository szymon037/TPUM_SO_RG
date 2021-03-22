using Microsoft.VisualStudio.TestTools.UnitTesting;
using App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GreaterThanZeroTest()
        {
            Assert.IsTrue(Program.GreaterThanZero(1));
            Assert.IsFalse(Program.GreaterThanZero(0));
            Assert.IsFalse(Program.GreaterThanZero(-1));
        }
    }
}