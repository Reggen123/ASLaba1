using System;
using System.Collections.Generic;
using System.Text;

namespace ASLaba1
{
    public class Ability
    {
        public Ability(string id, string name, string desc, int manacost, int damage, int reloadinsec)
        {
            ID = id;
            Name = name;
            Desc = desc;
            ManaCost = manacost;
            Damage = damage;
            ReloadInSec = reloadinsec;
        }

        public Ability(string name, string desc, int manacost, int damage, int reloadinsec)
        {
            ID = Guid.NewGuid().ToString();
            Name = name;
            Desc = desc;
            ManaCost = manacost;
            Damage = damage;
            ReloadInSec = reloadinsec;
        }

        public string ID;
        public string Name;
        public string Desc;
        public int ManaCost;
        public int Damage;
        public int ReloadInSec;
    }
}
