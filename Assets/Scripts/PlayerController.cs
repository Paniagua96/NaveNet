using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Transform Canon;
    public GameObject bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 DirectionX = Input.GetAxis("Horizontal") * Vector3.right;
        Vector3 DirectionZ = Input.GetAxis("Vertical") * Vector3.forward;

        Vector3 Direction = DirectionX + DirectionZ;
        Vector3 VectorVelocity = Direction * speed;

        rb.velocity = VectorVelocity;

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(bullet, Canon.position, bullet.transform.rotation);

        }

    }
}