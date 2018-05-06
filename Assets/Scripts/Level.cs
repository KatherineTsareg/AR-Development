using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public enum LevelsSet {
        HelloScene,
        ChooseHeroSettings,
        ChoosePersonalSetting,
        ARForestScene,
        ARBattleScene,
    };

    [Serializable]
    public class CLevel : MonoBehaviour
    {
        public int _currentLevel = 0;
        public static Dictionary<string, int> SCENE_LIST = new Dictionary<string, int>
        {
            { "HelloScene", 0 },
            { "ChooseHeroSettings", 1 },
            { "ChoosePersonalSettings", 2 },
            { "WaitingPartnersScene", 3},
            { "ARForestScene", 4 },
            { "ARBattleScene", 5 },
        };

        public void Awake()
        {
            this._currentLevel = Application.loadedLevel;
        }

        public void LoadScene(string toSceneName)
        {
            this._currentLevel = SCENE_LIST[toSceneName];
            SceneManager.LoadScene(_currentLevel);
        }
        public void LoadNextScene()
        {
            Debug.Log(this._currentLevel + " scene CHANGE TO " + this._currentLevel + 1);
            this._currentLevel += 1;
            SceneManager.LoadScene(this._currentLevel);
        }
        public int GetNumberLevel()
        {
            return _currentLevel;
        }
    }
}
