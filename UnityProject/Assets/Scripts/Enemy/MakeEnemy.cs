using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeEnemy : MonoBehaviour
{
    //生成する敵のプレハブ
    [SerializeField] GameObject[] enemys;
    //次の敵が出るまでの時間
    [SerializeField] float appearNextTime;
    //経過時間
    private float nowTime;
    //親のEnemysオブジェクト
    GameObject Enemys;
    Transform parent;

    //　敵出現メソッド
    void AppearEnemy()
    {
        //出現する敵をランダムに
        int randomValue = Random.Range(0, enemys.Length);
        //ランダムな個数で
        int randomNum = Random.Range(1, 2);
        //出現場所の微調整
        Vector3 positionAdjustment = new Vector3(randomNum, 0.0f, randomNum);

        //出現させる
        for (int i =0; i < randomNum; i++)
        {
            GameObject.Instantiate(enemys[randomValue], transform.position + positionAdjustment, transform.rotation, parent);
        }

        nowTime = 0.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        //時間の初期化
        nowTime = 0.0f;
        //親を探す
        Enemys = GameObject.Find("Enemys");
        parent = Enemys.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //時間を進める
        nowTime = nowTime + Time.deltaTime;

        //現在の敵残存数
        int count = Enemys.transform.childCount;

        //一定時間後，敵をリスポーン
        if (nowTime > appearNextTime)
        {
            nowTime = 0f;

            //敵残存数が10以下なら
            if(count <= 7)
            {
                AppearEnemy();
            }
        }
    }
}
