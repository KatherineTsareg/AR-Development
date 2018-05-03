using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public enum HeroesSet { Lich, Footman, Grunt };

    [Serializable]
    public abstract class CHero
    {
        public int _power;
        public int _agility;
        public int _defence;
        public string _name;

        // Use this for initialization
        public abstract void Start();
        public string GetName()
        {
            return this._name;
        }
    }
}
