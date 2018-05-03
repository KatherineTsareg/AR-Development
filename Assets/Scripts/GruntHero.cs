using System;
using UnityEngine;

namespace Scripts
{
    [Serializable]
    public class GruntHero : CHero
    {
        private int _power = 2;
        private int _agility = 5;
        private int _defence = 3;
        private string _name = "Grunt";

        // Use this for initialization
        public override void Start() { }
    }
}