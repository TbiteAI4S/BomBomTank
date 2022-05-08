using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsManager : MonoBehaviour
{
    //スコアの値
    public int allscore;
    //表示テキスト
    public Text textFrame;

    // Start is called before the first frame update
    void Start()
    {
        //UIに反映
        textFrame.text = string.Format("Score：" + allscore);
    }
}
