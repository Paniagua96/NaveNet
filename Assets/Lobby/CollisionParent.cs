using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParent : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DesactivarCanvas>())
        {
            //Debug.Log("entro");
            //Jugador.transform.parent = PlataformaMov.transform;
            //other.gameObject.transform.parent = this.transform;
            this.gameObject.transform.parent = other.transform;
        }

        if (other.gameObject.name == "Colicion_J2")
        {
            Debug.Log("entro1");
            if (SingletonShip.ship == 1 || SingletonShip.ship == 3)
                this.gameObject.transform.Rotate(180, 0, 0);
            Destroy(this);
        }

        if (other.gameObject.name == "Colicion_J1")
        {
            Debug.Log("entro2");
            if (SingletonShip.ship == 2)
                this.gameObject.transform.Rotate(180, 0, 0);
            Destroy(this);
        }
    }
}
