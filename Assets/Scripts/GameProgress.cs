using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace Scripts
{

    //Класс для хранения данных об игре
    [Serializable]
    public class GameProgress
    {
        public int _currentLevel = 0;
        //public CPlayer _player = new CPlayer();
        //игра окончена, нет информации об игроке
        public bool _isGameOver = true;

        public void SetNextLevel()
        {
            this._currentLevel += 1;
        }
        public void SetLevelByName(string toSceneName)
        {
            this._currentLevel = CLevel.SCENE_LIST[toSceneName];
        }
        public int GetLevel()
        {
            return _currentLevel;
        }
        
    }
}
