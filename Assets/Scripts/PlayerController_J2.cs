using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController_J2 : NetworkBehaviour
{
    public AudioSource laser;
    public Slider bulletBar;
    public Slider healthBar;
    public Rigidbody rb;
    public float speed;
    public Transform Canon;
    public GameObject bullet;
    public Interactive buttonLeft;
    public Interactive buttonRight;
    public Interactive buttonDown;
    public Interactive buttonUp;
    public Interactive buttonFire;
    public float waitTime;
    private bool shoot;

    public int maxHealth;
    public int maxBullets;
    public int currentBullet;
    [SyncVar(hook = "OnChangeHealth")] public int currentHealth;
    public int timeReload;


    [SyncVar(hook = "OnChangeGameOver")]
    public bool gameOver;

    void OnChangeGameOver(bool _gameOver)
    {
        gameOver = _gameOver;
    }

    [Command]
    public void CmdChangeGameOver()
    {
        gameOver = true;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Set health
        healthBar.maxValue = maxHealth;
        healthBar.minValue = 0;
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
        
        bulletBar.value = currentBullet;

        if (buttonFire.pulsado && shoot)
        {
            CmdCrearBala2();
        }


        if (!shoot)
        {
            waitTime -= Time.deltaTime;
        }

        if (waitTime <= 0)
        {
            waitTime = 1;
            shoot = true;
        }
        //if 
        //if (currentBullet <= 0)
        //{
        //    waitTime += Time.deltaTime;
        //}

        //if (waitTime >= timeReload)
        //{
        //    currentBullet = maxBullets;
        //    waitTime = 0;
        //}


    }



    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            Destroy(other.gameObject);
            currentHealth--;
            if (currentHealth <= 0)
            {
                //Put here what happend if health=0
                currentHealth = 0;
            }
        }
    }

    public void OnChangeHealth(int health)
    {
        healthBar.value = health;
    }

    [Command]
    void CmdCrearBala2()
    {
        Debug.Log("disparo");
        if (currentBullet <= 0)
        {
            StartCoroutine(reloadBullets());
        }
        else
        {
            Debug.Log("se va a crear una bala");
            PlayLaser();
            GameObject Bala = (GameObject) Instantiate(bullet, Canon.position, bullet.transform.rotation);
            //Bala.GetComponent<Rigidbody>().velocity = Bala.transform.up * BulletSpeed;
            NetworkServer.Spawn(Bala);
            //currentBullet--;
            shoot = false;
            Debug.Log("se creo una bala");
        }
    }

    public void PlayLaser()
    {
        if (!laser.isPlaying)
        {
            laser.Play();
            laser.loop = false;
        }
    }

    public IEnumerator reloadBullets()
    {
        yield return new WaitForSeconds(timeReload);

        currentBullet = maxBullets;

    }



}