using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fax;

namespace FaxTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void feldolgozhatoSzamlaszam()
        {
            Numbers.szamlaszam = "883456789";
            Assert.IsTrue(!Numbers.szamlaszam.Contains("?"));

        }

        [TestMethod]
        public void hibasSzamlaszam()
        {
            Numbers.szamlaszam = "123456?89";
            Assert.IsTrue(Numbers.szamlaszam.Contains("?"));
        }

        [TestMethod]
        public void helyesSzamlaszam()
        {
            Numbers.szamlaszam = "183456789";// Ha az elsõ számjegy 8, akkor átmegy
            Assert.IsTrue(Numbers.ellenorzes(Numbers.szamlaszam) == 0);
        }
    }
}