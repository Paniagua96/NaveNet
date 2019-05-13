using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectNav : MonoBehaviour
{
    public GameObject prefabShip;
    public GameObject prefabShip2;
    public GameObject prefabShip3;
    

    // Start is called before the first frame update
    void Start()
    {
        SingletonShip.ship = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeShip1()
    {
        prefabShip.SetActive(true);
        prefabShip2.SetActive(false);
        prefabShip3.SetActive(false);
        SingletonShip.ship = 1;
    }

    public void changeShip2()
    {
        prefabShip.SetActive(false);
        prefabShip2.SetActive(true);
        prefabShip3.SetActive(false);
        SingletonShip.ship = 2;
    }

    public void changeShip3()
    {
        prefabShip.SetActive(false);
        prefabShip2.SetActive(false);
        prefabShip3.SetActive(true);
        SingletonShip.ship = 3;
    }

    public void GotoGame(string escena)
    {
        SceneManager.LoadScene("Game");
    }
}
