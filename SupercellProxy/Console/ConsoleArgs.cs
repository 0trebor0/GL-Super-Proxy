using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupercellProxy
{
    class ConsoleArgs
    {
        private readonly List<string> Arguments;

        /// <summary>
        /// The ConsoleArgs constructor 
        /// </summary>
        public ConsoleArgs(string[] args)
        {
            // string[] -> List<string>
            Arguments = new List<string>(args);
        }

        /// <summary>
        /// Parses console arguments
        /// </summary>
        public void Parse()
        {
            try
            {
                if (Arguments.Count != 1)
                    return;

                string Arg = Arguments[0];

                if (Arg == "-help" || Arg == "/help" || Arg == "help")
                {
                    // HELP parameter
                    Console.WriteLine("=> SupercellProxy - Argument usage <=");
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("-help | /help | help -> Displays this.");
                    Console.WriteLine("-ver  | /ver  | ver  -> Shows detailed version information");
                    Console.WriteLine("-apk  | /apk  | apk  -> Downloads latest, modded game clients");
                    //Console.WriteLine("-ui   | /ui   | ui   -> Starts the proxy with a user interface");
                }

                else if (Arg == "-ver" || Arg == "/ver" || Arg == "ver")
                {
                    // VER parameter
                    Console.WriteLine("=> SupercellProxy - Version information <=");
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("SupercellProxy Public Version " + Helper.AssemblyVersion);
                    Console.WriteLine("Copyright © 2016, InfinityModding");
                    Console.WriteLine("Licensed under the MIT license:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("https://opensource.org/licenses/MIT/");
                    Console.ResetColor();
                }

                else if (Arg == "-apk" || Arg == "/apk" || Arg == "apk")
                {
                    // APK parameter
                    Console.WriteLine("=> SupercellProxy - APK Downloader <=");
                    Console.Write(Environment.NewLine);
                    APK_Downloader.Start();
                }

                else if (Arg == "-ui" || Arg == "/ui" || Arg == "ui")
                {
                    /* UI parameter
                    Console.WriteLine("=> SupercellProxy - User Interface <=");
                    Helper.StartInterface(); */
                    throw new NotSupportedException("The UI is under development and not ready.");
                }

                else
                {
                    // UNKNOWN parameter
                    Console.WriteLine("=> SupercellProxy <=");
                    Console.Write(Environment.NewLine);
                    Console.WriteLine(Arg + ": Unknown parameter.");
                }
                Program.Kill();
            }
            catch(Exception ex)
            {
                Logger.Log("Failed to parse console argument (" + ex.GetType() + ")!", LogType.EXCEPTION);
                Program.WaitAndKill();
            }
        }
    }
}