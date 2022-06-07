//�\�[�X�R�[�h�̖��ߋK��
//�֐��A�^����(UCC�FUpper Camel Case)/�p�X�J���P�[�X (Pascal Case)(LCC�FLower Camel Case�j
//�ϐ���(LCC�FLower Camel Case�j

using UnityEngine;
using UnityEngine.UI;



public class AdovanceButton : MonoBehaviour
{
     private  enum controlPanel�@//�R���g���[����ʂɎg���Ă���z��̗v�f��
     {
      STR_ARREY = 20,
      NUMBER_ARREY = 20,
      STATUS_ARREY = 20,
      ARREY_LENGTH = 20, //for���ł̔z��̗v�f��
      STATUS_TEXT_ARREY = 20
      
     };

    //�Ȗ��F������ ���ʉ� �V�X�e��37
    AudioSource audioSource;�@
    public AudioClip sound1;
   
    
    //�e�L�X�g�{�b�N�X
    public InputField inputField;
    public Text text;

�@ //�e�z��̐錾�Ə�����
   private GameObject[] status = new GameObject[(int)controlPanel.STATUS_ARREY];
   private Text[] statusText = new Text[(int)controlPanel.STATUS_TEXT_ARREY];
   private string[] str = new string[(int)controlPanel.STR_ARREY];
   public static int[] number = new int[(int)controlPanel.NUMBER_ARREY];


    

    //�{�^��
    private Button executionButton; //���s�{�^��
    private Button adovanceButton;�@//�O�i�{�^��
    private Button rotateButton;�@  //��]�{�^��
    
    //�{�^���I�u�W�F�N�g
    private GameObject executionBt;
    private GameObject adovanceBt;
    private GameObject rotateBt;


    public int execution = 0;�@//�e�L�X�g�̏o�̓J�E���^

    public static int  positiveNegative = 0; //���ړ����E�ړ�����p





    //============��������==============================
    void Start()
    {
        
        StartSetting();
        
    }

    void StartSetting() //Start�֐��̓��e
    {
        StatusStartSetting();
        ButtonStartSetting();
        TextBoxStartSetting();
    }


    void StatusStartSetting()�@//start�֐���status�̓��e
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

    void ButtonStartSetting() //start�֐��̃{�^���̓��e
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


    void TextBoxStartSetting()�@//start�֐���textbox�̓��e
    {
        inputField = inputField.GetComponent<InputField>();
        audioSource = GetComponent<AudioSource>();
        text = text.GetComponent<Text>();
    }


    public void InputText() //�e�L�X�g���͎��C�x���g����
    {
        for(int i = 0; i < (int)controlPanel.ARREY_LENGTH; ++i)
        {
            if(execution == i)
            {
                text.text = inputField.text;
                statusText[i].text += text.text + "�b";
                number[i] = int.Parse(text.text);
            }
        }
        
        
        
    }

    public void AdovanceClick()�@//�O�i�{�^�����͎��C�x���g����
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
                statusText[i].text = "�O�i :";
            }
        }

    }

    public void RotateClick() //��]�{�^�����͎��C�x���g����
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
                statusText[i].text = "��] :";
            }
        }

    }


    public void ExecutionClick()�@//���s�{�^�����͎��C�x���g����
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
    

    void ButtonLift()�@//���s�{�^����������Ă���v���C���[�̈ړ����I�������C�x���g����
    {
        adovanceButton.interactable = true;
        rotateButton.interactable = true;

        for(int i = 0; i < (int)controlPanel.ARREY_LENGTH; ++i)
        {
            number[i] = 0;�@//number�ϐ���PlayerController�Ŏg�p����Ă���B
        }                  //���̑��ł̎g�p���ӁI       
    }

}