using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescue : MonoBehaviour
{
    public Vector3 pos;

    //ステージ外に出たときにステージに戻す
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
    }
}
