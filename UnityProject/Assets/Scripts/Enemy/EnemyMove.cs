using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    //ターゲット
    public GameObject target;
    public GameObject targetPlayer;
    public GameObject targetPoint1;
    public GameObject targetPoint2;
    public GameObject targetPoint3;
    private NavMeshAgent agent;
    //移動先の決定
    int movePoint = 0;
    //Playerを見つけたかどうか
    public bool findPlayer = false;
    //視界の範囲
    public float viewRange = 1;
    //ダメージを受けたどうか
    GameObject obj;
    DestroyObject destroyObjectScript;


    //行先の決定
    GameObject DecidingWhereToGo(int point, GameObject where)
    {
        if (point == 0)
        {
            //Point1に移動
            where = targetPoint1;
        }
        else if (point == 1)
        {
            //Point2に移動
            where = targetPoint2;
        }
        else if (point == 2)
        {
            //Point3に移動
            where = targetPoint3;
        }
        return where;
    }

    //プレイヤーを見つけたかどうか
    void FindPlayer()
    {
        //前方
        Ray ray = new Ray(transform.position, transform.forward);
        //rayのあたり判定
        RaycastHit hit;
        //Raycast(開始地点,向き,当たったもの,rayの距離)
        if (Physics.Raycast(ray, out hit, 10))
        {
            string hitName = hit.transform.gameObject.tag;

            //rayがPlayerに当たったら
            if (hitName == "Player")
            {
                findPlayer = true;
                target = targetPlayer;
                return;
            }
        }

        //右斜め
        Ray rayRight = new Ray(transform.position, transform.forward + transform.right * viewRange);
        //rayのあたり判定
        RaycastHit hitRight;
        //Raycast(開始地点,向き,当たったもの,rayの距離)
        if (Physics.Raycast(rayRight, out hitRight, 10))
        {
            string hitName = hitRight.transform.gameObject.tag;

            //rayがPlayerに当たったら
            if (hitName == "Player")
            {
                findPlayer = true;
                target = targetPlayer;
                return;
            }
        }

        //左斜め
        Ray rayLeft = new Ray(transform.position, transform.forward + (-transform.right * viewRange));
        //rayのあたり判定
        RaycastHit hitLeft;
        //Raycast(開始地点,向き,当たったもの,rayの距離)
        if (Physics.Raycast(rayLeft, out hitLeft, 10))
        {
            string hitName = hitLeft.transform.gameObject.tag;

            //rayがPlayerに当たったら
            if (hitName == "Player")
            {
                findPlayer = true;
                target = targetPlayer;
                return;
            }
        }

        //ダメージを受けたらプレイヤーを追跡
        if (destroyObjectScript.damage == true)
        {
            findPlayer = true;
            target = targetPlayer;
            return;
        }
    }

    void Start()
    {
        //ナビメッシュを取得
        agent = GetComponent<NavMeshAgent>();
        //ターゲットを取得
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        targetPoint1 = GameObject.Find("MovePoint1");
        targetPoint2 = GameObject.Find("MovePoint2");
        targetPoint3 = GameObject.Find("MovePoint3");

        //ダメージを受けたどうかのスクリプトを取得
        destroyObjectScript = this.GetComponent<DestroyObject>();

        //ランダムに移動ポイントを設定
        movePoint = Random.Range(0, 2);
        target = DecidingWhereToGo(movePoint, target);
    }

    void Update()
    {
        //ナビメッシュ領域から外れた場合補正
        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            transform.position = hit.position;
        }

        //ターゲットの位置へ向かう
        agent.destination = target.transform.position;

        /*---Playerが視界に入ったか判定---*/
        FindPlayer();
        Debug.DrawRay(transform.position, transform.forward * 10, Color.green);
        Debug.DrawRay(transform.position, (transform.forward+transform.right* viewRange) * 10, Color.red);
        Debug.DrawRay(transform.position, (transform.forward + (-transform.right* viewRange)) * 10, Color.blue);

        //Playerを見つけていない時
        if (findPlayer == false)
        {
            //ターゲットに近づくとターゲットを変更
            Vector3 nowDistance = this.transform.position - target.transform.position;
            float nowDistance2 = nowDistance.sqrMagnitude;
            if (nowDistance2 < 10.0f)
            {
                //次のポイントを決める
                movePoint += Random.Range(1, 2);
                //movePointが2より大きいとき0～2の間に戻す
                if (movePoint > 2)
                {
                    movePoint = movePoint - 3;
                }
                //次の行先に変更
                target = DecidingWhereToGo(movePoint, target);
            }
        }
    }
}
