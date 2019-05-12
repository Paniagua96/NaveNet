using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public Slider bulletBar;
    public Rigidbody rb;
    public float speed;
    public float BulletSpeed;
    public Transform Canon;
    public GameObject bullet;
    public Interactive buttonLeft;
    public Interactive buttonRight;
    public Interactive buttonDown;
    public Interactive buttonUp;
    public Interactive buttonFire;

    public int maxBullets;
    private int currentBullet;
    public int timeReload;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bulletBar.maxValue = maxBullets;
        bulletBar.minValue = 0;
        currentBullet = maxBullets;
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

        Vector3 Direction = DirectionX + DirectionZ;
        Vector3 VectorVelocity = Direction * speed;

        rb.velocity = VectorVelocity;

        bulletBar.value = currentBullet;

        if (buttonFire.pulsado)
        {
            CmdCrearBala();
        }


    }

    [Command]
    void CmdCrearBala()
    {
        if (currentBullet <= 0)
        {
            StartCoroutine(reloadBullets());
        }
        else
        {
            GameObject Bala = (GameObject) Instantiate(bullet, Canon.position, bullet.transform.rotation);
            //Bala.GetComponent<Rigidbody>().velocity = Bala.transform.up * BulletSpeed;
            NetworkServer.Spawn(Bala);
            currentBullet--;
        }
    }


    public IEnumerator reloadBullets()
    {
        yield return new WaitForSeconds(timeReload);

            currentBullet = maxBullets;
     
    }

    
   
}