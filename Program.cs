using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiatorGame
{
    // TODO: DisplayStats - A function with array(s), displaying all your current items and stats
    // TODO: AddItem - An option to loot slain opponents items. Before fights one can equip/unequip items
    class Program
    {
        // These are made to have two global keywords for the current active instances of their respective classes.
        public static Character hero; 
        public static Enemy opponent;

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
            Character yourChar = new Character(); // Create instance of class to save name into it

            while(nameCheck)
            {
                Console.Clear();
                Print("Gladiator, what is your name?", ConsoleColor.Yellow);
                Console.Write("Enter your name: ");
                yourChar.name = Console.ReadLine(); // Assign input to name of the class

                if (yourChar.name != "")
                {
                    nameCheck = false;
                    Print("Alright, good luck in the arena " + yourChar.name + "!", ConsoleColor.Green);
                    Console.ReadKey();
                }

                // Basic error-handling
                else if (yourChar.name == "")
                {
                    Print("Please enter a name!", ConsoleColor.Red);
                    Console.ReadKey();
                }

                yourChar.name = hero.name;
            }
        }

        static void ChooseChar()
        {
            string choice;
            bool decide = true;

            Console.Clear();
            Print("Before you enter the arena, you must choose your weapons and armor", ConsoleColor.Yellow);
            Console.ReadKey();

            while (decide) { 
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
            
                else if (choice == "info 2")
                {
                    choice = "";
                    Console.Clear();
                    Print("The medium armor is a jack of all trades. You'll have decent defenses, and decent mobility \n", ConsoleColor.Yellow);
                    Print("The spear can offer you great safety, against enemies you can keep at range \n", ConsoleColor.Yellow);
                    Print("You wont have any shield though. That means fast enemies can have an upper hand once they get close \n", ConsoleColor.Yellow);
                    Print("Press any key to close this message.", ConsoleColor.Red);
                    Console.ReadKey();
                }

                else if (choice == "info 3")
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

                    Weapon lightWeapon = new Weapon();
                    Armor lightArmor = new Armor();
                    Character lightChar = new Character();
                    hero = lightChar;
                    hero.weapon = lightWeapon;
                    hero.armor = lightArmor;

                    lightWeapon.name = "steel sword";
                    lightWeapon.type = "One-handed";
                    lightWeapon.minDmgRoll = 4;
                    lightWeapon.maxDmgRoll = 7;
                    lightWeapon.offhand = "Iron shield";

                    lightArmor.name = "chain mail";
                    lightArmor.type = "Light";
                    lightArmor.armor = 5;
                    lightArmor.agilityDiff = 5;

                    lightChar.health = 65;
                    lightChar.agility = 25;
                    lightChar.blockChance = 15;
                    lightChar.items[0] = lightWeapon.type + " " + lightWeapon.name;
                    lightChar.items[1] = lightArmor.type + " " + lightArmor.name;
                    lightChar.items[2] = lightWeapon.offhand;

                    lightChar.stats[0] = lightChar.health;
                    lightChar.stats[1] = lightArmor.armor;
                    lightChar.stats[2] = lightChar.agility;
                    lightChar.stats[3] = lightChar.blockChance;
                }

                else if (choice == "2")
                {
                    decide = false;
                    Console.Clear();
                    Print("You have chosen the medium armor with a spear! \n", ConsoleColor.Green);
                    Print("Press any key to continue..", ConsoleColor.Red);
                    Console.ReadKey();

                    Weapon mediumWeapon = new Weapon();
                    Armor mediumArmor = new Armor();
                    Character mediumChar = new Character();
                    hero = mediumChar;
                    hero.weapon = mediumWeapon;
                    hero.armor = mediumArmor;

                    mediumWeapon.name = "wooden spear";
                    mediumWeapon.type = "Two-handed";
                    mediumWeapon.minDmgRoll = 4;
                    mediumWeapon.maxDmgRoll = 11;

                    mediumArmor.name = "steel armor";
                    mediumArmor.type = "Medium";
                    mediumArmor.armor = 15;
                    mediumArmor.agilityDiff = 0;

                    mediumChar.health = 90;
                    mediumChar.agility = 15;
                    mediumChar.blockChance = 0;

                    // Fill out arrays for DisplayStats function
                    mediumChar.items[0] = mediumWeapon.type + " " + mediumWeapon.name;
                    mediumChar.items[1] = mediumArmor.type + " " + mediumArmor.name;
                    mediumChar.items[2] = mediumWeapon.offhand;

                    mediumChar.stats[0] = mediumChar.health;
                    mediumChar.stats[1] = mediumArmor.armor;
                    mediumChar.stats[2] = mediumChar.agility;
                    mediumChar.stats[3] = mediumChar.blockChance;
                }

                else if (choice == "3")
                {
                    decide = false;
                    Console.Clear();
                    Print("You have chosen the heavy armor with the two-handed axe! \n", ConsoleColor.Green);
                    Print("Press any key to continue..", ConsoleColor.Red);
                    Console.ReadKey();

                    Weapon heavyWeapon = new Weapon();
                    Armor heavyArmor = new Armor();
                    Character heavyChar = new Character();
                    hero = heavyChar;
                    hero.weapon = heavyWeapon;
                    hero.armor = heavyArmor;

                    heavyWeapon.name = "steel axe";
                    heavyWeapon.type = "Two-handed";
                    heavyWeapon.minDmgRoll = 8;
                    heavyWeapon.maxDmgRoll = 20;

                    heavyArmor.name = "iron plate";
                    heavyArmor.type = "Heavy";
                    heavyArmor.armor = 35;
                    heavyArmor.agilityDiff = -10;

                    heavyChar.health = 105;
                    heavyChar.agility = 0;
                    heavyChar.blockChance = 0;

                    // Fill out arrays for DisplayStats function
                    heavyChar.items[0] = heavyWeapon.type + " " + heavyWeapon.name;
                    heavyChar.items[1] = heavyArmor.type + " " + heavyArmor.name;
                    heavyChar.items[2] = heavyWeapon.offhand;


                    heavyChar.stats[0] = heavyChar.health;
                    heavyChar.stats[1] = heavyArmor.armor;
                    heavyChar.stats[2] = heavyChar.agility;
                    heavyChar.stats[3] = heavyChar.blockChance;
                }

                else if (choice != "1" || // Error check on input
                         choice != "2" ||
                         choice != "3" ||
                         choice != "info 1" ||
                         choice != "info 2" ||
                         choice != "info 3") {
                    Console.Clear();
                    Print("\n" + "Please enter a valid option!", ConsoleColor.Red);
                    Console.ReadKey();
                }
            }
        }
        /// <summary>
        /// Displays stats for your current character in arrays
        /// </summary>
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
            int enemyID = 1; // Enemy count, will increment if user wins the round
            int round = 1; /* Increments after every turn of you and opponent deals damage
                              - to prevent initializing opponent over & over */
            bool alive = true; // To stay in loop for combat - will exit if either your or opponent dies
            
            while (alive)
            {
                Print("This is round " + enemyID + " in the arena." + "\n" + "Good luck!", ConsoleColor.Cyan);
                if (round == 1) { 
                    if (enemyID == 1) // Create enemy based on round number
                    {
                        Random roll = new Random();
                        Enemy peasant = new Enemy();
                        opponent = peasant;
                        Weapon peasantWeapon = new Weapon();
                        Armor peasantArmor = new Armor();

                        peasant.name = "Pete the Peasant";
                        peasant.health = 65;
                        peasant.agility = 10;

                        peasantWeapon.name = "Pitchfork";
                        peasantWeapon.type = "Medium";
                        peasantWeapon.minDmgRoll = 2;
                        peasantWeapon.maxDmgRoll = 7;
                        peasant.weapon = peasantWeapon;
                    
                        peasantArmor.name = "Ragged Cloth";
                        peasantArmor.type = "Light";
                        peasantArmor.armor = 15;
                        peasantArmor.agilityDiff = 5;

                        int enemyDmg = 0;
                        int eDmg = peasant.GetEnemyDmg();
                        enemyDmg = eDmg;
                    }
                    // TODO: Create more enemies
                }
                Console.Clear();
                // Actual combat-system
                // TODO: Remove decimal numbers after damage dealt by enemy (currently is rounded down, but on output-text)
                opponent.health -= hero.GetHeroDmg();
                Print("You're in combat with a " + opponent.name + "!", ConsoleColor.Red);
                Print("\n" + "You dealt " + hero.GetHeroDmg() + " points of damage!", ConsoleColor.Green);
                Print("Your opponents health is now: " + opponent.health, ConsoleColor.Yellow);

                Random defRoll = new Random();
                int defensiveRoll = defRoll.Next(0, 100);

                // Calculate chance to dodge
                if (defensiveRoll < hero.agility + hero.blockChance)
                {
                    Print("\n" + "You dodged your opponents damage!", ConsoleColor.Green);
                }

                // Calculate damage reduction from armor
                else
                {
                    double calculatedDmg = opponent.GetEnemyDmg() * (1 - (hero.GetHeroArmor() / 100d));
                    hero.health -= (int)Math.Floor(calculatedDmg);
                    Print("\n" + opponent.name + " dealt " + calculatedDmg + " points of damage!", ConsoleColor.Red);
                }

                Print("Your healthpoints is now at: " + hero.health + "!", ConsoleColor.Yellow);

                Console.ReadKey();
                Console.Clear();

                if (opponent.health <= 0)
                {
                    alive = false;
                    Print("You are the victor! Congratulations, you are a true gladiator!", ConsoleColor.Yellow);
                    Print("You'll be moving on to the next round!", ConsoleColor.Yellow);
                    Console.ReadKey();
                    enemyID++;
                }

                if (hero.health <= 0)
                {
                    alive = false;
                    Print("You have been slain!", ConsoleColor.Red);
                    Console.ReadKey();
                }
                round++; // Increments after every round
            }
        }

        static void Print(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public class Character
        {
            public string name;
            public int health;
            public int agility;
            public int blockChance;
            public string[] items = new string[3];
            public string[] itemLabels = new string[3] { "Weapon: ", "Armor: ", "Shield: " };
            public int[] stats = new int[4];
            public string[] statLabels = new string[4] { "Health: ", "Armor: ", "Agility: ", "Block-chance: " };
            public Weapon weapon;
            public Armor armor;

            public int GetHeroDmg()
            {
                if (weapon != null)
                {
                    return weapon.GetWeaponDmg();
                }
                else
                {
                    return 1;
                }
            }

            public int GetHeroArmor()
            {
                return armor.GetArmor();
            }
        }

        public class Weapon
        {
            public string name;
            public string type;
            public string offhand;
            public int minDmgRoll;
            public int maxDmgRoll;

            public int GetWeaponDmg()
            {
                Random roll = new Random();
                return roll.Next(minDmgRoll, maxDmgRoll);
            }
        }

        public class Armor
        {
            public string name;
            public string type;
            public int armor;
            public int agilityDiff;

            public int GetArmor()
            {
                return armor;
            }
        }

        public class Enemy
        {
            public string name;
            public int health;
            public int agility;
            public Weapon weapon;
            public int GetEnemyDmg()
            {
                if (weapon != null)
                {
                    return weapon.GetWeaponDmg();
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
