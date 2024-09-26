using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImportClientPrototype
{
    internal class Settings
    {
        public void Start()
        {
            int navigationXPosition = 1;
            int countOfMenuOptions = 5;



            Console.Title = "DHF - ImportClient";
            Console.OutputEncoding = Encoding.UTF8;

            Console.CursorVisible = false;

            Console.Clear();


        LabelDrawUi:

            Console.SetCursorPosition(0, 4);




            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("              ┏┓    •                                          ");
            Console.WriteLine("              ┗┓┏┓╋╋┓┏┓┏┓┏                                     ");
            Console.WriteLine("              ┗┛┗ ┗┗┗┛┗┗┫┛                                     ");
            Console.WriteLine("                        ┛                                      ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("             ────────────────                                  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             ┌ Adjust settigns                                 ");
            Console.WriteLine("             └──────────────────────┐                          ");
            Console.WriteLine("             {0} Open settings file                            ", $"[\u001b[91m{(navigationXPosition == 1 ? ">" : " ")}\u001b[97m]");
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             ┌ Error handling                                  ");
            Console.WriteLine("             └──────────────────────┐                          ");
            Console.WriteLine("             {0} Show last errors                              ", $"[\u001b[91m{(navigationXPosition == 2 ? ">" : " ")}\u001b[97m]");
            Console.WriteLine("             {0} Show error cache                              ", $"[\u001b[91m{(navigationXPosition == 3 ? ">" : " ")}\u001b[97m]");
            Console.WriteLine("             {0} Open error file                               ", $"[\u001b[91m{(navigationXPosition == 4 ? ">" : " ")}\u001b[97m]");
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             ┌ Application                                     ");
            Console.WriteLine("             └──────────────────────┐                          ");
            Console.WriteLine("             {0} MainMenu                                      ", $"[\u001b[91m{(navigationXPosition == 5 ? ">" : " ")}\u001b[97m]");



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
                    // Open settings file
                    Process.Start("notepad");
                    break;

                case 2:
                    // Redirect to new console menu
                    break;

                case 3:
                    // Open error cache in file
                    Process.Start("notepad");
                    break;

                case 4:
                    // Open entire error log
                    Process.Start("notepad");
                    break;

                case 5:
                    Console.Clear();
                    return;
            }

            goto LabelDrawUi;
        }
    }
}
