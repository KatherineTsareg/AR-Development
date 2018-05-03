using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    [Serializable]
    public class CPlayer
    {
        [NonSerialized]
        public CHero _hero;
        public int _heroID = -1;
        public string _color;
        public string _name;
        public int _wins = 0;
        public int _loses = 0;
        public int _lands = 5;

        public void SetHero(HeroesSet heroName)
        {
            switch (heroName)
            {
                case HeroesSet.Lich:
                    this._hero = new LichHero();
                    Debug.Log("Set the hero with name " + _hero.GetName());
                    break;
                case HeroesSet.Grunt:
                    this._hero = new GruntHero();
                    Debug.Log("Set the hero with name " + _hero.GetName());
                    break;
                case HeroesSet.Footman:
                    this._hero = new FootmanHero();
                    Debug.Log("Set the hero with name " + _hero.GetName());
                    break;
                default:
                    Debug.Log("Hero is not set!");
                    break;
            }
            
        }
        public void SetHeroIndex(int index)
        {
            this._heroID = index;
        }
        
        public void SetName()
        {
            string name = GameService.GetPlayerName();
            this._name = name;
        }
        public void SetColor(string color)
        {
            this._color = color;
        }

        public string GetName()
        {
            return this._name;
        }
        public string GetHeroName()
        {
            return _hero.GetName();
        }
    }
}
