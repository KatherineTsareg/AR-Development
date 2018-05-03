using System;
using UnityEngine;

namespace Scripts
{
    [Serializable]
    public class FootmanHero : CHero
    {
        private int _power = 5;
        private int _agility = 2;
        private int _defence = 3;
        private string _name = "Footman";

        // Use this for initialization
        public override void Start() { }
    }
}