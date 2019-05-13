using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParent : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("entro");
            //Jugador.transform.parent = PlataformaMov.transform;
            //other.gameObject.transform.parent = this.transform;
            this.gameObject.transform.parent = other.transform;
        }
    }
}
