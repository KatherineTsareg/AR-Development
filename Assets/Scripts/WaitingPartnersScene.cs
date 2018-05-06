using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class WaitingPartnersScene : MonoBehaviour
    {
        #region MonoBehaviour members
        // Use this for initialization
        void Start()
        {
            GameObject cam = GetComponent<Camera>().gameObject;

            var server = cam.GetComponent<Server>();
            
            GameObject.Find("IpInputField").GetComponent<InputField>().text = server.ip;
            GameObject.Find("PortInputField").GetComponent<InputField>().text = server.port;
            GameObject.Find("ClientsInputField").GetComponent<InputField>().text = Convert.ToString(2);
        }
#endregion

        // Update is called once per frame
        void Update()
        {

        }
    }
}
