/// <summary>
/// Server.
/// Разработанно командой Sky Games
/// sgteam.ru
/// </summary>
using UnityEngine;
using System.Collections;
using System;

namespace Scripts
{
    public class Server : MonoBehaviour
    {

        public GameObject PlayerPrefab; // Персонаж игрока
        public string ip = "127.0.0.1"; // ip для создания или подключения к серверу
        public string port = "5300";    // Порт
        public bool connected;          // Статус подключения
        private GameObject _go;         // Объект для ссылки на игрока
        public bool _visible = false;   // Статус показа меню

        // На каждый кадр
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
                _visible = !_visible;
        }

        // На каждый кадр для прорисовки кнопок
        void OnGUI()
        {
            // Если мы на сервере
            if (connected)
            {
                if (_visible)
                {
                    GUI.Label(new Rect(30, 30, 120, 30), "Присоединились: " + Network.connections.Length);
                    if (GUI.Button(new Rect(30, 80, 100, 30), "Отключиться"))
                        Network.Disconnect(200);

                    if (GUI.Button(new Rect(30, 130, 100, 30), "Выход"))
                        Application.Quit();
                }
                //Если мы в главном меню
            }
        }

        // Вызывается когда мы подключились к серверу
        void OnConnectedToServer()
        {
            //CreatePlayer();

            connected = true;
            Application.LoadLevel(Application.loadedLevel + 1);
        }

        // Когда мы создали сервер
        void OnServerInitialized()
        {
            //CreatePlayer();
            connected = true;
            Application.LoadLevel(Application.loadedLevel + 1);
        }

        // Создание игрока
        void CreatePlayer()
        {
            connected = true;
            GetComponent<Camera>().enabled = false;
            GetComponent<Camera>().gameObject.GetComponent<AudioListener>().enabled = false;
            /*_go = (GameObject)Network.Instantiate(PlayerPrefab, transform.position, transform.rotation, 1);
            _go.transform.GetComponentInChildren<Camera>().GetComponent<Camera>().enabled = true;
            _go.transform.GetComponentInChildren<AudioListener>().enabled = true;*/
        }

        // При отключении от сервера
        void OnDisconnectedFromServer(NetworkDisconnection info)
        {
            connected = false;
            GetComponent<Camera>().enabled = true;
            GetComponent<Camera>().gameObject.GetComponent<AudioListener>().enabled = true;
            Application.LoadLevel(Application.loadedLevel);
        }

        // Вызывается каждый раз когда игрок отсоеденяется от сервера
        void OnPlayerDisconnected(NetworkPlayer pl)
        {
            Network.RemoveRPCs(pl);
            Network.DestroyPlayerObjects(pl);
        }

        public void ConnectClient()
        {
            Debug.Log("start connect");
            Network.Connect(ip, Convert.ToInt32(port));
            Debug.Log("connect to " + ip + ":" + port);
        }
        public void InitializeServer()
        {
            Debug.Log("start init");
            Network.InitializeServer(3, Convert.ToInt32(port), false);
            Debug.Log("initialized server in " + ip + ":" + port);
        }
    }
}
