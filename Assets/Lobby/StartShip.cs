using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShip : MonoBehaviour
{
    public GameObject ship1;
    public GameObject ship2;
    public GameObject ship3;
    public GameObject finalShip;

    void Start()
    {
        if (SingletonShip.ship == 1)
        {
            finalShip = Instantiate(ship1, this.transform.position, Quaternion.identity);
            finalShip.transform.Rotate(-90, 0,0);
            finalShip.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            Destroy(this);
        }else if (SingletonShip.ship == 2)
        {
            finalShip = Instantiate(ship2, transform.position, Quaternion.identity);
            finalShip.transform.Rotate(-90, 0, 0);
            finalShip.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            Destroy(this);
        }else if (SingletonShip.ship == 3)
        {
            finalShip = Instantiate(ship3, transform.position, Quaternion.identity);
            finalShip.transform.Rotate(-90, 0, 0);
            finalShip.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            Destroy(this);
        }
    }
}

   
