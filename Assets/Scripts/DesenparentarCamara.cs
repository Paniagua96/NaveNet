using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Networking;

public class DesenparentarCamara : NetworkBehaviour
{
    public GameObject EstaCam;
    void Start()
    {
        this.transform.parent = null;
        if (isLocalPlayer)
        {
            EstaCam.SetActive(false);
        }
        else
        {
            EstaCam.SetActive(false);
        }
    }
}
