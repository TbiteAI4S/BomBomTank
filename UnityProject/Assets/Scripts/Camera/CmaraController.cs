using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmaraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;
    public Camera backCamera;
    //カメラを使うかどうか
    private bool mainCameraON = true;
    private bool subCameraON = false;
    //照準UI
    public GameObject aimImage;
    //プレイヤー
    private GameObject playerTank;

    void Start()
    {
        mainCamera.enabled = true;
        subCamera.enabled = false;
        backCamera.enabled = false;

        //mainでは照準UIをオフにする
        aimImage.SetActive(false);

        playerTank = GameObject.Find("Tank");
    }

    void Update()
    {
        //視点がぐるぐる回転したらバックカメラにする
        if (playerTank.transform.localEulerAngles.x > 5 || playerTank.transform.localEulerAngles.z > 5||
            playerTank.transform.localEulerAngles.x < -5 || playerTank.transform.localEulerAngles.z < -5)
        {
            mainCamera.enabled = false;
            subCamera.enabled = false;
            backCamera.enabled = true;

            mainCameraON = false;
            subCameraON = false;
            aimImage.SetActive(false);
        }
        else
        {
            backCamera.enabled = false;
            //もしカメラが選択されていないならメインカメラ
            if (mainCameraON == false && subCameraON == false)
            {
                mainCamera.enabled = true;
                mainCameraON = true;
            }
            //視点を近づける
            if (Input.GetKeyDown(KeyCode.Mouse1) && mainCameraON == true)
            {
                mainCamera.enabled = false;
                subCamera.enabled = true;

                mainCameraON = false;
                subCameraON = true;

                //照準UIオン
                aimImage.SetActive(true);

            }//視点を元に戻す
            else if (Input.GetKeyDown(KeyCode.Mouse1) && mainCameraON == false)
            {
                mainCamera.enabled = true;
                subCamera.enabled = false;

                mainCameraON = true;
                subCameraON = false;

                //照準UIオフ
                aimImage.SetActive(false);
            }

        }

    }
}
