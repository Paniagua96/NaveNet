using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class CondicionDerrota : NetworkBehaviour
{
    PlayerController_J1 player_1;
    PlayerController_J2 player_2;

    GameObject otherPlayer;

    private void Start()
    {
        otherPlayer = GameObject.FindGameObjectWithTag("Server");

        if (player_1.isActiveAndEnabled)              //is player 1
        {
            player_1 = this.GetComponent<PlayerController_J1>();
        } else if (player_2.isActiveAndEnabled)      //is player 2
        {
            player_2 = this.GetComponent<PlayerController_J2>();
        }
        
    }

    private void Update()
    {
        if (player_1.isActiveAndEnabled)
        {
            if (player_1.currentHealth <= 0)
            {
                SceneManager.LoadScene("Defeat");
            }
        } else if (player_2.isActiveAndEnabled)
        {
            if (player_2.currentHealth <= 0)
            {
                SceneManager.LoadScene("Defeat");
            }
        }

        otherPlayerDead();
    }

    private void otherPlayerDead()
    {
        if (otherPlayer != null)
        {
            SceneManager.LoadScene("Victory");
        }
    }


}









/*
 * CLASE
 * 
static public Transform player;
public float distance = 10;
public float height = 5;
public Vector3 lookOffset = new Vector3(0, 1, 0);
public float cameraSpeed = 10;
public float rotSpeed = 10;

void LateUpdate()
{
    if(player)
    {
        Vector3 lookPosition = player.position + lookOffset;
        Vector3 realtivePos = lookPosition - Transform.position;
        Quaternion rot = Quaternion.LookRotation(relativePos);

        Transform.rotation = Quaternion.Slerp(this.transform.rotation, rot, time.deltatime * rotspeed *0.1f);
        Vector3 targetPos = player.transform.positon + player.transform.up * height - player.transform.forward * distance;
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, time.deltatime * cameraspeed *0.1f);
    }
}

    */
