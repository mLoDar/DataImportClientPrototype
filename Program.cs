using System.Text;





namespace DataImportClientPrototype
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

        private static readonly int _countOfLastExportErrors = 0;


        private static int _navigationXPosition = 1;
        private static int _countOfMenuOptions = 5;


        static void Main()
        {
        LabelMethodEntry:

            

            Console.Title = "Digital HTL Footprint";
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            Console.Clear();



        LabelDrawUi:

            Console.SetCursorPosition(0, 4);



            string stateWeather = UiTextWeather();
            string stateElectricity = UiTextElectricity();
            string stateDistrictHeat = UiTextDistrictHeat();
            string statePhotovoltaic = UiTextPhotovoltaic();

            string stateLastExport = $"\x1B[9{(_countOfLastExportErrors > 0 ? "1" : "2")}m{_countOfLastExportErrors} {(_countOfLastExportErrors > 1 || _countOfLastExportErrors <= 0 ? "Errors" : "Error")}\x1B[97m";



            Console.WriteLine("              {0} {1} {2}                                       ", "\u001b[91m┳┓•  •   ┓", "\u001b[97m┓┏┏┳┓┓ ", "\u001b[91m┏┓         •   \u001b[97m");
            Console.WriteLine("              {0} {1} {2}                                       ", "\u001b[91m┃┃┓┏┓┓╋┏┓┃", "\u001b[97m┣┫ ┃ ┃ ", "\u001b[91m┣ ┏┓┏┓╋┏┓┏┓┓┏┓╋\u001b[97m");
            Console.WriteLine("              {0} {1} {2}                                       ", "\u001b[91m┻┛┗┗┫┗┗┗┻┗", "\u001b[97m┛┗ ┻ ┗┛", "\u001b[91m┻ ┗┛┗┛┗┣┛┛ ┗┛┗┗\u001b[97m");
            Console.WriteLine("              {0} {1} {2}                                       ", "\u001b[91m    ┛     ", "\u001b[97m       ", "\u001b[91m       ┛       \u001b[97m");
            Console.WriteLine("             ─────────────────────────────────────────");
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             ┌ Modules                           State         ");
            Console.WriteLine("             └────────────────┐                  ┌───┐         ");
            Console.WriteLine("             {0} Weather                         │ {1}         ", $"[\u001b[91m{(_navigationXPosition == 1 ? ">" : " ")}\u001b[97m]", stateWeather);
            Console.WriteLine("             {0} Electricity                     │ {1}         ", $"[\u001b[91m{(_navigationXPosition == 2 ? ">" : " ")}\u001b[97m]", stateElectricity);
            Console.WriteLine("             {0} DistrictHeat                    │ {1}         ", $"[\u001b[91m{(_navigationXPosition == 3 ? ">" : " ")}\u001b[97m]", stateDistrictHeat);
            Console.WriteLine("             {0} Photovoltaic                    │ {1}         ", $"[\u001b[91m{(_navigationXPosition == 4 ? ">" : " ")}\u001b[97m]", statePhotovoltaic);
            Console.WriteLine("                                                 └───┘         ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             ┌ Application                                     ");
            Console.WriteLine("             └────────────────┐                                 ");
            Console.WriteLine("             {0} Settings                                   ", $"[\u001b[91m{(_navigationXPosition == 5 ? ">" : " ")}\u001b[97m]");



            bool enterKeyPressed = false;
            ConsoleKey pressedKey = Console.ReadKey(true).Key;

            switch (pressedKey)
            {
                case ConsoleKey.DownArrow:
                    if (_navigationXPosition + 1 <= _countOfMenuOptions)
                    {
                        _navigationXPosition += 1;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (_navigationXPosition - 1 >= 1)
                    {
                        _navigationXPosition -= 1;
                    }
                    break;

                case ConsoleKey.Enter:
                    enterKeyPressed = true;
                    break;

                default:
                    break;
            }



            if (enterKeyPressed == false)
            {
                goto LabelDrawUi;
            }

            enterKeyPressed = false;



            switch (_navigationXPosition)
            {
                case 1:
                    
                    break;

                case 2:

                    break;

                case 3:

                    break;

                case 4:

                    break;

                case 5:
                    
                    break;
            }

            goto LabelDrawUi;
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