using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    //オブジェクトのスクリプト
    ScoreManager script;
    //タイマー
    public float time;
    public Text timeLabel;
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        //シーン切り替え後のスクリプトを取得
        var gameManager = GameObject.Find("ResultManager").GetComponent<ResultsManager>();

        //スコア(倒した敵数)
        int giveScore = script.score;

        //データを渡す
        gameManager.allscore = giveScore;

        //イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
    // Start is called before the first frame update
    void Start()
    {
        //スコアのスクリプト取得
        script = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        //タイマーの初期化
        time = 0.0f;
        //タイムラベルにスコア値を入れる
        timeLabel = GameObject.Find("TimeLabel").GetComponent<Text>();
        timeLabel.text = "残り時間：" + 60;
    }

    // Update is called once per frame
    void Update()
    {
        //タイマー更新
        time += Time.deltaTime;
        timeLabel.text = "残り時間：" + (60f - time);

        if (time >= 60.0f)//制限時間を超えるとシーン移動
        {
            SceneManager.sceneLoaded += GameSceneLoaded;

            SceneManager.LoadScene("GameClear");
        }
    }
}
