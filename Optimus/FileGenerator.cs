using System;
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
        private uint _integersPerFile;
        private UInt64 _upperLimit;
        private UInt64 _lowerLimit;


        /// <summary>
        /// Constructor used to generate a file.
        /// This number should be between lowerLimit(1) and upperLimit (184,467,440,737,095,551,615).</param>
        /// </summary>
        /// <param name="input"></param>
        public FileGenerator(Inputs input)
        {
            if (input == null) throw new ArgumentNullException("Input needed for FileGenerator to work");
            this.FileName = input.fileName;
            _upperLimit = (input.upperLimit <= 1) ? 999999 : input.upperLimit;
            _lowerLimit = (input.lowerLimit <= 1) ? 999 : input.lowerLimit;
            _integersPerFile = input.integersPerFile;

            this.GenerateFile();
        }


        /// <summary>
        /// Unique name of the File to be generated.
        /// </summary>
        public string FileName { get; set; }
        public string FullPath { get; set; }
        

        /// <summary>
        /// Creates a FileName for the Generated File.  Ensures the folder exists for the file as well.
        /// </summary>
        /// <returns>File Name that was created based on the FileName passed in.</returns>
        public string CreateFileName(string fileName = "")
        {
            // Give option to pass a different file name.
            if (String.IsNullOrWhiteSpace(fileName)) fileName = this.FileName;
 
            string workingDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string dataDirectory = String.Format(@"{0}\Generated-Data\", workingDirectory);

            if (!(Directory.Exists(dataDirectory))) Directory.CreateDirectory(dataDirectory);

            FullPath = String.Format(@"{0}{1}", dataDirectory, fileName.GenerateSlug());
            return FullPath;
        }


        /// <summary>
        /// Generates a file of integers.
        /// </summary>
        /// <returns>Nadda.  But it does output the file to the "Generated-Data" folder of the Project</returns>
        private void GenerateFile()
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _integersPerFile; i++)
            {
                ulong value = rnd.Next(_lowerLimit, _upperLimit);
                sb.AppendLine(value.ToString());
            }

            using (StreamWriter sw = new StreamWriter(CreateFileName(), append: false))
            {
                sw.Write(sb.ToString());
            }
        }

    }

}
