﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus
{
    class Optimus : Algorithm
    {
        /// <summary>
        /// Runs the algorithm against each integer in the referenced file.
        /// </summary>
        /// <param name="fileName">Name of file to be processed</param>
        /// <returns>Number of lines processed.</returns>
        public override int ProcessFile(string fileName)
        {
            int linesProcessed = 0;

            if (! (File.Exists(fileName)) )
            {
                if (fileName.Contains(@"\")) throw new FileNotFoundException(
                    "The file passed into this Optimus Algorithm could not be found.",
                    fileName);
                
            }

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    ulong value;
                    try { value = Convert.ToUInt64(line); }
	                catch (Exception) { continue; /* Ignore this line in the file */}
                    GeneratePrimeFactors(value);
                    linesProcessed += 1;
                }
            }
            return linesProcessed;
        }


        /// <summary>
        /// Generates the prime factors of a given number.
        /// </summary>
        /// <param name="value"></param>
        public static void GeneratePrimeFactors(ulong value)
        {
            ulong number = value;
            Console.Write(value + " = ");

            for (ulong i = 2; i <= (ulong)Math.Sqrt(number); /* Increments conditionally */)
            {
                while ((number % i) == 0)
                {
                    Console.Write(i + ", ");
                    number = number / i;
                };
                i = (i == 2) ? i + 1 : i + 2; // Eliminate multiples of 2
                if (((i % 5) == 0) && (i > 5)) i += 2;   // Eliminate multiples of 5
            }
            Console.WriteLine(number);
            System.Threading.Thread.Sleep(50);
        }

    }
}
