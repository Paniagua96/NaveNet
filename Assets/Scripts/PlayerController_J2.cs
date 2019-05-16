using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController_J2 : NetworkBehaviour
{
    public Slider bulletBar;
    //public Slider healthBar;
    public Rigidbody rb;
    public float speed;
    public Transform Canon;
    public GameObject bullet;
    public Interactive buttonLeft;
    public Interactive buttonRight;
    public Interactive buttonDown;
    public Interactive buttonUp;
    public Interactive buttonFire;

    public int maxHealth;
    public int maxBullets;
    private int currentBullet;
    public int currentHealth;
    public int timeReload;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Set health
        //healthBar.maxValue = maxHealth;
        //healthBar.minValue = 0;
        currentHealth = maxHealth;

        //Set Bullets
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
        }
        else if (buttonRight.pulsado)
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

        //healthBar.value = currentHealth;
        bulletBar.value = currentBullet;

        if (buttonFire.pulsado)
        {
            CmdCrearBala();
        }


    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                //Put here what happend if health=0
                currentHealth = 0;
            }
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