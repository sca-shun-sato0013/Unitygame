//ソースコードの命令規則
//関数、型名は(UCC：Upper Camel Case)/パスカルケース (Pascal Case)(LCC：Lower Camel Case）
//変数は(LCC：Lower Camel Case）

using UnityEngine;
using UnityEngine.UI;



public class AdovanceButton : MonoBehaviour
{
     private  enum controlPanel　//コントロール画面に使われている配列の要素数
     {
      STR_ARREY = 20,
      NUMBER_ARREY = 20,
      STATUS_ARREY = 20,
      ARREY_LENGTH = 20, //for文での配列の要素数
      STATUS_TEXT_ARREY = 20
      
     };
    
    //ボタンクリック時のサウンド
    AudioSource audioSource;　//
    public AudioClip sound1;
   
    
    //テキストボックス
    public InputField inputField;
    public Text text;

　 //各配列の宣言と初期化
   private GameObject[] status = new GameObject[(int)controlPanel.STATUS_ARREY];
   private Text[] statusText = new Text[(int)controlPanel.STATUS_TEXT_ARREY];
   private string[] str = new string[(int)controlPanel.STR_ARREY];
   public static int[] number = new int[(int)controlPanel.NUMBER_ARREY];


    //ボタン
    public Button executionButton; //実行ボタン
    public Button adovanceButton;　//前進ボタン
    public Button rotateButton;　  //回転ボタン
    
    public int execution = 0;　//テキストの出力カウンタ

    public static int  positiveNegative = 0; //左移動か右移動判定用


        

   

    void Start()
    {
        
        StartSetting();//Start関数内容
        
    }

    void StartSetting() 
    {


        for (int i = 0; i < (int)controlPanel.ARREY_LENGTH; ++i)
        {
            str[i] = i.ToString(); //型変換
            str[i] = "Status" + str[i];

            status[i] = GameObject.Find("Canvas/" + str[i]);
            statusText[i] = status[i].GetComponent<Text>();



            number[i] = 0;
        }



        //Componentを扱えるようにする
        inputField = inputField.GetComponent<InputField>();
        text = text.GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();




        executionButton.interactable = false;
        inputField.interactable = false;
    }
    public void InputText() //テキスト入力時イベント発生
    {
        for(int i = 0; i < (int)controlPanel.ARREY_LENGTH; ++i)
        {
            if(execution == i)
            {
                text.text = inputField.text;
                statusText[i].text += text.text + "秒";
                number[i] = int.Parse(text.text);
            }
        }
        
        
        
    }

    public void AdovanceClick()　//前進ボタン入力時イベント発生
    {
        audioSource.PlayOneShot(sound1);
        executionButton.interactable = true;
         adovanceButton.interactable = false;
           rotateButton.interactable = false;
        
        inputField.interactable = true;

        for(int i = 0; i < status.Length; ++i)
        {
            if(execution == i)
            {
                positiveNegative = 0;
                statusText[i].text = "前進 :";
            }
        }

    }
    public void RotateClick() //回転ボタン入力時イベント発生
    {
        audioSource.PlayOneShot(sound1);
        executionButton.interactable = true;
        adovanceButton.interactable = false;
        rotateButton.interactable = false;
        inputField.interactable = true;


        for (int i = 0; i < (int)controlPanel.ARREY_LENGTH; ++i)
        {
            if (execution == i)
            {
                positiveNegative = 1;
                statusText[i].text = "回転 :";
            }
        }


    }

    public void ExecutionClick()　//実行ボタン入力時イベント発生
    {
        audioSource.PlayOneShot(sound1);
        executionButton.interactable = false;
        inputField.interactable = false;
        
        for(int i = 0; i < (int)controlPanel.ARREY_LENGTH; ++i)
        {
            if(AdovanceButton.number[i] != 0)
            {
                Invoke("ButtonLift", AdovanceButton.number[i]);
            }
        }

        
        ++execution;


    }
    

    void ButtonLift()　//実行ボタンを押されてからプレイヤーの移動が終わったらイベント発生
    {
        adovanceButton.interactable = true;
        rotateButton.interactable = true;

        
        for(int i = 0; i < (int)controlPanel.ARREY_LENGTH; ++i)
        {
            number[i] = 0;　//number変数はPlayerControllerで使用されている。
        }                  //その他での使用注意！
       

    }
  
}