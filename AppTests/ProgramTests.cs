using Microsoft.VisualStudio.TestTools.UnitTesting;

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