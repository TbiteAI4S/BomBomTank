using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotShell : MonoBehaviour
{
    //砲弾のprefab
    public GameObject enemyShellPrefab;
    //発射速度
    public float shotSpeed;
    //発射音
    public AudioClip shotSound;
    //発射間隔
    private int shotIntarval;
    //射撃を止める時間
    public float stopTimer = 5.0f;
    //敵を見つけたかどうかの判断
    GameObject parentObject;
    EnemyMove enemyMoveScript;

    void Start()
    {
        //敵を見つけたかどうかの判断のスクリプト取得
        parentObject = transform.parent.gameObject;
        enemyMoveScript = parentObject.GetComponent<EnemyMove>();
    }

    void Update()
    {
        //射撃間隔
        shotIntarval = shotIntarval + 1;

        //射撃を止める
        stopTimer = stopTimer - Time.deltaTime;

        if (stopTimer < 0)
        {
            stopTimer = 0;
        }


        if (shotIntarval % 300 == 0 && stopTimer <= 0)
        {
            if (enemyMoveScript.findPlayer == false)
            {
                return;
            }
            //砲弾のprefabをインスタンス化
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

            //砲弾に付いているRigidbodyにアクセス
            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            //Z軸の正方向に力を加える
            enemyShellRb.AddForce(transform.forward * shotSpeed);

            //砲弾の発射音を出す
            AudioSource.PlayClipAtPoint(shotSound, transform.position);

            //発射した砲弾を３秒後に破壊
            Destroy(enemyShell, 3.0f);
        }
    }

    //射撃を止める時間
    //アイテムを複数取ると加算
    public void AddStopTimer(float amount)
    {
        stopTimer = stopTimer + amount;
    }
}
