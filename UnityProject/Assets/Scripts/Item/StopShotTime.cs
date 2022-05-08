using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopShotTime : MonoBehaviour
{
    //射撃ストップ先
    private GameObject[] targets;
    //音
    public AudioClip getSound;
    //エフェクト
    public GameObject effectPrefab;
    //吹っ飛びのスクリプトを取得
    Explosion explosionScript;

    private void Start()
    {
        //Exprotionのスクリプトを取得
        explosionScript = gameObject.GetComponent<Explosion>();
    }
    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("EnemyShotShell");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < targets.Length; i++)
            {
                //攻撃停止時間3s加算
                targets[i].GetComponent<EnemyShotShell>().AddStopTimer(3.0f);
            }
            //音を出す
            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);

            //周りを吹き飛ばす
            explosionScript.Explode();

            //アイテムを消す
            Destroy(gameObject);

            //エフェクト
            GameObject effect = (GameObject)Instantiate(effectPrefab, transform.position, Quaternion.identity);

            //エフェクト削除
            Destroy(effect, 0.5f);
        }
    }
}
