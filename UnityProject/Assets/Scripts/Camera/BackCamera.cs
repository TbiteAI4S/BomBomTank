using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCamera : MonoBehaviour
{
    public GameObject target;
    private Vector3 distance;

    void Start()
    {
        distance = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        //追従
        transform.position = target.transform.position + distance;
    }
}
