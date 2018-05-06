using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts
{
    public class ChooseHeroPersonalSettings : MonoBehaviour
    {
        public GameObject LichHero;
        public GameObject FootmanHero;
        public GameObject GruntHero;

        #region MonoBehaviour members
        // Use this for initialization
        void Start()
        {
            GameObject cam = GetComponent<Camera>().gameObject;

            int index = cam.GetComponent<SaveSystem>().GetHeroIndex();
            
            switch (index)
            {
                case 0:
                    LichHero.SetActive(true);
                    break;
                case 1:
                    FootmanHero.SetActive(true);
                    break;
                case 2:
                    GruntHero.SetActive(true);
                    break;
            }
        }
#endregion

        // Update is called once per frame
        void Update()
        {

        }
    }
}
