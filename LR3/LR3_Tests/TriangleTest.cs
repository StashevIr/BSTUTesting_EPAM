using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LR3_dll;

namespace LR3_Tests
{
    [TestClass]
    public class TestTriangle
    {
        [TestMethod]
        public void OneSideIsZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 10, 17));
        }

        [TestMethod]
        public void AllSidesIsZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 0, 0));
        }

        [TestMethod]
        public void OneSideIsNegative()
        {
            Assert.IsFalse(Triangle.IsTriangle(-4, 2, 9));
        }

        [TestMethod]
        public void AllSidesIsNegative()
        {
            Assert.IsFalse(Triangle.IsTriangle(-4, -2, -9));
        }

        [TestMethod]
        public void IsoscelesTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(3, 3, 5));
        }

        [TestMethod]
        public void EquilateralTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(3, 3, 3));
        }

        [TestMethod]
        public void RightTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(8, 6, 10));
        }

        [TestMethod]
        public void SumMoreThanSideLength()
        {
            Assert.IsTrue(Triangle.IsTriangle(10, 9, 18));
        }
        
        [TestMethod]
        public void SumLessThanSideLength()
        {
            Assert.IsFalse(Triangle.IsTriangle(3, 1, 5));
        }
        
        [TestMethod]
        public void DoubleSideType()
        {
            Assert.IsTrue(Triangle.IsTriangle(0.5, 0.5, 0.8));
        }
    }
}
