using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //スコア値
    public int score;

    public Text scoreLabel;

    void Start()
    {
        score = 0;
        //スコアラベルにスコア値を入れる
        //scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
        scoreLabel.text = "SCORE :" + score;
    }

    //スコア増加
    public void AddScore(int amount)
    {
        score = score + amount;
        scoreLabel.text = "SCORE :" + score;
    }
}
