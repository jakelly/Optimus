using System;
//using System.Runtime.Extensions;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimus;

namespace Optimus
{
    /// <summary>
    /// Generates files with {n} integers; 1 per line.  
    /// Stores the file at a predetermined location.
    /// </summary>
    class FileGenerator
    {
        private string _FileName;
        private int _IntegersPerFile;
        private UInt64 _UpperLimit;

        /// <summary>
        /// Constructor used to generate a file.
        /// </summary>
        /// <param name="FileName">A unique name (without path or extension).</param>
        /// <param name="IntegersPerFile">The number of integer to write to the file.</param>
        /// <param name="UpperLimit">The maximum number that should be randomly generated.
        /// This number should be between 1 and 184,467,440,737,095,551,615.</param>
        public FileGenerator(string FileName = "random file of integers", int IntegersPerFile = 10, UInt64 UpperLimit = UInt64.MaxValue)
        {
            this.FileName = FileName;
            _UpperLimit = UpperLimit;
            _IntegersPerFile = IntegersPerFile;
            this.GenerateFile();
        }

        /// <summary>
        /// Unique name of the File to be generated.
        /// </summary>
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        /// <summary>
        /// Generates a file of integers.
        /// </summary>
        /// <returns>Nadda.  But it does output the file to the "Generated-Data" folder of the Project</returns>
        private void GenerateFile()
        {
            Random rnd = new Random();
            
            //TODO: Test for Directory Not Found.

            string file = String.Format(@"{0}\Generated-Data\{1}",
                Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,
                _FileName.GenerateSlug());

            Console.WriteLine(file);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _IntegersPerFile; i++)
            {
                //FIX:  UpperLimit at this point is irrelevant as randomization doesn't use it.
                Byte[] byteArray = BitConverter.GetBytes(_UpperLimit);
                rnd.NextBytes(byteArray);
                sb.AppendLine(BitConverter.ToUInt64(byteArray, startIndex: 0).ToString());
            }

            using (StreamWriter sw = new StreamWriter(file, append: false))
            {
                sw.Write(sb.ToString());
            }
        }

    }

}
