using System;

namespace gladiatorGame2._0
{
    class Menu
    {
        public static Character hero;
        public static string name;
        public static Light lightChar = new Light(name);
        public static Medium medChar = new Medium(name);
        public static Heavy heavyChar = new Heavy(name);

        public void Print(string msg, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public void Title(string title)
        {
            Print("********" + title + "********");
        }

        public string Request(string paramater)
        {
            Console.Write(paramater);
            string input = Console.ReadLine();
            return input;
        }

        public void Greet()
        {
            Print("Welcome, to the Grand Arena!", ConsoleColor.Green);
            Print("In here, you will fight for your life and glory!", ConsoleColor.Green);
            Print("If you succeed, you will receive large sums of gold and a chance to become the next master of your own team of gladiators! \n", ConsoleColor.Green);
            Print("Press any key to continue..", ConsoleColor.Red);
            Console.ReadKey();
        }

        public string NameChar()
        {
            while (true)
            {
                Console.Clear();
                Print("Gladiator, what is your name?", ConsoleColor.Yellow);
                string name = Request("Name: ");

                if (name != "")
                {
                    Print("Alright, good luck in the arena " + name + "!", ConsoleColor.Green);
                    Console.ReadKey();
                    return name;
                }

                // Basic error-handling - if above if-statement fails, string must be empty
                else
                {
                    Print("Please enter a name!", ConsoleColor.Red);
                    Console.ReadKey();
                }
            }

        }

        public int ChooseChar()
        {
            int choice = 0;
            Console.Clear();
            Print("Before you enter the arena, you must chose your weapons of armor", ConsoleColor.Yellow);
            Console.ReadKey();

            Console.Clear();
            Title("CHOOSE YOUR PATH");
            Print("You have three options: \n", ConsoleColor.Yellow);
            Print("1) Light armor, one handed sword and a shield \n", ConsoleColor.Red);
            Print("2) Medium armor, with a large spear \n", ConsoleColor.Red);
            Print("3) Heavy armor, with a big two-handed axe \n", ConsoleColor.Red);
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Print("You have chosen the light armor with a one-handed sword and shield! \n", ConsoleColor.Green);
                    Print("Press any key to continue..", ConsoleColor.Red);
                    Console.ReadKey();
                    hero = lightChar;
                    break;

                case 2:
                    Console.Clear();
                    Print("You have chosen the medium armor with a spear! \n", ConsoleColor.Green);
                    Print("Press any key to continue..", ConsoleColor.Red);
                    Console.ReadKey();
                    Medium medChar = new Medium(name);
                    hero = medChar;
                    break;

                case 3:
                    Console.Clear();
                    Print("You have chosen the heavy armor with the two-handed axe! \n", ConsoleColor.Green);
                    Print("Press any key to continue..", ConsoleColor.Red);
                    Console.ReadKey();
                    Heavy heavyChar = new Heavy(name);
                    hero = heavyChar;
                    break;
            }
            return choice;
        }

        public void DisplayStats()
        {
            // TODO: Add the option to have the option displayed - currently is displayed every time
            Console.Clear();
            Title("CHARACTER SHEET");
            Print("Here's your current items: \n", ConsoleColor.Green);
            for (int i = 0; i < hero.items.Length; i++)
            {
                string item = hero.items[i];
                // Put in 'N/A' text if off-hand is null
                if (hero.items[2] == null && i == 2)
                {
                    Print(hero.itemLabels[i] + "N/A", ConsoleColor.Yellow);
                }
                else
                {
                    Print(hero.itemLabels[i] + item + "\n", ConsoleColor.Yellow);
                }
            }

            Print("\n" + "Here's your stats: \n", ConsoleColor.Green);
            for (int i = 0; i < hero.stats.Length; i++)
            {
                int stats = hero.stats[i];

                // Put in 'N/A' text if block-chance is 0 - due to having two-hander equipped
                if (hero.stats[3] == 0 && i == 3)
                {
                    Print(hero.statLabels[i] + "N/A", ConsoleColor.Yellow);
                }
                else
                {
                    Print(hero.statLabels[i] + stats, ConsoleColor.Yellow);
                }

            }
            Print("\n" + "Press any key to continue..", ConsoleColor.Red);
            Console.ReadKey();
        }
    }
}
