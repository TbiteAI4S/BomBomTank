using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    //エフェクト
    public GameObject effectPrefab;
    //HP
    public int objectHP;
    //破壊時のエフェクト
    public GameObject effectPrefab2;
    //ドロップアイテム
    public GameObject[] itemPrefabs;
    //スコア加算
    public int scoreValue;
    private ScoreManager sm;
    //吹っ飛びのスクリプトを取得
    Explosion explosionScript;
    //攻撃されたかの判定
    public bool damage = false;


    void Start()
    {
        //ScoreManagerのスクリプトを取得
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        //Exprotionのスクリプトを取得
        explosionScript = gameObject.GetComponent<Explosion>();
    }

    //ぶつかった瞬間に呼び出し
    private void OnTriggerEnter(Collider other)
    {
        //Tag"Shell"がぶつかったとき
        if (other.CompareTag("Shell"))
        {
            //ダメージを受けた判定
            damage = true;

            //オブジェクトのHPを１ずつ減少
            objectHP -= 1;
            if (objectHP > 0)
            {
                //ぶつかってきたオブジェクトを破壊
                Destroy(other.gameObject);
                //エフェクトを出す
                GameObject effect = Instantiate(effectPrefab, this.transform.position, Quaternion.identity);
                //エフェクトを消す
                Destroy(effect, 2.0f);
            }
            else
            {
                //ぶつかってきたオブジェクトを破壊
                Destroy(other.gameObject);

                //周りを吹き飛ばす
                explosionScript.Explode();

                //破壊エフェクトを発生
                GameObject effect2 = Instantiate(effectPrefab2, this.transform.position, Quaternion.identity);

                Destroy(effect2, 2.0f);

                //オブジェクトを破壊する
                Destroy(this.gameObject);

                //ドロップアイテムをランダムに選択
                int itemNum = Random.Range(1, itemPrefabs.Length) - 1;
                GameObject dropItem = itemPrefabs[itemNum];

                //アイテムドロップ
                Vector3 posi = this.transform.position;
                Instantiate(dropItem, new Vector3(posi.x, 0.5f, posi.z), Quaternion.identity);

                //スコア加算
                sm.AddScore(scoreValue);
            }
        }
    }
}
