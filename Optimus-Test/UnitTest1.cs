using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Optimus;

namespace Optimus_Test
{
    [TestClass]
    public class AutoBots
    {
        [TestMethod]
        public void PrimeFactorsAlgorithmWork()
        {
            GeneratePrimeFactors(360);
        }


        [TestMethod]
        public void TestNewlineCount()
        {
            string line = "We would like\nto count\nthe number\nof times\na newline\nis found\nin this string!\n";
            int count = line.Count(f => f == '\n');
            Assert.AreEqual(count, 7);
        }

        private void GeneratePrimeFactors(ulong value)
        {
            ulong number = value;
            for (ulong i = 2; i <= number;)
            {
                while ((number % i) == 0) 
                {
                    Console.WriteLine("{0} / {1} = {2}", number, i, (number / i));
                    number = number / i;
                };
                i = (i == 2) ? i + 1 : i + 2;
            }
        }
    }
}
