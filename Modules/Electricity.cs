using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImportClientPrototype.Modules
{
    internal class Electricity
    {
        private static bool _serviceRunning = false;
        private static int _countOfErrors = 634;





        internal void Start()
        {
            int navigationXPosition = 1;
            int countOfMenuOptions = 4;

            Console.Title = "DHF - ImportClient";
            Console.OutputEncoding = Encoding.UTF8;

            Console.CursorVisible = false;

            Console.Clear();



        LabelDrawUi:

            string lastImport = "09.04.2024 - 19:30:00";
            string lastLogFileEntry = "25.09.2024 - 08:15:00";

            Console.SetCursorPosition(0, 4);

/*







 */



            lastLogFileEntry = FormatLastLogEntry(lastLogFileEntry);

            string formatServiceRunning = FormatServiceRunning(_serviceRunning);
            string formatError = FormatErrorCount(_countOfErrors);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("              ┏┓┓      • •                                     ");
            Console.WriteLine("              ┣ ┃┏┓┏╋┏┓┓┏┓╋┓┏                                  ");
            Console.WriteLine("              ┗┛┗┗ ┗┗┛ ┗┗┗┗┗┫                                  ");
            Console.WriteLine("                            ┛                                  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("             ────────────────────                              ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             │   Last import:  {0}   │                         ", lastImport);
            Console.WriteLine("             └─────────────────────────────────────────┘       ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             ┌ Options                             State       ");
            Console.WriteLine("             └──────────────────────┐              ┌───┐       ");
            Console.WriteLine("             {0} Open log file                     │ {1}       ", $"[\u001b[91m{(navigationXPosition == 1 ? ">" : " ")}\u001b[97m]", lastLogFileEntry);
            Console.WriteLine("             {0} {1}                     │ {2}       ", $"[\u001b[91m{(navigationXPosition == 2 ? ">" : " ")}\u001b[97m]", $"{(_serviceRunning ? "Stop service " : "Start service")}", formatServiceRunning);
            Console.WriteLine("             {0} Clear errors                      │ {1}       ", $"[\u001b[91m{(navigationXPosition == 3 ? ">" : " ")}\u001b[97m]", formatError);
            Console.WriteLine("                                                   └───┘       ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             ┌ Application                                     ");
            Console.WriteLine("             └──────────────────────┐                          ");
            Console.WriteLine("             {0} MainMenu                                      ", $"[\u001b[91m{(navigationXPosition == 4 ? ">" : " ")}\u001b[97m]");



            bool enterKeyPressed = false;
            ConsoleKey pressedKey = Console.ReadKey(true).Key;

            switch (pressedKey)
            {
                case ConsoleKey.DownArrow:
                    if (navigationXPosition + 1 <= countOfMenuOptions)
                    {
                        navigationXPosition += 1;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (navigationXPosition - 1 >= 1)
                    {
                        navigationXPosition -= 1;
                    }
                    break;

                case ConsoleKey.Enter:
                    enterKeyPressed = true;
                    break;

                case ConsoleKey.Backspace:
                    Console.Clear();
                    return;

                default:
                    break;
            }



            if (enterKeyPressed == false)
            {
                goto LabelDrawUi;
            }

            enterKeyPressed = false;



            switch (navigationXPosition)
            {
                case 1:
                    // Open log file
                    Process.Start("notepad");
                    break;

                case 2:
                    _serviceRunning = !_serviceRunning;
                    break;

                case 3:
                    _countOfErrors = 0;
                    break;

                case 4:
                    Console.Clear();
                    return;
            }

            goto LabelDrawUi;
        }



        static string FormatLastLogEntry(string dateTime)
        {
            if (!DateTime.TryParseExact(dateTime, "dd.MM.yyyy - HH:mm:ss", null, DateTimeStyles.None, out DateTime providedDateTime))
            {
                return "\u001b[96m?\u001b[97m │ \u001b[96mUnknown\u001b[97m";
            }

            if (providedDateTime > DateTime.Now)
            {
                return "\u001b[96m?\u001b[97m │ \u001b[96mUnknown\u001b[97m";
            }



            TimeSpan difference = DateTime.Now - providedDateTime;

            if (difference.TotalMinutes < 30)
            {
                return $"\u001b[92m√\u001b[97m │ Updated at '\u001b[92m{dateTime}\u001b[97m'";

            }
            else if (difference.TotalMinutes >= 30 && difference.TotalMinutes < 60)
            {
                return $"\u001b[93mo\u001b[97m │ Updated at '\u001b[93m{dateTime}\u001b[97m'";
            }
            else
            {
                return $"\u001b[91mx\u001b[97m │ Updated at '\u001b[91m{dateTime}\u001b[97m'";
            }
        }

        static string FormatServiceRunning(bool serviceRunning)
        {
            if (serviceRunning == true)
            {
                return "\u001b[92m√\u001b[97m │ \u001b[92mRunning\u001b[97m";
            }

            return "\u001b[93mo\u001b[97m │ \u001b[93mStopped\u001b[97m";
        }

        static string FormatErrorCount(int countOfErrors)
        {
            if (countOfErrors > 0)
            {
                return $"\u001b[91mx\u001b[97m │ \u001b[91m{countOfErrors} {(countOfErrors > 1 ? "Errors" : "Error")}\u001b[97m";
            }

            return "\u001b[92m√\u001b[97m │ \u001b[92mCleared\u001b[97m";
        }
    }
}
