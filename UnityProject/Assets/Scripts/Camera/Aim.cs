using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    //照準器の画像
    public Image aimImage;

    void Update()
    {
        //rayを飛ばす
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 30, Color.green);

        //rayのあたり判定
        RaycastHit hit;

        //Raycast(開始地点,向き,当たったもの,rayの距離)
        if (Physics.Raycast(ray, out hit, 60))
        {
            string hitName = hit.transform.gameObject.tag;

            //rayがEnemyに当たったら
            if (hitName == "Enemy")
            {
                // 赤にする
                aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            else
            {
                //水色にする
                aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
            }
        }
        else
        {
            //水色にする
            aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
