using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    //対象オブジェクト
    [SerializeField]
    private Transform tank;

    //対象の中心
    [SerializeField]
    private Transform pivot;

    void Start()
    {
        //エラーが起きないようにNullだった場合、それぞれ設定
        if (tank == null)
            tank = transform.parent;
        if (pivot == null)
            pivot = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //マウスのX,Y軸の移動
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");

        //左右視点移動(マウスのX軸をY軸に反映)
        tank.transform.Rotate(0, X_Rotation, 0);

        //上下視点移動
        float nowAngle = pivot.transform.localRotation.x;

        //最大値、または最小値を超えた場合カメラを止める
        if (-Y_Rotation != 0)
        {
            if (0 < Y_Rotation)
            {
                if (-0.5 <= nowAngle)
                {
                    pivot.transform.Rotate(-Y_Rotation, 0, 0);
                }
            }
            else
            {
                if (nowAngle <= 0.5)
                {
                    pivot.transform.Rotate(-Y_Rotation, 0, 0);
                }
            }
        }
    }
}
