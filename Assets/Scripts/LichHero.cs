using System;
using UnityEngine;

namespace Scripts
{
    [Serializable]
    public class LichHero : CHero
    {
        private int _power = 2;
        private int _agility = 3;
        private int _defence = 5;
        private string _name = "Lich";

        // Use this for initialization
        public override void Start() { }
    }
}