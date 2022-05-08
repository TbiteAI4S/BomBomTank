using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // ぶつかった瞬間に呼び出し
    private void OnTriggerEnter(Collider other)
    {
        //ぶつかった砲弾を破壊する
        if (other.CompareTag("Shell")|| other.CompareTag("EnemyShell"))
        {
            //ぶつかってきたオブジェクトを破壊する
            Destroy(other.gameObject);
        }
    }
}
