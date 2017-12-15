using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiatorGame2._0
{
    class Enemy
    {
        private string _name;
        private bool _isAlive;
        private int _health;
        private int _agility;
        private Weapon _weapon;
        private Armor _armor = new Armor();

        public string name { get { return _name; } set { _name = value; } }
        public bool isAlive { get { return _isAlive; } set { _isAlive = value; } }
        public int health { get { return _health; } set { if (value <= 0) _isAlive = false; _health = value; } }
        public int agility { get { return _agility; }  set { _agility = value; } }
        public Weapon weapon { get { return _weapon; } set { _weapon = value; } }
        public Armor armor { get { return _armor; } set { _armor = value; } }

        public Enemy()
        {

        }

        public Enemy(string name, int health, int agility, Weapon weapon = null, Armor armor = null)
        {
            this.name = name;
            this.health = health;
            this.agility = agility;
            this.weapon = weapon;
            this.armor = armor;
        }

        public int GetEnemyDmg()
        {
            if (weapon != null)
            {
                return weapon.RollWeaponDmg();
            }
            else
            {
                return 0;
            }
        }

    }
}
