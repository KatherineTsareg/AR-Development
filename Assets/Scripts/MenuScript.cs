using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class MenuScript : MonoBehaviour
    {
        public void LoadByIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void LoadNextScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}
