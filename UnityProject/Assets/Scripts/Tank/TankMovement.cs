using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    //移動スピード
    public float moveSpeed;
    //旋回スピード
    public float turnSpeed;
    //リグボディ
    private Rigidbody rb;
    //移動の入力値
    private float movementInputValue;
    //旋回の入力値
    private float turnInputValue;

    void Start()
    {
        //リグボディにアクセス
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Turn();
    }

    //前進・後退
    void Move()
    {
        //w,sキーの入力を受け取る
        movementInputValue = Input.GetAxis("Vertical");
        /*
         * transform.forward・・・z軸の正方向
         * Time.deltaTime・・・現在のフレームと直前のフレームとの間の時間を秒で返す
         */
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
        //リグボディに反映
        rb.MovePosition(rb.position + movement);
    }

    //旋回
    void Turn()
    {
        //a,dキーの入力を受ける
        turnInputValue = Input.GetAxis("Horizontal");
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        //リグボディに反映
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
