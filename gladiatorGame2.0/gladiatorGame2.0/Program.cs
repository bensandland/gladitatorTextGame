using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiatorGame2._0
{
    // TODO: Add menu class, for cleaner code in program.cs
    // TODO: Add more character customization (maybe pick up opponents weapon after fight? or the option to upgrade after each round)
    class Program
    {
        // Create instances of classes - to assign variables in different scopes
        public static Character hero;
        public static string name;
        public static Weapon weapon = new Weapon();
        public static Armor armor = new Armor();
        public static Enemy opponent = new Enemy();
        public static List<Enemy> enemies = new List<Enemy>();

        static void Print(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Console.WindowWidth = 155;
            StartGame();
            NameChar();
            ChooseChar();
            DisplayStats();
            Combat();
        }

        public static void StartGame()
        {
            Print("Welcome, to the Grand Arena!", ConsoleColor.Green);
            Print("In here, you will fight for your life and glory!", ConsoleColor.Green);
            Print("If you succeed, you will receive large sums of gold and a chance to become the next master of your own team of gladiators! \n", ConsoleColor.Green);
            Print("Press any key to continue..", ConsoleColor.Red);
            Console.ReadKey();
        }

        public static void NameChar()
        {
            bool nameCheck = true;

            while (nameCheck)
            {
                Console.Clear();
                Print("Gladiator, what is your name?", ConsoleColor.Yellow);
                Console.Write("Enter your name: ");
                name = Console.ReadLine(); // Assign input to name of the class

                if (name != "") // Check if string isn't empty
                {
                    nameCheck = false;
                    Print("Alright, good luck in the arena " + name + "!", ConsoleColor.Green);
                    Console.ReadKey();
                }

                // Basic error-handling - if above if-statement fails, string must be empty
                else
                {
                    Print("Please enter a name!", ConsoleColor.Red);
                    Console.ReadKey();
                }
            }
        }

        static void ChooseChar()
        {
            string choice;
            bool decide = true;

            Console.Clear();
            Print("Before you enter the arena, you must chose your weapons of armor", ConsoleColor.Yellow);
            Console.ReadKey();

            while (decide)
            {
                Console.Clear();
                Print("You have three options: \n", ConsoleColor.Yellow);
                Print("1) Light armor, one handed sword and a shield \n", ConsoleColor.Red);
                Print("2) Medium armor, with a large spear \n", ConsoleColor.Red);
                Print("3) Heavy armor, with a big two-handed axe \n", ConsoleColor.Red);
                Print("To receive more detailed info about each class, type info (number)", ConsoleColor.Red);
                Print("\n" + "ex. 'info 1'", ConsoleColor.Green);
                choice = Console.ReadLine().ToLower().Trim();

                if (choice == "info 1")
                {
                    choice = "";
                    Console.Clear();
                    Print("The light armor offers great mobility, but at a cost of lower armor. \n", ConsoleColor.Yellow);
                    Print("With a one handed sword, you'll have reliable damage, but with mediocre rolls (low max damage) \n", ConsoleColor.Yellow);
                    Print("The shield offers a somewhat solid defensive backbone, with a chance to block most incoming attacks.\n", ConsoleColor.Yellow);
                    Print("Press any key to close this message.", ConsoleColor.Red);
                    Console.ReadKey();
                }

                if (choice == "info 2")
                {
                    choice = "";
                    Console.Clear();
                    Print("The medium armor is a jack of all trades. You'll have decent defenses, and decent mobility \n", ConsoleColor.Yellow);
                    Print("The spear can offer you great safety, against enemies you can keep at range \n", ConsoleColor.Yellow);
                    Print("You wont have any shield though. That means fast enemies can have an upper hand once they get close \n", ConsoleColor.Yellow);
                    Print("Press any key to close this message.", ConsoleColor.Red);
                    Console.ReadKey();
                }

                if (choice == "info 3")
                {
                    choice = "";
                    Console.Clear();
                    Print("The heavy armor has high armor, but comes with a big mobility penalty \n", ConsoleColor.Yellow);
                    Print("With the two-handed axe you'll have potential for extreme damage, but with a high chance to miss due to your low mobility. \n", ConsoleColor.Yellow);
                    Print("Your heavy weapon wont allow you for any additional defenses. This means you'll have to rely on your body armor alone. \n", ConsoleColor.Yellow);
                    Print("Press any key to close this message.", ConsoleColor.Red);
                    Console.ReadKey();
                }

                else if (choice == "1")
                {
                    decide = false;
                    Console.Clear();
                    Print("You have chosen the light armor with a one-handed sword and shield! \n", ConsoleColor.Green);
                    Print("Press any key to continue..", ConsoleColor.Red);
                    Console.ReadKey();
                    hero = new Light(name);
                }

                else if (choice == "2")
                {
                    decide = false;
                    Console.Clear();
                    Print("You have chosen the medium armor with a spear! \n", ConsoleColor.Green);
                    Print("Press any key to continue..", ConsoleColor.Red);
                    Console.ReadKey();
                    hero = new Medium(name);
                }

                else if (choice == "3")
                {
                    decide = false;
                    Console.Clear();
                    Print("You have chosen the heavy armor with the two-handed axe! \n", ConsoleColor.Green);
                    Print("Press any key to continue..", ConsoleColor.Red);
                    Console.ReadKey();
                    hero = new Heavy(name);
                }
            }
        }

        static void DisplayStats()
        {
            // TODO: Add the option to have the option displayed - currently is displayed every time
            Console.Clear();
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

        static void Combat()
        {
            int enemyID = 0; // Enemy count, will increment if user wins the round
            int round = 1; /* Increments after every turn of you and opponent deals damage
                              - to prevent initializing same  opponent over & over */
            #region Add Enemies
            //AddEnemies
            enemies.Add(new Enemy("Pete the Peasant", 65, 10,  new Weapon("N/A", 2, 7), new Armor(15, 5)));
            enemies.Add(new Enemy("Kyle the Knight", 75, 5, new Weapon("N/A", 5, 9), new Armor(20, 0)));
            enemies.Add(new Enemy("Gary the Gladiator", 85, 20, new Weapon("N/A", 6, 11), new Armor(20, 5)));
            enemies.Add(new Enemy("Walter the Warrior", 100, 5, new Weapon("N/A", 9, 14), new Armor(30, 0)));
            #endregion Add Enemies

            while (hero.isAlive && (enemies.Count > enemyID))
            {
                hero.currentHealth = hero.health;
                Print("This is round " + round + " in the arena." + "\n" + "Good luck!", ConsoleColor.Cyan);
                opponent = enemies[enemyID];

                while(hero.isAlive && opponent.isAlive)
                {
                    Console.Clear();
                    // Actual combat-system
                    // TODO: Remove decimal numbers after damage dealt by enemy (currently is rounded down, but on output-text)
                    int dmg = hero.weapon.RollWeaponDmg();
                    opponent.health -= dmg;
                    Print("You're in combat with a " + opponent.name + "!", ConsoleColor.Red);
                    Print("\n" + "You dealt " + dmg + " points of damage!", ConsoleColor.Green);
                    Print("Your opponents health is now: " + opponent.health, ConsoleColor.Yellow);

                    Random defRoll = new Random();
                    int defensiveRoll = defRoll.Next(0, 100);

                    // Calculate chance to dodge and block
                    if (defensiveRoll < hero.agility + hero.blockChance)
                    {
                        Print("\n" + "You dodged your opponents damage!", ConsoleColor.Green);
                    }

                    // Calculate damage reduction from armor
                    else
                    {
                        double calculatedDmg = opponent.GetEnemyDmg() * (1 - (armor.dmgReduc / 100d));
                        hero.currentHealth -= (int)Math.Floor(calculatedDmg);
                        Print("\n" + opponent.name + " dealt " + calculatedDmg + " points of damage!", ConsoleColor.Red);
                    }

                    if (!opponent.isAlive)
                    {
                        Print("You are the victor! Congratulations, you are a true gladiator!", ConsoleColor.Yellow);
                        Print("You'll be moving on to the next round!", ConsoleColor.Yellow);
                        enemyID++;
                        Console.ReadKey();
                        continue;
                    }

                    if (!hero.isAlive)
                    {
                        Print("You have been slain!", ConsoleColor.Red);
                        Console.ReadKey();
                        continue;
                    }
                    Print("Your healthpoints is now at: " + hero.currentHealth + "!", ConsoleColor.Yellow);
                    Console.ReadKey();
                    Console.Clear();
                }
                round++; // Increments after every round
            }
        }
    }
}
