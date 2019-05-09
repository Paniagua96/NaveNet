using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Transform Canon;
    public GameObject bullet;
    public Interactive buttonLeft;
    public Interactive buttonRight;
    public Interactive buttonDown;
    public Interactive buttonUp;
    public Interactive buttonFire;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float directionX;

        if (buttonLeft.pulsado)
        {
            directionX = -1;
        }else if (buttonRight.pulsado)
        {
            directionX = 1;
        }
        else
        {
            directionX = 0;

        }

        float directionY;

        if (buttonDown.pulsado)
        {
            directionY = -1;
        }
        else if (buttonUp.pulsado)
        {
            directionY = 1;
        }
        else
        {
            directionY = 0;

        }


        Vector3 DirectionX = directionX * Vector3.right;
        Vector3 DirectionZ = directionY * Vector3.forward;

        DirectionZ = Input.GetAxis("Vertical") * Vector3.forward;

        Vector3 Direction = DirectionX + DirectionZ;
        Vector3 VectorVelocity = Direction * speed;

        rb.velocity = VectorVelocity;

        if (buttonFire.pulsado)
        {
            Instantiate(bullet, Canon.position, bullet.transform.rotation);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(bullet, Canon.position, bullet.transform.rotation);

        }

    }

   
}