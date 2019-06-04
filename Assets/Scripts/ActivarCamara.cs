using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCamara : MonoBehaviour
{

    public GameObject Cam;
    public GameObject start;

    void Start()
    {
        Cam.SetActive(true);
        Cam.GetComponent<DesenparentarCamara>().player = gameObject.transform.parent.gameObject;
        Vector3 temp = transform.parent.position;
        Quaternion temporot = transform.parent.rotation;
        Cam.transform.parent = null;
        Cam.transform.position = temp;
        Cam.transform.rotation = temporot;
    }
}
