using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCamara : MonoBehaviour
{

    public GameObject Cam;
    public Vector3 PocicionDeCam;
    public Vector3 RotacionDeCam;

    void Start()
    {
        Cam.SetActive(true);
        Cam.GetComponent<DesenparentarCamara>().player = gameObject.transform.parent.gameObject;
        Cam.transform.parent = null;
        Cam.transform.position = PocicionDeCam;
        Cam.transform.Rotate(RotacionDeCam);
    }
}
