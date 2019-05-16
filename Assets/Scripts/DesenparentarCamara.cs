using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Networking;

public class DesenparentarCamara : NetworkBehaviour
{
    public GameObject player;
    void Start()
    {

    }

    void Update()
    {
        if (player == null)
        {
            Debug.Log("destory");
            Destroy(gameObject);
        }
    }
}
