using System.Net.Security;
using System.Runtime.InteropServices;

namespace ConsoleBlackjack
{
    class Program
    {
        // DISCORD RPC

        // i cant find any for .NET 10.0

        // RPC END

        // variable declarations
        public static bool REALISTIC_CARD_DECK = true; // made static

        // helpers
        static int ShowMenu(string title, string body, string[] options)
        {
            int selection = 0;
            Console.Clear();
            Console.WriteLine($"{title}\n\n{body}");
            Console.WriteLine();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selection)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"> {options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"> {options[i]}");
                }
            }
            while (true)
            {
                ConsoleKeyInfo Choise = Console.ReadKey(false);
                if (Choise.Key == ConsoleKey.DownArrow)
                {
                    selection++;

                    if (selection >= options.Length)
                    {
                        selection = 0;
                    }
                }
                else if (Choise.Key == ConsoleKey.UpArrow)
                {
                    selection--;

                    if (selection < 0)
                    {
                        selection = options.Length - 1;
                    }
                }
                else if (Choise.Key == ConsoleKey.Enter)
                {
                    return selection;
                }
                Console.Clear();
                Console.WriteLine($"{title}\n\n{body}");
                Console.WriteLine();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selection)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"> {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"> {options[i]}");
                    }
                }
            }
        }

        // end of helpers


        // game stuff
        static void Game()
        {
            int[] cards = new int[0];// fixed array initialization

            Main();
        }

        static void Settings()
        {
            while (true)
            {
                int pick = ShowMenu("Settings", "wip", new string[] { $"RealisticCardDeck ({REALISTIC_CARD_DECK})", "Exit" }); // fixed literal
                if (pick == 0)
                {
                    REALISTIC_CARD_DECK = !REALISTIC_CARD_DECK;
                }
                else if (pick == 1)
                {
                    break;
                }
            }
            Console.ReadKey(false);
            Main();
        }

        // main program
        static void Main()
        {
            int option = ShowMenu("Blackjack", "Welcome to the Blackjack main menu!\nHere, you can tweak options, or get a game running!", new string[] { "START", "Settings", "Exit" }); // fixed literal
            Console.Clear();
            if (option == 0)
            {
                Game();
            }
            else if (option == 1)
            {
                Settings();
            }
            else if (option == 2)
            {
                Environment.Exit(0);
            }
        }
    }
}