using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus
{
    class Optimus : Algorithm
    {
        private static int origRow;
        private static int origCol;

        public override void ProcessFile(string fileName)
        {
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
	                catch (OverflowException) { continue; /* Ignore this line in the file */}
                    //Console.WriteLine("-----------------------");
                    GeneratePrimeFactors(value);
                }
            }
        }

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
        }

        private static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

    }
}
