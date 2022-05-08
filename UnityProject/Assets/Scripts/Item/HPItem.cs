using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    //エフェクト
    public GameObject effectPrefab;
    //回復音
    public AudioClip getSound;

    private TankHealth th;
    //回復量
    private int reward = 3;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //"Tank"を探してスクリプトを取得
            th = GameObject.Find("Tank").GetComponent<TankHealth>();

            //AddHPの引数rewardを入れる
            th.AddHP(reward);

            //音を出す
            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);

            //アイテムを消す
            Destroy(gameObject);

            //エフェクト
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            //エフェクトを消す
            Destroy(effect, 0.5f);
        }
    }
}
