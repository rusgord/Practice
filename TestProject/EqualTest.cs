using Shop.Logic.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class EqualTest
    {
        [TestMethod]
        public void EqualCpu1() 
        {
            string cpu = "Intel_i3";
            int a=0;
            bool result = Processor.Equal(cpu, ref a, ref a);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void EqualCpu2()
        {
            string cpu = "Intel_i3";
            int actual = 0;
            int b = 0;
            int expected = 1;
            Processor.Equal(cpu, ref actual, ref b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualCpu3()
        {
            string cpu = "Intel_i3";
            int a = 0;
            int actual = 0;
            int expected = 1;
            Processor.Equal(cpu, ref a, ref actual);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualCpu4()
        {
            string cpu = "Intel_i1";
            int a = 0;
            bool result = Processor.Equal(cpu, ref a, ref a);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EqualCpu5()
        {
            string cpu = "Intel_i1";
            int actual = 0;
            int b = 0;
            int expected = 1;
            Processor.Equal(cpu, ref actual, ref b);
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void EqualCpu6()
        {
            string cpu = "Intel_i1";
            int a = 0;
            int actual = 0;
            int expected = 1;
            Processor.Equal(cpu, ref a, ref actual);
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void EqualGpu1()
        {
            string cpu = "GTX_1650";
            int a = 0;
            bool result = Videocard.Equal(cpu, ref a, ref a);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void EqualGpu2()
        {
            string cpu = "GTX_1650";
            int actual = 0;
            int b = 0;
            int expected = 1;
            Videocard.Equal(cpu, ref actual, ref b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualGpu3()
        {
            string cpu = "GTX_1650";
            int a = 0;
            int actual = 0;
            int expected = 1;
            Videocard.Equal(cpu, ref a, ref actual);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualGpu4()
        {
            string cpu = "GTS_450";
            int a = 0;
            bool result = Videocard.Equal(cpu, ref a, ref a);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EqualGpu5()
        {
            string cpu = "GTS_450";
            int actual = 0;
            int b = 0;
            int expected = 1;
            Videocard.Equal(cpu, ref actual, ref b);
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void EqualGpu6()
        {
            string cpu = "GTS_450";
            int a = 0;
            int actual = 0;
            int expected = 1;
            Videocard.Equal(cpu, ref a, ref actual);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
