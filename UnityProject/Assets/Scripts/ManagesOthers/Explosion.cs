using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //ぶっ飛びの力
    [SerializeField] float force = 10;
    //ぶっ飛びの半径
    [SerializeField] float radius = 10;
    //ぶっ飛びの上方向の力
    [SerializeField] float upwards = 5;
    //発生源
    Vector3 position;


    public void Explode()
    {
        //発生源はアタッチされたオブジェクトの所
        position = this.transform.position;

        // 範囲内のオブジェクトを吹き飛ばす
        Collider[] hitColliders = Physics.OverlapSphere(position, radius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Rigidbody rb = hitColliders[i].GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(force, position, radius, upwards, ForceMode.Impulse);
            }
        }
    }
}
