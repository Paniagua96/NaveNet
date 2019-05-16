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
    public GameObject CamJ1;
    public GameObject Cam;
    private GameObject ParentCamera;
    void Start()
    {
        ParentCamera = GameObject.Find("CameraParent");
        /*
        if (isServer)
        {
            this.gameObject.GetComponent<PlayerController_J1>().enabled = true;
            _Canvas_Jugador = _Canvas_Jugador1;
        }
        if (isClient && this.gameObject.GetComponent<PlayerController_J1>().enabled == false)
        {
            this.gameObject.GetComponent<PlayerController_J2>().enabled = true;
            CamaraDeJugador = _Canvas_Jugador2;
            CamaraDeJugador.SetActive(true);
        }*/
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Colicion_J1")
        {
            if (isLocalPlayer)
            {
                this.gameObject.GetComponent<PlayerController_J1>().enabled = true;
                //_Canvas_Jugador = _Canvas_Jugador1;
                _Canvas_Jugador1.SetActive(true);
                _Canvas_Jugador2.SetActive(false);
                Debug.Log("Activate Control De Jugador 1");
            }
        }

        else
        {
            if (isLocalPlayer)
            {
                this.gameObject.GetComponent<PlayerController_J2>().enabled = true;
                //CamaraDeJugador = _Canvas_Jugador2;
                _Canvas_Jugador2.SetActive(true);
                _Canvas_Jugador1.SetActive(false);
                Debug.Log("Activate Control De Jugador 2");
            }
        }
    }
}
