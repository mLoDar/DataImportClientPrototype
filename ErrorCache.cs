using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImportClientPrototype
{
    internal class ErrorCache
    {
        internal void Start()
        {
            int startIndex = 0;
            int numberOfElementsToPrint = 10;



            Console.Title = "DHF - ImportClient";
            Console.OutputEncoding = Encoding.UTF8;

            Console.CursorVisible = false;

            Console.Clear();



        LabelDrawUi:

            Console.SetCursorPosition(0, 4);

            

            List<string> errorCache = new List<string>()
            {
                "File not found: 'config.yaml'. Check if the file exists and the path is correct.",
                "Access denied: insufficient permissions to modify 'settings.json'.",
                "Unexpected end of JSON input at line 4.",
                "Null pointer exception encountered in module 'DataParser' at line 243.",
                "Failed to open database: SQLite file is locked.",
                "Invalid user input: 'username' field cannot be empty.",
                "Warning: disk space running low, less than 5% remaining on drive C:.",
                "Error: unable to establish a secure SSL connection to 'payments.example.com'.",
                "Database connection failed: maximum retries exceeded.",
                "Invalid file format: expected '.csv', but received '.txt'.",
                "Service unavailable: 'database.example.com' is down for maintenance.",
                "Warning: uncommitted changes detected in the repository.",
                "Failed to initialize module 'PaymentGateway': required library missing.",
                "Checksum mismatch: the file 'backup.zip' may be corrupted.",
                "Operation aborted: concurrent access to resource 'user_data' detected.",
                "File not found: 'config.yaml'. Check if the file exists and the path is correct.",
                "Access denied: insufficient permissions to modify 'settings.json'.",
                "Connection timeout: unable to reach server 'api.example.com' after 30 seconds.",
                "Null pointer exception encountered in module 'DataParser' at line 243.",
                "Failed to open database: SQLite file is locked.",
                "Invalid user input: 'username' field cannot be empty.",
                "Warning: disk space running low, less than 5% remaining on drive C:.",
                "Error: unable to establish a secure SSL connection to 'payments.example.com'.",
                "Database connection failed: maximum retries exceeded.",
                "Invalid file format: expected '.csv', but received '.txt'.",
                "Unexpected end of JSON input at line 4.",
                "Unable to locate external dependency: 'libXYZ.so'.",
                "Division by zero error in function 'calculateDiscount()'.",
                "File read error: unexpected EOF reached in 'data.csv'.",
                "Memory allocation failed: insufficient RAM available.",
                "Warning: deprecated API used in 'fetchData()' method.",
            };

            

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("              ┓       ┏┓                                       ");
            Console.WriteLine("              ┃ ┏┓┏╋  ┣ ┏┓┏┓┏┓┏┓┏                              ");
            Console.WriteLine("              ┗┛┗┻┛┗  ┗┛┛ ┛ ┗┛┛ ┛                              ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("             ──────────────────────────                        ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             ┌────────────────────────────────────────────────────────────────────────────────────────────┐");



            int allowedMaxErrorLength = 82;

            for (int j = startIndex; j < startIndex + numberOfElementsToPrint && j < errorCache.Count; j++)
            {
                string currError = errorCache[j];

                if (currError.Length > allowedMaxErrorLength)
                {
                    currError = currError.Substring(0, allowedMaxErrorLength - 4);
                    currError += " ...";
                }

                currError = currError.PadRight(allowedMaxErrorLength);

                Console.WriteLine($"             │ [{j + 1:D2}.] - {currError} │");
            }



            Console.WriteLine("             └────────────────────────────────────────────────────────────────────────────────────────────┘");
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("             ┌ Use 'Backspace' to return                       ");
            Console.WriteLine("             └────────────────────────────                     ");



            bool enterKeyPressed = false;
            ConsoleKey pressedKey = Console.ReadKey(true).Key;

            switch (pressedKey)
            {
                case ConsoleKey.DownArrow:
                    if (startIndex + 1 <= errorCache.Count - numberOfElementsToPrint)
                    {
                        startIndex += 1;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (startIndex - 1 >= 0)
                    {
                        startIndex -= 1;
                    }
                    break;

                case ConsoleKey.Escape:
                    return;

                case ConsoleKey.Backspace:
                    return;

                default:
                    break;
            }


            goto LabelDrawUi;
        }
    }
}
