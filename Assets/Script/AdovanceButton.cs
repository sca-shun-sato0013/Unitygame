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

    //曲名：魔王魂 効果音 システム37
    AudioSource audioSource;　
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
    private Button executionButton; //実行ボタン
    private Button adovanceButton;　//前進ボタン
    private Button rotateButton;　  //回転ボタン
    
    //ボタンオブジェクト
    private GameObject executionBt;
    private GameObject adovanceBt;
    private GameObject rotateBt;


    public int execution = 0;　//テキストの出力カウンタ

    public static int  positiveNegative = 0; //左移動か右移動判定用





    //============初期処理==============================
    void Start()
    {
        
        StartSetting();
        
    }

    void StartSetting() //Start関数の内容
    {
        StatusStartSetting();
        ButtonStartSetting();
        TextBoxStartSetting();
    }


    void StatusStartSetting()　//start関数のstatusの内容
    {
        for (int i = 0; i < (int)controlPanel.ARREY_LENGTH; ++i)
        {
            str[i] = i.ToString(); 
            str[i] = "Status" + str[i];

            status[i] = GameObject.Find("Canvas/" + str[i]);
            statusText[i] = status[i].GetComponent<Text>();

            number[i] = 0;
        }
    }

    void ButtonStartSetting() //start関数のボタンの内容
    {

        executionBt = GameObject.Find("Canvas/ExecutionClick");
        adovanceBt = GameObject.Find("Canvas/AdvanceButton");
        rotateBt = GameObject.Find("Canvas/RotateButton");

        executionButton = executionBt.GetComponent<Button>();
        adovanceButton = adovanceBt.GetComponent<Button>();
        rotateButton = rotateBt.GetComponent<Button>();
       
        executionButton.interactable = false;
        inputField.interactable = false;

    }


    void TextBoxStartSetting()　//start関数のtextboxの内容
    {
        inputField = inputField.GetComponent<InputField>();
        audioSource = GetComponent<AudioSource>();
        text = text.GetComponent<Text>();
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