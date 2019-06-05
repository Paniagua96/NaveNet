using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public bool areTwo = false;

    public GameObject player1;
    public GameObject player2;

    private PlayerController_J1 playerController1;
    private PlayerController_J2 playerController2;

    void Start()
    {
        player1 = GameObject.FindWithTag("P1");
        player2 = GameObject.FindWithTag("P2");
        if (player1 && player2)
        {
            playerController1 = player1.GetComponent<PlayerController_J1>();
            playerController2 = player2.GetComponent<PlayerController_J2>();
        }
        
    }

    void Update()
    {

        player1 = GameObject.FindWithTag("P1");
        player2 = GameObject.FindWithTag("P2");

        if (player1 && player2)
        {
            areTwo = true;
            playerController1 = player1.GetComponent<PlayerController_J1>();
            playerController2 = player2.GetComponent<PlayerController_J2>();

            if (playerController1.currentHealth <= 0)
            {
                Debug.Log("Win p2");
                HP_static.winner = "dos";
                SceneManager.LoadScene("Victory");
                Destroy(player2);
                Destroy(this);
            }

            if (playerController2.currentHealth <= 0)
            {
                Debug.Log("Win p1");
                HP_static.winner = "uno";
                SceneManager.LoadScene("Victory");
                Destroy(player1);
                Destroy(this);
            }
        }

        if (!player1 || !player2)
        {
            if (areTwo == true)
            {
                SceneManager.LoadScene("Victory");
            }
        }

        
    }
}