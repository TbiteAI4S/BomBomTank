using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlinker : MonoBehaviour
{
    //点滅スピード
    public float speed = 1.0f;
    //点滅させるテキスト
    private Text text;
    //点滅の時間
    private float time;

    //テキストのアルファ値を変化させる
    Color Blinker(Color color)
    {
        time = time + Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time)*2.0f;

        return color;
    }

    // Start is called before the first frame update
    void Start()
    {
        //テキストを取得
        text = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //テキストのアルファ値を変化
        text.color = Blinker(text.color);
    }
}
