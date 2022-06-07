//ソースコードの命令規則
//関数、型名は(UCC：Upper Camel Case)/パスカルケース (Pascal Case)(LCC：Lower Camel Case）
//変数は(LCC：Lower Camel Case）

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeUp : MonoBehaviour
{
    
    private float countMeter = 300.0f; //制限時間

    private GameObject timeMeter, timeUpText;

    //時間を表示するText型の変数
    private　Text　time, timeText;

    void Start()
    {
         timeMeter = GameObject.Find("Canvas/Time");
              time = timeMeter.GetComponent<Text>();

        timeUpText = GameObject.Find("Canvas/TimeText");
          timeText = timeUpText.GetComponent<Text>();
    }
        

    // Update is called once per frame
    void Update()
    {
        if(countMeter >= 0 ){countMeter -= Time.deltaTime;}//時間をカウントダウンする
        

        //時間を表示する
        time.text = countMeter.ToString("f2") + "秒"; //f2 小数点第二位

        //countdownが0以下になったとき
        if (countMeter <= 0)
        {
            timeText.text = "TIME UP";
            Invoke("Chenge", 2);
        }

    }
    void Chenge()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}






    

