using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiatorGame2._0
{
    public abstract class Equipment
    {
        private string _name;
        private string _type;

        public string name { get { return _name; } set { _name = value; } }
        public string type { get { return _type; } set { _type = value; } }
    }

    public class Weapon : Equipment
    {
        private string _offhand;
        private int _minDmgRoll;
        private int _maxDmgRoll;

        // Getters & setters
        public string offhand { get { return _offhand; } set { _offhand = value; } }
        public int minDmgRoll { get { return _minDmgRoll; } set { _minDmgRoll = value; } }
        public int maxDmgRoll { get { return _maxDmgRoll; } set { _maxDmgRoll = value; } }

        public Weapon()
        {

        }

        public Weapon(string offhand, int minDmgRoll, int maxDmgRoll)
        {
            this.offhand = offhand;
            this.minDmgRoll = minDmgRoll;
            this.maxDmgRoll = minDmgRoll;
        }

        public int RollWeaponDmg()
        {
            Random roll = new Random();
            return roll.Next(minDmgRoll, maxDmgRoll);
        }
    }

    public class TwoHander : Weapon
    {

    }

    public class Shield : Equipment
    {

    }

    public class Armor : Equipment
    {
        private int _dmgReduc;
        private int _agilityDiff;

        // Getters & setters
        public int dmgReduc { get { return _dmgReduc; } set { _dmgReduc = value; } }
        public int agilityDiff { get { return _agilityDiff; } set { _agilityDiff = value; } }

        public Armor()
        {
            
        }

        public Armor(int dmgReduc, int agilityDiff)
        {
            this.dmgReduc = dmgReduc;
            this.agilityDiff = agilityDiff;
        }
    }
}
