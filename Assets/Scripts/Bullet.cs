using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;


    void Start()
    {
        Destroy(gameObject, 3);
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.name == "Colicion_J1")
        {
            speed = 20;
        }

        if (other.gameObject.name == "Colicion_J2")
        {
            speed = -20;
        }
    }
}
