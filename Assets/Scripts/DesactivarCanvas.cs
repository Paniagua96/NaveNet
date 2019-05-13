using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DesactivarCanvas : NetworkBehaviour
{
    public GameObject _Canvas_Jugador1;
    public GameObject CamaraDeJugador;
    private GameObject ParentCamera;
    void Start()
    {
        ParentCamera = GameObject.Find("CameraParent");

        if (isServer)
        {
            this.gameObject.GetComponent<PlayerController_J1>().enabled = true;
        }
        if (isClient && this.gameObject.GetComponent<PlayerController_J1>().enabled == false)
        {
            Debug.Log("Cliente");
            this.gameObject.GetComponent<PlayerController_J2>().enabled = true;
        }

        if (isLocalPlayer)
        {
            _Canvas_Jugador1.active = true;
            CamaraDeJugador.active = true;
        }
        else
        {
            _Canvas_Jugador1.active = false;
            CamaraDeJugador.active = false;
        }
    }
}
