using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 別忘了要追加 UI 必要程式

public class GameManager : MonoBehaviour
{
    public GameObject arrowPrefab; //置放Prefab的公開變數
    float span = 1.0f;             //時間間隔
    float delta = 0;               //現在已經累積的時間
    public GameObject hpGauge;     //置放血環的公開變數
    public Text ScoreText;
    int Score = 0;                 // 分數

    void Start()
    {
        ScoreText.text = $"分數：{Score}";
        //ScoreText.text = "分數：" + Score.ToString();
        InvokeRepeating("MakeArrow", 2, 1.0f);
    }

    void Update()
    {
        delta += Time.deltaTime;  // 累積時間到delta
        if (delta > span) // 如果delta時間累積大於span時間間隔
        {
            delta = 0; // delta時間歸零
        }
    }

    void MakeArrow()
    {
        int px = Random.Range(-6, 7); // 隨機產生一個-6到6之間的整數
        Instantiate(arrowPrefab, new Vector3(px, 7, 0), Quaternion.identity); // 產生新箭頭，並且設定新箭頭的位置
    }

    // 公開（Public）的方法（DecreaseHp），每執行一次，Fill Amount的數值就減少0.1
    public void DecreaseHp()
    {
        hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }

    public void IncreaseScore()
    {
        Score += 10;
        ScoreText.text = $"分數：{Score}";
    }
}
