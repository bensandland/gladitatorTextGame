using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiatorGame2._0
{
    class Game
    {
        Menu menu = new Menu();
        public static List<Enemy> enemies = new List<Enemy>();
        public static Character hero;
        public static Weapon weapon = new Weapon();
        public static Armor armor = new Armor();
        public static Enemy opponent = new Enemy();

        public void Combat()
        {
            int enemyID = 0; // Enemy count, will increment if user wins the round
            int round = 1; /* Increments after every turn of you and opponent deals damage
                              - to prevent initializing same  opponent over & over */

            #region Add Enemies
            //AddEnemies
            Weapon peasantWeapon = new Weapon("N/A", 2, 7);
            Armor peasantArmor = new Armor(15, 5);
            enemies.Add(new Enemy("Pete the Peasant", 65, 10, peasantWeapon, peasantArmor));

            Weapon knightWeapon = new Weapon("N/A", 5, 9);
            Armor knightArmor = new Armor(20, 0);
            enemies.Add(new Enemy("Kyle the Knight", 75, 5, knightWeapon, knightArmor));

            Weapon gladiatorWeapon = new Weapon("N/A", 6, 11);
            Armor gladiatorArmor = new Armor(20, 5);
            enemies.Add(new Enemy("Gary the Gladiator", 80, 2));
            #endregion Add Enemies


            while (hero.isAlive && (enemies.Count > enemyID))
            {
                hero.currentHealth = hero.health;
                menu.Print("This is round " + round + " in the arena." + "\n" + "Good luck!", ConsoleColor.Cyan);
                opponent = enemies[enemyID];

                while (hero.isAlive && opponent.isAlive)
                {
                    Console.Clear();
                    // Actual combat-system
                    // TODO: Remove decimal numbers after damage dealt by enemy (currently is rounded down, but on output-text)
                    int dmg = hero.weapon.RollWeaponDmg();
                    opponent.health -= dmg;
                    menu.Print("You're in combat with a " + opponent.name + "!", ConsoleColor.Red);
                    menu.Print("\n" + "You dealt " + dmg + " points of damage!", ConsoleColor.Green);
                    menu.Print("Your opponents health is now: " + opponent.health, ConsoleColor.Yellow);

                    Random defRoll = new Random();
                    int defensiveRoll = defRoll.Next(0, 100);

                    // Calculate chance to dodge and block
                    if (defensiveRoll < hero.agility + hero.blockChance)
                    {
                        menu.Print("\n" + "You dodged your opponents damage!", ConsoleColor.Green);
                    }

                    // Calculate damage reduction from armor
                    else
                    {
                        double calculatedDmg = opponent.GetEnemyDmg() * (1 - (armor.dmgReduc / 100d));
                        hero.currentHealth -= (int)Math.Floor(calculatedDmg);
                        menu.Print("\n" + opponent.name + " dealt " + calculatedDmg + " points of damage!", ConsoleColor.Red);
                    }

                    if (!opponent.isAlive)
                    {
                        menu.Print("You are the victor! Congratulations, you are a true gladiator!", ConsoleColor.Yellow);
                        menu.Print("You'll be moving on to the next round!", ConsoleColor.Yellow);
                        enemyID++;
                        Console.ReadKey();
                        continue;
                    }

                    if (!hero.isAlive)
                    {
                        menu.Print("You have been slain!", ConsoleColor.Red);
                        Console.ReadKey();
                        continue;
                    }
                    menu.Print("Your healthpoints are now at: " + hero.currentHealth + "!", ConsoleColor.Yellow);

                    Console.ReadKey();
                    Console.Clear();
                }
                round++; // Increments after every round
            }
        }
    }
}
