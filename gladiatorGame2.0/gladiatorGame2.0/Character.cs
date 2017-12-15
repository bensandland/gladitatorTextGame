using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiatorGame2._0
{
    public abstract class Character
    {
        private string _name;
        private bool _isAlive = true;
        private int _health;
        private int _currentHealth;
        private int _agility;
        private int _blockChance;
        private string[] _items = new string[3];
        private string[] _itemLabels = new string[3] { "Weapon: ", "Armor: ", "Shield: " };
        private int[] _stats = new int[6];
        private string[] _statLabels = new string[6] { "Health: ", "Armor: ", "Agility: ", "Block-chance: ", "Min-damage: ", "Max-damage: " };
        private Armor _armor;
        private Weapon _weapon;

        // Getters & setters
        public string name { get { return _name; } set { _name = value; } }
        public bool isAlive { get { return _isAlive; } set { _isAlive = value; } }
        public int health { get { return _health; }  set { _health = value; } }
        public int currentHealth { get { return _currentHealth; } set { if (value <= 0) _isAlive = false; _currentHealth = value; } }
        public int agility { get { return _agility; } set { _agility = value; } }
        public int blockChance { get { return _blockChance; } set { _blockChance = value; } }
        public string[] items { get { return _items; } set { _items = value; } }
        public string[] itemLabels { get { return _itemLabels; } set { _itemLabels = value; } }
        public int[] stats { get { return _stats; } set { _stats = value; } }
        public string[] statLabels { get { return _statLabels; } set { _statLabels = value; } }
        public Armor armor { get { return _armor; } set { _armor = value; } }
        public Weapon weapon { get { return _weapon; } set { _weapon = value; } }

        public Character()
        {
            armor = new Armor();
            weapon = new Weapon();
        }
    }

    public class Light : Character
    {
        public Light()
        {
            weapon.name = "steel sword";
            weapon.type = "One-handed";
            weapon.minDmg = 4;
            weapon.maxDmg = 7;
            weapon.offhand = "Iron shield";
            
            armor.name = "chain mail";
            armor.type = "Light";
            armor.dmgReduc = 5;
            armor.agilityDiff = 5;

            health = 65;
            agility = 25;
            blockChance = 15;

            items[0] = weapon.type + " " + weapon.name;
            items[1] = armor.type + " " + armor.name;
            items[2] = weapon.offhand;

            stats[0] = health;
            stats[1] = armor.dmgReduc;
            stats[2] = agility;
            stats[3] = blockChance;
            stats[4] = weapon.minDmg;
            stats[5] = weapon.maxDmg;

        }

        public Light(string name)
        {
            this.name = name;

            weapon.name = "steel sword";
            weapon.type = "One-handed";
            weapon.minDmg = 4;
            weapon.maxDmg = 7;
            weapon.offhand = "Iron shield";

            armor.name = "chain mail";
            armor.type = "Light";
            armor.dmgReduc = 5;
            armor.agilityDiff = 5;

            health = 65;
            agility = 25;
            blockChance = 15;

            items[0] = weapon.type + " " + weapon.name;
            items[1] = armor.type + " " + armor.name;
            items[2] = weapon.offhand;

            stats[0] = health;
            stats[1] = armor.dmgReduc;
            stats[2] = agility;
            stats[3] = blockChance;
            stats[4] = weapon.minDmg;
            stats[5] = weapon.maxDmg;
        }
    }

    public class Medium : Character
    {
        public Medium()
        {
            weapon.name = "wooden spear";
            weapon.type = "Two-handed";
            weapon.minDmg = 5;
            weapon.maxDmg = 11;
            weapon.offhand = "Iron shield";

            armor.name = "chain mail";
            armor.type = "Medium";
            armor.dmgReduc = 12;
            armor.agilityDiff = 0;

            health = 90;
            agility = 12;
            blockChance = 0;

            items[0] = weapon.type + " " + weapon.name;
            items[1] = armor.type + " " + armor.name;
            items[2] = weapon.offhand;

            stats[0] = health;
            stats[1] = armor.dmgReduc;
            stats[2] = agility;
            stats[3] = blockChance;
            stats[4] = weapon.minDmg;
            stats[5] = weapon.maxDmg;
        }

        public Medium(string name)
        {
            this.name = name;

            weapon.name = "wooden spear";
            weapon.type = "Two-handed";
            weapon.minDmg = 5;
            weapon.maxDmg = 11;
            weapon.offhand = "Iron shield";

            armor.name = "chain mail";
            armor.type = "Medium";
            armor.dmgReduc = 22;
            armor.agilityDiff = 0;

            health = 90;
            agility = 12;
            blockChance = 0;

            items[0] = weapon.type + " " + weapon.name;
            items[1] = armor.type + " " + armor.name;
            items[2] = weapon.offhand;

            stats[0] = health;
            stats[1] = armor.dmgReduc;
            stats[2] = agility;
            stats[3] = blockChance;
            stats[4] = weapon.minDmg;
            stats[5] = weapon.maxDmg;
        }
    }

    public class Heavy : Character
    {
        public Heavy()
        {
            weapon.name = "steel axe";
            weapon.type = "Two-handed";
            weapon.minDmg = 8;
            weapon.maxDmg = 20;
            weapon.offhand = "Iron shield";

            armor.name = "iron plate";
            armor.type = "Heavy";
            armor.dmgReduc = 35;
            armor.agilityDiff = -10;

            health = 105;
            agility = 5;
            blockChance = 0;

            items[0] = weapon.type + " " + weapon.name;
            items[1] = armor.type + " " + armor.name;
            items[2] = weapon.offhand;

            stats[0] = health;
            stats[1] = armor.dmgReduc;
            stats[2] = agility;
            stats[3] = blockChance;
            stats[4] = weapon.minDmg;
            stats[5] = weapon.maxDmg;
        }

        public Heavy(string name)
        {
            this.name = name;

            weapon.name = "steel axe";
            weapon.type = "Two-handed";
            weapon.minDmg = 8;
            weapon.maxDmg = 20;
            weapon.offhand = "Iron shield";

            armor.name = "iron plate";
            armor.type = "Heavy";
            armor.dmgReduc = 35;
            armor.agilityDiff = -10;

            health = 105;
            agility = 5;
            blockChance = 0;

            items[0] = weapon.type + " " + weapon.name;
            items[1] = armor.type + " " + armor.name;
            items[2] = weapon.offhand;

            stats[0] = health;
            stats[1] = armor.dmgReduc;
            stats[2] = agility;
            stats[3] = blockChance;
            stats[4] = weapon.minDmg;
            stats[5] = weapon.maxDmg;
        }
    }
}
