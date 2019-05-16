using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoserScreen : MonoBehaviour
{
    public TextMeshProUGUI loserText;
    public Transform parent;

    private float time;

    void Update()
    {
        time += Time.deltaTime;
        if (time >= .5)
        {
            time = 0;
            InstanceLoser();
        }
    }

    void InstanceLoser()
    {
        TextMeshProUGUI instance = Instantiate(loserText, new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), Random.Range(-Screen.height / 2, Screen.height / 2), 0), Quaternion.identity);

        instance.transform.SetParent(parent.transform, false);
    }
}
