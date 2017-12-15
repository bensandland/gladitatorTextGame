using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiatorGame2._0
{
    public class Character
    {
        private string _name;
        private bool _isAlive;
        private int _health;
        private int _currentHealth;
        private int _agility;
        private int _blockChance;
        private string[] _items = new string[3];
        private string[] _itemLabels = new string[3] { "Weapon: ", "Armor: ", "Shield: " };
        private int[] _stats = new int[4];
        private string[] _statLabels = new string[4] { "Health: ", "Armor: ", "Agility: ", "Block-chance: " };
        
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
    }

    public class Light : Character
    {
        public Light()
        {
            Armor lightArmor = new Armor();
            Weapon lightWeapon = new Weapon();
            Character lightChar = new Character();

            lightWeapon.name = "steel sword";
            lightWeapon.type = "One-handed";
            lightWeapon.minDmgRoll = 4;
            lightWeapon.maxDmgRoll = 7;
            lightWeapon.offhand = "Iron shield";

            lightArmor.name = "chain mail";
            lightArmor.type = "Light";
            lightArmor.dmgReduc = 5;
            lightArmor.agilityDiff = 5;

            health = 65;
            agility = 25;
            blockChance = 15;

            items[0] = lightWeapon.type + " " + lightWeapon.name;
            items[1] = lightArmor.type + " " + lightArmor.name;
            items[2] = lightWeapon.offhand;

            stats[0] = health;
            stats[1] = lightArmor.dmgReduc;
            stats[2] = agility;
            stats[3] = blockChance;
        }

        public Light(string name)
        {
            this.name = name;
            Armor lightArmor = new Armor();
            Weapon lightWeapon = new Weapon();
            Character lightChar = new Character();

            lightWeapon.name = "steel sword";
            lightWeapon.type = "One-handed";
            lightWeapon.minDmgRoll = 4;
            lightWeapon.maxDmgRoll = 7;
            lightWeapon.offhand = "Iron shield";

            lightArmor.name = "chain mail";
            lightArmor.type = "Light";
            lightArmor.dmgReduc = 5;
            lightArmor.agilityDiff = 5;

            health = 65;
            agility = 25;
            blockChance = 15;

            items[0] = lightWeapon.type + " " + lightWeapon.name;
            items[1] = lightArmor.type + " " + lightArmor.name;
            items[2] = lightWeapon.offhand;

            stats[0] = health;
            stats[1] = lightArmor.dmgReduc;
            stats[2] = agility;
            stats[3] = blockChance;
        }
    }

    public class Medium : Character
    {
        public Medium()
        {
            Armor mediumArmor = new Armor();
            Weapon mediumWeapon = new Weapon();
            Character mediumChar = new Character();

            mediumWeapon.name = "wooden spear";
            mediumWeapon.type = "Two-handed";
            mediumWeapon.minDmgRoll = 5;
            mediumWeapon.maxDmgRoll = 11;
            mediumWeapon.offhand = "Iron shield";

            mediumArmor.name = "chain mail";
            mediumArmor.type = "Medium";
            mediumArmor.dmgReduc = 15;
            mediumArmor.agilityDiff = 0;

            health = 90;
            agility = 12;
            blockChance = 0;

            items[0] = mediumWeapon.type + " " + mediumWeapon.name;
            items[1] = mediumArmor.type + " " + mediumArmor.name;
            items[2] = mediumWeapon.offhand;

            stats[0] = health;
            stats[1] = mediumArmor.dmgReduc;
            stats[2] = agility;
            stats[3] = blockChance;
        }

        public Medium(string name)
        {
            this.name = name;
            Armor mediumArmor = new Armor();
            Weapon mediumWeapon = new Weapon();
            Character mediumChar = new Character();

            mediumWeapon.name = "wooden spear";
            mediumWeapon.type = "Two-handed";
            mediumWeapon.minDmgRoll = 5;
            mediumWeapon.maxDmgRoll = 11;
            mediumWeapon.offhand = "Iron shield";

            mediumArmor.name = "chain mail";
            mediumArmor.type = "Medium";
            mediumArmor.dmgReduc = 15;
            mediumArmor.agilityDiff = 0;

            health = 90;
            agility = 12;
            blockChance = 0;

            items[0] = mediumWeapon.type + " " + mediumWeapon.name;
            items[1] = mediumArmor.type + " " + mediumArmor.name;
            items[2] = mediumWeapon.offhand;

            stats[0] = health;
            stats[1] = mediumArmor.dmgReduc;
            stats[2] = agility;
            stats[3] = blockChance;
        }
    }

    public class Heavy : Character
    {
        public Heavy()
        {
            Armor heavyArmor = new Armor();
            Weapon heavyWeapon = new Weapon();
            Character heavyChar = new Character();

            heavyWeapon.name = "steel axe";
            heavyWeapon.type = "Two-handed";
            heavyWeapon.minDmgRoll = 8;
            heavyWeapon.maxDmgRoll = 20;
            heavyWeapon.offhand = "Iron shield";

            heavyArmor.name = "iron plate";
            heavyArmor.type = "Heavy";
            heavyArmor.dmgReduc = 35;
            heavyArmor.agilityDiff = -10;

            health = 105;
            agility = 5;
            blockChance = 0;

            items[0] = heavyWeapon.type + " " + heavyWeapon.name;
            items[1] = heavyArmor.type + " " + heavyArmor.name;
            items[2] = heavyWeapon.offhand;

            stats[0] = health;
            stats[1] = heavyArmor.dmgReduc;
            stats[2] = agility;
            stats[3] = blockChance;
        }

        public Heavy(string name)
        {
            this.name = name;
            Armor heavyArmor = new Armor();
            Weapon heavyWeapon = new Weapon();
            Character heavyChar = new Character();

            heavyWeapon.name = "steel axe";
            heavyWeapon.type = "Two-handed";
            heavyWeapon.minDmgRoll = 8;
            heavyWeapon.maxDmgRoll = 20;
            heavyWeapon.offhand = "Iron shield";

            heavyArmor.name = "iron plate";
            heavyArmor.type = "Heavy";
            heavyArmor.dmgReduc = 35;
            heavyArmor.agilityDiff = -10;

            health = 105;
            agility = 5;
            blockChance = 0;

            items[0] = heavyWeapon.type + " " + heavyWeapon.name;
            items[1] = heavyArmor.type + " " + heavyArmor.name;
            items[2] = heavyWeapon.offhand;

            stats[0] = health;
            stats[1] = heavyArmor.dmgReduc;
            stats[2] = agility;
            stats[3] = blockChance;
        }
    }
}
