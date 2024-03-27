using System.Text;
using static DesktopClientPrototype.Program;





namespace DesktopClientPrototype
{
    internal class Program
    {
        internal struct ErrorCounts
        {
            internal int weather;
            internal int electricity;
            internal int districtHeat;
            internal int photovoltaic;
        }

        internal struct ServiceState
        {
            internal string weather;
            internal string electricity;
            internal string districtHeat;
            internal string photovoltaic;
        }



        static ErrorCounts errorCounts = new()
        {
            weather = 0,
            electricity = 0,
            districtHeat = 23,
            photovoltaic = 0
        };

        static ServiceState serviceState = new()
        {
            weather = "running",
            electricity = "stopped",
            districtHeat = "error",
            photovoltaic = "undefined"
        };

        static string dateTimeOfLastExport = "26.03.2024 - 16:10:23";
        static int countOfLastExportErrors = 0;

        



        static void Main()
        {
        LabelMethodEntry:

            

            Console.Title = "Digital Electronic Fingerprint";
            Console.OutputEncoding = Encoding.UTF8;

            Console.Clear();
            Console.SetCursorPosition(0, 4);



            string stateWeather = UiTextWeather();
            string stateElectricity = UiTextElectricity();
            string stateDistrictHeat = UiTextDistrictHeat();
            string statePhotovoltaic = UiTextPhotovoltaic();

            string stateLastExport = $"\x1B[9{(countOfLastExportErrors > 0 ? "1" : "2")}m{countOfLastExportErrors} {(countOfLastExportErrors > 1 || countOfLastExportErrors <= 0 ? "Errors" : "Error")}\x1B[97m";



            Console.WriteLine("             {0} {1} {2}                                       ", "\u001b[91m┳┓•  •   ┓", "\u001b[97m┏┓┓          • ", "\u001b[91m┏┓•            •   \u001b[97m");
            Console.WriteLine("             {0} {1} {2}                                       ", "\u001b[91m┃┃┓┏┓┓╋┏┓┃", "\u001b[97m┣ ┃┏┓┏╋┏┓┏┓┏┓┓┏", "\u001b[91m┣ ┓┏┓┏┓┏┓┏┓┏┓┏┓┓┏┓╋\u001b[97m");
            Console.WriteLine("             {0} {1} {2}                                       ", "\u001b[91m┻┛┗┗┫┗┗┗┻┗", "\u001b[97m┗┛┗┗ ┗┗┛ ┗┛┛┗┗┗", "\u001b[91m┻ ┗┛┗┗┫┗ ┛ ┣┛┛ ┗┛┗┗\u001b[97m");
            Console.WriteLine("             {0} {1} {2}                                       ", "\u001b[91m    ┛     ", "\u001b[97m               ", "\u001b[91m      ┛    ┛       \u001b[97m");
            Console.WriteLine("             ──────────────────────────────────────────────────");
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             │ IMPORT                            State         ");
            Console.WriteLine("             └─────────                          ┌───┐         ");
            Console.WriteLine("             [1] Weather                         │ {0}         ", stateWeather);
            Console.WriteLine("             [2] Electricity                     │ {0}         ", stateElectricity);
            Console.WriteLine("             [3] DistrictHeat                    │ {0}         ", stateDistrictHeat);
            Console.WriteLine("             [4] Photovoltaic                    │ {0}         ", statePhotovoltaic);
            Console.WriteLine("                                                 └───┘         ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             │ EXPORT                                          ");
            Console.WriteLine("             └─────────                                        ");
            Console.WriteLine("             [5] Last created at '{0}'                         ", dateTimeOfLastExport);
            Console.WriteLine("                 with: {0}                                     ", stateLastExport);
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
                    break;

                case '3':
                    break;

                case '4':
                    break;

                case '5':
                    break;
            }
            
            goto LabelMethodEntry;
        }

        private static string UiTextWeather()
        {
            string currentState = "\u001b[96m?\u001b[97m │ \u001b[96mUnknown\u001b[97m";

            switch (serviceState.weather)
            {
                case "error":
                    currentState = $"\x1B[91mx\x1B[97m │ \u001b[91m{errorCounts.weather} {(errorCounts.weather > 1 ? "Errors" : "Error")} \u001b[97m";
                    break;

                case "stopped":
                    currentState = "\x1B[93mo\x1B[97m │ \u001b[93mStopped\u001b[97m";
                    break;

                case "running":
                    currentState = "\x1B[92m√\x1B[97m │ \u001b[92mRunning\u001b[97m";
                    break;

                default:
                    break;
            }

            return currentState;
        }

        private static string UiTextElectricity()
        {
            string currentState = "\u001b[96m?\u001b[97m │ \u001b[96mUnknown\u001b[97m";

            switch (serviceState.electricity)
            {
                case "error":
                    currentState = $"\x1B[91mx\x1B[97m │ \u001b[91m{errorCounts.electricity} {(errorCounts.electricity > 1 ? "Errors" : "Error")} \u001b[97m";
                    break;

                case "stopped":
                    currentState = "\x1B[93mo\x1B[97m │ \u001b[93mStopped\u001b[97m";
                    break;

                case "running":
                    currentState = "\x1B[92m√\x1B[97m │ \u001b[92mRunning\u001b[97m";
                    break;

                default:
                    break;
            }

            return currentState;
        }

        private static string UiTextDistrictHeat()
        {
            string currentState = "\u001b[96m?\u001b[97m │ \u001b[96mUnknown\u001b[97m";

            switch (serviceState.districtHeat)
            {
                case "error":
                    currentState = $"\x1B[91mx\x1B[97m │ \u001b[91m{errorCounts.districtHeat} {(errorCounts.districtHeat > 1 ? "Errors" : "Error")} \u001b[97m";
                    break;

                case "stopped":
                    currentState = "\x1B[93mo\x1B[97m │ \u001b[93mStopped\u001b[97m";
                    break;

                case "running":
                    currentState = "\x1B[92m√\x1B[97m │ \u001b[92mRunning\u001b[97m";
                    break;

                default:
                    break;
            }

            return currentState;
        }

        private static string UiTextPhotovoltaic()
        {
            string currentState = "\u001b[96m?\u001b[97m │ \u001b[96mUnknown\u001b[97m";

            switch (serviceState.photovoltaic)
            {
                case "error":
                    currentState = $"\x1B[91mx\x1B[97m │ \u001b[91m{errorCounts.photovoltaic} {(errorCounts.photovoltaic > 1 ? "Errors" : "Error")} \u001b[97m";
                    break;

                case "stopped":
                    currentState = "\x1B[93mo\x1B[97m │ \u001b[93mStopped\u001b[97m";
                    break;

                case "running":
                    currentState = "\x1B[92m√\x1B[97m │ \u001b[92mRunning\u001b[97m";
                    break;

                default:
                    break;
            }

            return currentState;
        }
    }
}