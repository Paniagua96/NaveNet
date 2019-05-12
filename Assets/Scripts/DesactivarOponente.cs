using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DesactivarOponente : NetworkBehaviour
{
    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponent<DesactivarOponente>().enabled = true;
            this.transform.gameObject.SetActive(true);
            this.transform.gameObject.tag = "Cliente";
        }
        else
        {
            GetComponent<DesactivarOponente>().enabled = false;
            this.transform.gameObject.SetActive(false);
            this.transform.gameObject.tag = "Server";
        }
    }
}
