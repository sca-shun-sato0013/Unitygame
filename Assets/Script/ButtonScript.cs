//ソースコードの命令規則
//関数、型名は(UCC：Upper Camel Case)/パスカルケース (Pascal Case)(LCC：Lower Camel Case）
//変数は(LCC：Lower Camel Case）

using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private enum controlPanel //コントロール画面に使われている配列の要素数
    {
        STR_ARREY = 20,    
        STATUS_ARREY = 20,
        ARREY_LENGTH = 20, //for文での配列の要素数
        STATUS_POS_ARREY = 20

    };

    //曲名：魔王魂 効果音 システム37
    AudioSource audioSource;
    public AudioClip sound1;
    
    //コントロール画面背景
    public RectTransform image;

    //ボタン類
    public RectTransform Click; //実行ボタン
    public RectTransform adovanceButton; //前進ボタン
    public RectTransform rotateButton; //回転ボタン

    //テキストボックス
    public RectTransform inputField;
    public RectTransform placeholder;
    public RectTransform text;

    //各配列の宣言と初期化
    private GameObject[] status = new GameObject[(int)controlPanel.STATUS_ARREY];
    private RectTransform[] statusPos = new RectTransform[(int)controlPanel.STATUS_POS_ARREY];
    private string[] str = new string[(int)controlPanel.STR_ARREY];

    //画面の移動判定
    private int counter = 0;　//ボタンのクリック判定用
    private int num = 0; //画面外か画面内かの判定用
    private int sum = 1; //画面外か画面内かの判定用


    private float    move = 10.0f; //画面の移動量



    //============初期処理==============================
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StatusStartSetting();
        
    }
  

    void StatusStartSetting() //Start関数の内容Statusだけ
    {
        for (int i = 0; i < (int)controlPanel.ARREY_LENGTH; ++i)
        {
            str[i] = i.ToString(); 
            str[i] = "Status" + str[i];

            status[i] = GameObject.Find("Canvas/" + str[i]);
            statusPos[i] = status[i].GetComponent<RectTransform>();
        }
    }


    //=================主処理 =========================
    void Update()
    {
        UpdateSetting();
    }

    
    void UpdateSetting() //Update関数の内容
    {
        text.position = inputField.position;
        placeholder.position = inputField.position;

        if (num > 0 && sum > 0)　//もし、画面上にコントロール画面が表示されていなければ移動する
        {
            Button_TextBox_Move(); 
            StatusMove(); 

            counter++;
        }

        if (counter > (int)controlPanel.ARREY_LENGTH - 1) //配列の要素数-1　
        {
            counter = 0;
            num = 0;
            sum = -1;
        }

        if (num > 0 && sum < 0) //もし、画面上にコントロール画面が表示されていれば逆移動する
        {
            Button_TextBox_ReMove(); 
            StatusReMove(); 

            counter++;
        }

        if (counter > (int)controlPanel.ARREY_LENGTH - 1)
        {
            counter = 0;
            num = 0;
            sum = 1;
        }

    }

    void StatusMove()　//statusテキストを画面内に移動する
    {
        for (int i = 0; i < (int)controlPanel.ARREY_LENGTH; ++i)
        {
            statusPos[i].position += new Vector3(-move, 0, 0);
        }
    }


    void StatusReMove()　//statusテキストを画面外に移動する
    {
        for (int i = 0; i < (int)controlPanel.ARREY_LENGTH; ++i)
        {
            statusPos[i].position += new Vector3(move, 0, 0);
        }
    }


    void Button_TextBox_Move()　//ボタンとテキストボックスを画面内に移動する
    {
        //背景
        image.position += new Vector3(-move, 0, 0);

        //ボタン
        adovanceButton.position += new Vector3(-move, 0, 0);
        rotateButton.position += new Vector3(-move, 0, 0);
        Click.position += new Vector3(-move, 0, 0);

        //テキストボックス
        inputField.position += new Vector3(-move, 0, 0);
    }


    void Button_TextBox_ReMove()　//ボタンとテキストボックスを画面外に移動する
    {
        //背景
        image.position += new Vector3(move, 0, 0);

        //ボタン
        adovanceButton.position += new Vector3(move, 0, 0);
        rotateButton.position += new Vector3(move, 0, 0);
        Click.position += new Vector3(move, 0, 0);

        //テキストボックス
        inputField.position += new Vector3(move, 0, 0);
    }


    public void OnClick() //コントロール画面のボタンが押されたらイベント発生
    {
        audioSource.PlayOneShot(sound1);
        Debug.Log("押された!");
    
        num = 1;　//コントロール画面のボタンが押されたかの判定用
     
    }

}
