using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotShell : MonoBehaviour
{
    //砲弾のprefab
    public GameObject shellPrefab;
    //発射速度
    public float shotSpeed;
    //発射音
    public AudioClip shotSound;
    //残段管理
    public int shotCount;
    //残段表示
    public Text shellLabel;
    //リロード音
    public AudioClip shotSound2;
    //発射間隔
    private float timeBetweenShot = 1.0f;
    private float timer;

    void Start()
    {
        shellLabel.text = "砲弾 :" + shotCount;
    }

    void Update()
    {
        timer = timer + Time.deltaTime;

        //タイマーが発射間隔を超える + スペースを押す
        if (Input.GetKeyDown(KeyCode.Mouse0) && timer > timeBetweenShot)
        {
            //音を鳴らす
            AudioSource.PlayClipAtPoint(shotSound2, transform.position);


            if (shotCount < 1)
            {
                return;
            }


            //残段を減らす
            shotCount = shotCount - 1;
            shellLabel.text = "砲弾 :" + shotCount;

            //タイマーリセット
            timer = 0.0f;

            //砲弾のprefabをインスタンス化
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);

            //砲弾に付いているRigidbodyにアクセス
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            //Z軸の正方向に力を加える
            shellRb.AddForce(transform.forward * shotSpeed);

            //発射した砲弾を３秒後に破壊
            Destroy(shell, 3.0f);

            //砲弾の発射音を出す
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }

    //残段追加
    public void AddShell(int amount)
    {
        //amount分だけ回復
        shotCount += amount;

        //残段の最大値
        if (shotCount > 30)
        {
            shotCount = 30;
        }

        //UIに反映
        shellLabel.text = "砲弾 :" + shotCount;
    }
}
