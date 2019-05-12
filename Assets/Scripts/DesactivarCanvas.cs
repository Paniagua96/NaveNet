using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DesactivarCanvas : NetworkBehaviour
{
    public GameObject _Canvas;
    void Start()
    {
        if (isLocalPlayer)
        {
            _Canvas.active = true;
        }
        else
        {
            _Canvas.active = false;
        }
    }
}
