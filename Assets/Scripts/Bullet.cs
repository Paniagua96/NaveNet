using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed=20;

    void Start()
    {
        Destroy(gameObject,3);
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

}
