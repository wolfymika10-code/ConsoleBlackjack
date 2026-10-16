namespace ConsoleBlackjack
{
    class Program
    {
        // DISCORD RPC

        // i cant find any for .NET 10.0

        // RPC END

        // variable declarations
        public static bool REALISTIC_CARD_DECK = true;

        public static readonly List<string> deck = new List<string> { "A", "A", "A", "A", "2", "2", "2", "2", "3", "3", "3", "3", "4", "4", "4", "4", "5", "5", "5", "5", "6", "6", "6", "6", "7", "7", "7", "7", "8", "8", "8", "8", "9", "9", "9", "9", "10", "10", "10", "10", "J", "J", "J", "J", "Q", "Q", "Q", "Q", "K", "K", "K", "K" };

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

        static T GetAndRemove<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                throw new ArgumentException("There isn't anything in the list!");
            }
            int i = Random.Shared.Next(0, list.Count);
            T obj = list[i];
            list.RemoveAt(i);
            return obj;
        }

        // end of helpers


        // game stuff
        static void Game()
        {
            List<string> player_cards = new List<string>();
            List<string> dealer_cards = new List<string>();
            List<string> localdeck = new List<string>(deck);

            while (true)
            {
                player_cards.Add(GetAndRemove(localdeck));
                // unfinished at the moment
            }

            Main();
        }

        static void Settings()
        {
            while (true)
            {
                int pick = ShowMenu("Settings", "does nothing at the moment", new string[] { $"RealisticCardDeck ({REALISTIC_CARD_DECK})", "Exit" });
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
            int option = ShowMenu("Blackjack", "Welcome to the Blackjack main menu!\nHere, you can tweak options, or get a game running!", new string[] { "START", "Settings", "Exit" });
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