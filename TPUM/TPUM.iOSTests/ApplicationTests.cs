using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPUM.iOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPUM.iOS.Tests
{
    [TestClass()]
    public class ApplicationTests
    {
        [TestMethod()]
        public void GreaterThanZeroTest()
        {
            Assert.IsTrue(Application.GreaterThanZero(1));
            Assert.IsFalse(Application.GreaterThanZero(0));
            Assert.IsFalse(Application.GreaterThanZero(-1));
        }
    }
}