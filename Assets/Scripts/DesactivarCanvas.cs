using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DesactivarCanvas : NetworkBehaviour
{
    //private GameObject ParentCamera;
    void Start()
    {
        

        if (isLocalPlayer)
        {
            this.transform.gameObject.tag = "Cliente";
        }
        else
        {
            this.transform.gameObject.tag = "Servidor";
        }

        //ParentCamera = GameObject.Find("CameraParent");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Colicion_J1")
        {
            if (isLocalPlayer)
            {
                this.gameObject.GetComponent<PlayerController_J1>().enabled = true;
                //GameObject cam = GameObject.FindGameObjectWithTag("Cam1");
                //cam.SetActive(true);
                //_Canvas_Jugador = _Canvas_Jugador1;
                GameObject.FindGameObjectWithTag("Cam2").SetActive(false);
                Debug.Log("Activate Control De Jugador 1");
                
            }
        }

        else if(other.gameObject.name == "Colicion_J2")
        {
            if (isLocalPlayer)
            {
                this.gameObject.GetComponent<PlayerController_J1>().enabled = true;
                //CamaraDeJugador = _Canvas_Jugador2;
                //GameObject cam = GameObject.FindGameObjectWithTag("Cam2");
                //cam.SetActive(true);
                GameObject.FindGameObjectWithTag("Cam1").SetActive(false);
                Debug.Log("Activate Control De Jugador 2");
            }
        }
    }

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.name == "Colicion_J1")
    //    {
    //        if (isLocalPlayer)
    //        {
    //            this.gameObject.GetComponent<PlayerController_J1>().enabled = true;
    //            this.gameObject.GetComponent<PlayerController_J2>().enabled = false;
    //            //_Canvas_Jugador = _Canvas_Jugador1;
    //        }
    //    }

    //    else if (other.gameObject.name == "Colicion_J1")
    //    {
    //        if (isLocalPlayer)
    //        {
    //            this.gameObject.GetComponent<PlayerController_J2>().enabled = true;
    //            this.gameObject.GetComponent<PlayerController_J1>().enabled = false;
    //            //CamaraDeJugador = _Canvas_Jugador2;
    //        }
    //    }
    //}

}
