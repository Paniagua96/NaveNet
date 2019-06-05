using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DesactivarCanvas : NetworkBehaviour
{
    private GameObject _Canvas_Jugador;
    public GameObject _Canvas_Jugador1;
    public GameObject _Canvas_Jugador2;
    private GameObject ParentCamera;
    void Start()
    {
        

       /* if (isLocalPlayer)
        {
            this.transform.gameObject.tag = "Cliente";
        }
        else
        {
            this.transform.gameObject.tag = "Servidor";
        }*/

        ParentCamera = GameObject.Find("CameraParent");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Colicion_J1")
        {
            if (isLocalPlayer)
            {
                this.transform.gameObject.tag = "P1";

                this.gameObject.GetComponent<PlayerController_J1>().enabled = true;
                this.gameObject.GetComponent<PlayerController_J2>().enabled = false;
                //_Canvas_Jugador = _Canvas_Jugador1;
                _Canvas_Jugador1.SetActive(true);
                _Canvas_Jugador2.SetActive(false);
                Debug.Log("Activate Control De Jugador 1");
                
            }
        }

        else if(other.gameObject.name == "Colicion_J2")
        {
            if (isLocalPlayer)
            {
                this.transform.gameObject.tag = "P2";
                this.gameObject.GetComponent<PlayerController_J2>().enabled = true;
                this.gameObject.GetComponent<PlayerController_J1>().enabled = false;
                //CamaraDeJugador = _Canvas_Jugador2;
                _Canvas_Jugador2.SetActive(true);
                _Canvas_Jugador1.SetActive(false);
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
