using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankRecover : MonoBehaviour
{
    private Vector3 re;

    void Update()
    {
        re = transform.eulerAngles;
        //こけたときに元に戻す
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.eulerAngles = new Vector3(0, re.y, 0);
        }
    }
}
