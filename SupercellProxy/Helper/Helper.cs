using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupercellProxy
{
    class Helper
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// Returns the local network IP in a proper format
        /// </summary>
        public static IPAddress LocalNetworkIP
        {
            get
            {
                try
                {
                    using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                    {
                        socket.Connect("10.0.2.4", 65530);
                        return (socket.LocalEndPoint as IPEndPoint).Address;
                    }
                }
                catch
                {
                    return IPAddress.Parse("127.0.0.1");
                }                
            }
        }

        /// <summary>
        /// Returns a random console color
        /// </summary>
        public static ConsoleColor ChooseRandomColor()
        {
            var randomIndex = new Random().Next(0, Enum.GetNames(typeof(ConsoleColor)).Length);
            var color = (ConsoleColor)randomIndex;

            if (color != ConsoleColor.Black)
                return (ConsoleColor)randomIndex;
            else
                return ConsoleColor.Green;
        }

        /// <summary>
        /// Returns Proxy-Version in the following format:
        /// v1.2.3
        /// </summary>
        public static string AssemblyVersion
        {
            get
            {
                return "v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Remove(5);
            }
        }

        /// <summary>
        /// Returns the license for public use
        /// </summary>
        public static string License
        {
            get
            {
                return @"
                    Permission is hereby granted, free of charge, to any person obtaining a copy of the provided software and associated documentation files, 
                    to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, and/or distribute the software, 
                    and to permit persons to whom the Software is furnished to do so, subject to the following conditions: 
                    THE PROVIDED SOFTWARE IS AS IS, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
                    WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
                ";
            }      
        }

        /// <summary>
        /// Returns the actual time in a localized format
        /// </summary>
        public static string ActualTime
        {
            get
            {
                return DateTime.Now.ToString();
            }
        }

        /// <summary>
        /// Checks if the proxy runs on Mono
        /// </summary>
        public static void CheckMono()
        {
            if (Type.GetType("Mono.Runtime") != null)
            {
                Logger.Log("This proxy does not support Mono and will likely throw exceptions!", LogType.WARNING);
                Logger.Log("Please proceed with caution!", LogType.WARNING);
                Console.WriteLine("Proceed (y/n)?");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        // Continue
                        break;
                    case ConsoleKey.N:
                        // Exit
                        Program.Kill();
                        break;
                    default:
                        // Exit
                        Program.Kill();
                        break;
                }
            }         
        }   

        /// <summary>
        /// Displays a "SupercellProxy" ASCII art
        /// </summary>
        public static void DisplayAsciiArt()
        {
            Console.ForegroundColor = Helper.ChooseRandomColor();
            Console.WriteLine(@"
                   _____                                 ____
                  / ___/__  ______  ___  _____________  / / /
                  \__ \/ / / / __ \/ _ \/ ___/ ___/ _ \/ / / 
                 ___/ / /_/ / /_/ /  __/ /  / /__/  __/ / /  
                /____/\__,_/ .___/\___/_/   \___/\___/_/_/   
                          /_/____                            
                            / __ \_________  _  ____  __     
                           / /_/ / ___/ __ \| |/_/ / / /     
                          / ____/ /  / /_/ />  </ /_/ /      
                         /_/   /_/   \____/_/|_|\__, /       
                                               /____/               
                ");
            Console.ResetColor();
        }     

        /// <summary>
        /// Starts the proxy UI
        /// </summary>
        [STAThread]
        public static void StartInterface()
        {
            HideConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            Application.Run(new Loader());
        }

        /// <summary>
        /// Hides the cmd window
        /// </summary>
        public static void HideConsole()
        {
            ShowWindow(GetConsoleWindow(), 0);
        }     
    }
}
