using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class SaveSystem : MonoBehaviour
    {
        public GameProgress _gameProgress = new GameProgress();
        public CPlayer _player = new CPlayer();
        private string _pathGP, _pathP;

        private void Awake()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            _pathGP = Path.Combine(Application.persistentDataPath, "SavedGameProgress.json");
            _pathP = Path.Combine(Application.persistentDataPath, "SavedPlayerInfo.json");

#else
            _pathGP = Path.Combine(Application.dataPath, "SavedGameProgress.json");
            _pathP = Path.Combine(Application.dataPath, "SavedPlayerInfo.json");
#endif
            if (File.Exists(_pathGP) && File.Exists(_pathP))
            {
                SetInfoFromJSON();
                if (!_gameProgress._isGameOver)
                {
                    Debug.Log("Добро пожаловать на уровень " + _gameProgress._currentLevel);
                    Debug.Log("Ваш персонаж:  " + _player._heroID);
                }
                else
                {
                    Debug.Log("Добро пожаловать в новую игру!");
                    Debug.Log("Уровень: " + _gameProgress.GetLevel());
                }
            }
        }


        public void Save()
        {
            File.WriteAllText(_pathGP, JsonUtility.ToJson(_gameProgress));
            File.WriteAllText(_pathP, JsonUtility.ToJson(_player));
        }

        private void SetInfoFromJSON()
        {
            this._gameProgress = JsonUtility.FromJson<GameProgress>(File.ReadAllText(_pathGP));
            this._player = JsonUtility.FromJson<CPlayer>(File.ReadAllText(_pathP));
        }
#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        Save();
    }
#endif
        private void OnApplicationQuit()
        {
            _gameProgress._currentLevel = 0;
            Save();
        }

        public void SetPlayerHero()
        {
            int index = GameService.GetIndexOfChoosenHero();
            _player.SetHeroIndex(index);
            //this._player.SetHero(GameService.GetHeroEnum(index));
            Debug.Log("Set hero for player " + index);
            this._gameProgress._isGameOver = false;
        }

        public void LoadScene(string toSceneName)
        {
            this._gameProgress.SetLevelByName(toSceneName);
            Save();
            SceneManager.LoadScene(this._gameProgress.GetLevel());
        }
        public void LoadNextScene()
        {
            //Debug.Log(this._gameProgress._currentLevel + " scene CHANGE TO " + this._gameProgress._currentLevel + 1);
            this._gameProgress.SetNextLevel();
            Save();
            SceneManager.LoadScene(this._gameProgress.GetLevel());
        }
        public void SetPlayerName()
        {
            _player.SetName();
        }
        public int GetHeroIndex()
        {
            return _player._heroID;
        }
    }
}