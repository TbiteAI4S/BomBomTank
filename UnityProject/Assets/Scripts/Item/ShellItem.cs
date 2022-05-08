using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellItem : MonoBehaviour
{
    //取得音
    public AudioClip getSound;
    //エフェクト
    public GameObject effectPrefab;

    private ShotShell shotShell;
    //回復数
    private int reward = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //"ShotShell"を探してスクリプトを取得
            shotShell = GameObject.Find("ShotShell").GetComponent<ShotShell>();

            //shotShellのAddShellの引数にrewardを入れる
            shotShell.AddShell(reward);

            //アイテムゲット音を出す。
            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);

            //アイテム削除
            Destroy(gameObject);

            //エフェクトを発生
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            //エフェクトを0.5s後に消す
            Destroy(effect, 0.5f);
        }
    }
}
