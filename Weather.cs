using System.Text;
using System.Globalization;





namespace DesktopClientPrototype
{
    internal class Weather
    {
        private static bool _serviceRunning = false;
        private static int _countOfErrors = 634;





        internal static void Start()
        {
        LabelMethodEntry:



            Console.Title = "Digital Electronic Fingerprint";
            Console.OutputEncoding = Encoding.UTF8;

            Console.Clear();
            Console.SetCursorPosition(0, 4);



            string lastImport = "09.04.2024 - 19:30:00";
            string lastLogFileEntry = "09.04.2024 - 19:30:00";

            lastLogFileEntry = FormatLastLogEntry(lastLogFileEntry);

            string formatServiceRunning = FormatServiceRunning(_serviceRunning);
            string formatError = FormatErrorCount(_countOfErrors);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("             ┓ ┏     ┓     ");
            Console.WriteLine("             ┃┃┃┏┓┏┓╋┣┓┏┓┏┓");
            Console.WriteLine("             ┗┻┛┗ ┗┻┗┛┗┗ ┛ ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("             ──────────────────");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             │  Last import:   {0}  │                          ", lastImport);
            Console.WriteLine("             └────────────────────────────────────────┘        ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             │  OPTIONS                           State");
            Console.WriteLine("             └───────────                         ┌───┐");
            Console.WriteLine("             [1] Open log file                    │ {0}", lastLogFileEntry);
            Console.WriteLine("             [2] Start service                    │ {0}", formatServiceRunning);
            Console.WriteLine("             [3] Clear errors                     │ {0}", formatError);
            Console.WriteLine("                                                  └───┘ ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             [E] Return                                        ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.Write("             > ");



            char pressedKey = Console.ReadKey(true).KeyChar;

            switch (pressedKey)
            {
                case (char)ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;

                case '1':
                    break;

                case '2':
                    if (_serviceRunning == false)
                    {
                        _serviceRunning = true;
                    }
                    break;

                case '3':
                    if (_countOfErrors > 0)
                    {
                        _countOfErrors = 0;
                    }
                    break;

                case 'e':
                    return;
            }

            goto LabelMethodEntry;
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