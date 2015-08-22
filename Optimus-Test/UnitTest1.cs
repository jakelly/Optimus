using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
