using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus
{
    class Program
    {
        /// <summary>
        /// The entry point of this program.  Where it all begins...
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            InitializeWorkingDirectory();
            do
            {
                Run();
            } while (Inquire("\nRun Again? [Y/N]:  ", Console.CursorTop + 5).ToUpper() == "Y");
            
        }


        /// <summary>
        /// Separated from [Main] to allow the program to loop indefinitely.
        /// </summary>
        static void Run()
        {
            Intro();
            Inputs input = GetInputs();
            if (input == null) throw new NullReferenceException("We need input my friend!");

            string fileName = String.Empty;
            // File is to be generated.
            if (!((input.lowerLimit == 0)
                && (input.upperLimit == 0)
                && (input.integersPerFile == 0)))
            {
                FileGenerator fg = new FileGenerator(input);
                fileName = fg.FullPath;
            }
            else
            {
                fileName = input.fileName;
            }

            var lineCount = File.ReadLines(fileName).Count();

            Console.BufferHeight = (lineCount > Console.BufferHeight) ? lineCount + 5 : Console.BufferHeight;
            Console.Write("On to the results... [Press Enter]");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(new string('▄', Console.WindowWidth));
            Console.WriteLine("Results: ");
            Console.WriteLine(new string('▀', Console.WindowWidth));
            Algorithm algorithm = new Optimus();
            algorithm.ProcessFile(fileName);
        }

        /// <summary>
        /// Every body loves an intro right?
        /// </summary>
        static void Intro()
        {
            Console.Title = "Andrew's Optimus Prime Program";
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.SetWindowSize(79, 40);
            Console.WriteLine("".PadRight(79, '*'));
            Console.WriteLine("*" + "".PadRight(77) + "*");
            Console.WriteLine("*".PadRight(24) + Console.Title.PadRight(54) + "*");
            Console.WriteLine("*" + "".PadRight(77) + "*");
            Console.WriteLine("*".PadRight(24) + "───────────▄▄▄▄▄▄▄▄▄───────────".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "────────▄█████████████▄────────".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "█████──█████████████████──█████".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "▐████▌─▀███▄───────▄███▀─▐████▌".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "─█████▄──▀███▄───▄███▀──▄█████─".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "─▐██▀███▄──▀███▄███▀──▄███▀██▌─".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "──███▄▀███▄──▀███▀──▄███▀▄███──".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "──▐█▄▀█▄▀███─▄─▀─▄─███▀▄█▀▄█▌──".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "───███▄▀█▄██─██▄██─██▄█▀▄███───".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "────▀███▄▀██─█████─██▀▄███▀────".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "───█▄─▀█████─█████─█████▀─▄█───".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "───███────────███────────███───".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "───███▄────▄█─███─█▄────▄███───".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "───█████─▄███─███─███▄─█████───".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "───█████─████─███─████─█████───".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "───█████─████─███─████─█████───".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "───█████─████─███─████─█████───".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "───█████─████▄▄▄▄▄████─█████───".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "────▀███─█████████████─███▀────".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "──────▀█─███─▄▄▄▄▄─███─█▀──────".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "─────────▀█▌▐█████▌▐█▀─────────".PadRight(54) + "*");
            Console.WriteLine("*".PadRight(24) + "────────────███████────────────".PadRight(54) + "*");
            Console.WriteLine("*" + "".PadRight(77) + "*");
            Console.WriteLine("".PadRight(79, '*'));
            Console.WriteLine("*" + "".PadRight(77) + "*");
            string quote = GetQuote();
            if (quote.Length < 79)
            {
                Console.WriteLine(("*".PadRight(((79 - quote.Length) / 2)) + quote).PadRight(78) + "*");
            }
            Console.WriteLine("*" + "".PadRight(77) + "*");
            Console.WriteLine("".PadRight(79, '*'));
            Console.WriteLine();
        }


        /// <summary>
        /// Ask the hard questions.  Get the answers...
        /// </summary>
        static Inputs GetInputs()
        {
            string answer = "", 
                fileName = "";
            uint numbers = 0;
            ulong digits = 5;

            //Console.Write("{0}, {1}", Console.CursorTop, Console.CursorLeft);
            answer = Inquire("\nShould we generate a file? [Y/N]:  ");
            do
            {
                if (answer.ToUpper() == "Y") 
                {
                    fileName = InquireNewFileName();
                    numbers = InquireNumbers();
                    //digits = InquireBoundries();
                    return new Inputs()
                    {
                        upperLimit = 999999999,
                        lowerLimit = 999,
                        integersPerFile = numbers,
                        fileName = fileName
                    };
                }
                else if (answer.ToUpper() == "N")
                {
                    fileName = InquireExistingFileName();
                    return new Inputs()
                    {
                        upperLimit = 0,
                        lowerLimit = 0,
                        integersPerFile = 0,
                        fileName = fileName                        
                    };
                }
                else {
                    answer = Inquire("Let's try to answer that question again...\nShould we generate a file? [Y/N]:  ");
                }
            } while (true);
            return null;
        }


        /// <summary>
        /// Let's get that file name nailed down...
        /// </summary>
        /// <returns>The file name to be used to generate the file of numbers.</returns>
        static string InquireNewFileName()
        {
            string answer;
            string fileName = GetRandomFileName().GenerateSlug();

            do
            {
                answer = Inquire(String.Format(
                    "Let's give this file a name.  I suggest: '{0}'\nUse '{0}'? [Y/N]:  ", 
                    fileName));
            } while (!((answer.ToUpper() == "Y") || (answer.ToUpper() == "N")));

            Console.WriteLine();

            if (answer.ToUpper() == "N")
            {
                do
                {
                    fileName = Inquire("Enter a File Name of your choice:  ");
                    if (fileName == fileName.GenerateSlug()) break;
                    fileName = fileName.GenerateSlug();
                    
                    do
                    {
                        answer = Inquire(String.Format(
                            "I took the liberty of cleaning that file name up for you.\nOK to use: '{0}'? [Y/N]:  ",
                            fileName));
                        if (answer.ToUpper() == "Y" || answer.ToUpper() == "N") break;
                    } while (true);
                    
                    if (answer.ToUpper() == "Y") break;
                } while (true);
            }

            return fileName;
        }


        /// <summary>
        /// Asks the user for the custom file they wish to use for the algorithm.
        /// </summary>
        /// <returns>A valid file path</returns>
        static string InquireExistingFileName()
        {
            string answer;
            string question = "(Relative paths assume 'Generated-Data' folder as base path.)\nEnter an existing file:  ";
            answer = Inquire(question);

            do
            {
                if (File.Exists(answer)) break;
	            answer = Inquire(String.Format("Hmmm.  Can't seem to find that.  Let's try again. \n{0}",
                    question));    
            } while (true);
            return answer;
        }


        /// <summary>
        /// Solicits information about how many numbers should be generated in the file.
        /// </summary>
        /// <returns>How many numbers to generate.</returns>
        static uint InquireNumbers()
        {
            string answer = "";
            uint numbers = 0;
            string question = "How many numbers should we generate in this file?  ";
            answer = Inquire(question);
            do
            {
                try
                {
                    numbers = Convert.ToUInt32(answer);
                    
                    // Limit to 10000 just cause.
                    if (numbers <= 0)
                        throw new InvalidDataException("The number provided must be a positive integer.  Let's try again...");
                    else if (numbers > 10000)
                    {
                        numbers = 10000;
                        Console.WriteLine("Okay, we'll do {0} then! ;-)", numbers);
                    }
                    else
                        Console.WriteLine("I was just thinking {0} numbers would be perfect!  \nI like the way you think. :-D", numbers);
                    
                    break;
                }
                catch(InvalidDataException ex)
                {
                    answer = Inquire(String.Format("{0}\n{1}", ex.Message, question));
                    continue;
                }
                catch (Exception)
                {
                    answer = Inquire(String.Format(
                        "(psst...  I'm Looking for a number)\n{0}", 
                        question));
                    continue;
                }
            } while (true);
            return numbers;
        }

        
        /// <summary>
        /// Generates a Transformer's quote in light of "Optimus Prime" and this wonder exercise!
        /// </summary>
        /// <returns>A wonderful quote to brighten the day.</returns>
        static string GetQuote()
        {
            Random rnd = new Random();
            int i = rnd.Next(0, 9);
            string[] quotes = 
            {
                "Fate rarely calls upon us at a moment of our choosing.",
                "Freedom is the right of all sentient beings.",
                "Sometimes even the wisest of men and machines can be in error.",
                "We lost a great comrade, but gained new ones. Thank you, all of you. You honor us with your bravery.",
                "Like us, there’s more to them than meets the eye.",
                "I will accept this burden with all that I am!",
                "There’s a thin line between being a hero and being a memory.",
                "Until that day… till all are one.",
                "It’s been an honor serving with you all."
            };
            return quotes[i];
        }


        /// <summary>
        /// Generates a file name based on Transformer characters.
        /// </summary>
        /// <returns>A File Name</returns>
        static string GetRandomFileName()
        {
            Random rnd = new Random();
            int i = rnd.Next(0, 11);
            string[] names_1 = 
            {
                "Return of ", 
                "Rebirth of ",
                "Dawn of ",
                "The Faces of ",
                "Ultimate Weapon of ",
                "Fight with ",
                "Flee to ",
                "The Age of ",
                "Wisdom of ",
                "Zealous ",
                "Beastly "
            };

            int j = rnd.Next(0, 10);
            string[] names_2 = 
            {
                "Optimus Prime", 
                "Megatron",
                "Bumblebee",
                "Ultra Magnus",
                "Ratchet",
                "Teletraan",
                "Jazz",
                "Thundercracker",
                "Brawl",
                "Bonecrusher",
                "Tripticon"
            };
            return String.Concat(names_1[i], names_2[j]);
        }


        /// <summary>
        /// Helper function to ask for user input.
        /// </summary>
        /// <param name="inquiry">A question to be displayed to the user.</param>
        /// <returns>An answer to the inquiry.</returns>
        static string Inquire(string inquiry, int cursorTop = 37)
        {
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(inquiry);
            string result = Console.ReadLine();
            int count = inquiry.Count(f => f == '\n');
            ClearCurrentConsoleLine(cursorTop, count);
            return result;
        }


        /// <summary>
        /// Helper function to clear current console line.
        /// </summary>
        /// <param name="cursorTop">Cursor Position to begin with clearing.</param>
        /// <param name="lines">The number of lines to clear.</param>
        static void ClearCurrentConsoleLine(int cursorTop, int lines)
        {
            Console.SetCursorPosition(0, cursorTop);
            for (int i = 0; i <= lines; i++)
            {
                Console.SetCursorPosition(0, cursorTop + i);
                Console.Write(new string(' ', Console.WindowWidth));
            } 
            Console.SetCursorPosition(0, cursorTop);
        }


        /// <summary>
        /// Establishes the working directory for the program.
        /// </summary>
        static void InitializeWorkingDirectory()
        {
            // Set the working directory for relative files passed to this program.
            Directory.SetCurrentDirectory(
                String.Format(
                    @"{0}\Generated-Data\",
                    Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName
                ));
        }
    }
}
