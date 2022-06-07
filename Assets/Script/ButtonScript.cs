//�\�[�X�R�[�h�̖��ߋK��
//�֐��A�^����(UCC�FUpper Camel Case)/�p�X�J���P�[�X (Pascal Case)(LCC�FLower Camel Case�j
//�ϐ���(LCC�FLower Camel Case�j

using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private enum controlPanel //�R���g���[����ʂɎg���Ă���z��̗v�f��
    {
        STR_ARREY = 20,    
        STATUS_ARREY = 20,
        ARREY_LENGTH = 20, //for���ł̔z��̗v�f��
        STATUS_POS_ARREY = 20

    };

    //�Ȗ��F������ ���ʉ� �V�X�e��37
    AudioSource audioSource;
    public AudioClip sound1;
    
    //�R���g���[����ʔw�i
    public RectTransform image;

    //�{�^����
    public RectTransform Click; //���s�{�^��
    public RectTransform adovanceButton; //�O�i�{�^��
    public RectTransform rotateButton; //��]�{�^��

    //�e�L�X�g�{�b�N�X
    public RectTransform inputField;
    public RectTransform placeholder;
    public RectTransform text;

    //�e�z��̐錾�Ə�����
    private GameObject[] status = new GameObject[(int)controlPanel.STATUS_ARREY];
    private RectTransform[] statusPos = new RectTransform[(int)controlPanel.STATUS_POS_ARREY];
    private string[] str = new string[(int)controlPanel.STR_ARREY];

    //��ʂ̈ړ�����
    private int counter = 0;�@//�{�^���̃N���b�N����p
    private int num = 0; //��ʊO����ʓ����̔���p
    private int sum = 1; //��ʊO����ʓ����̔���p


    private float    move = 10.0f; //��ʂ̈ړ���



    //============��������==============================
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StatusStartSetting();
        
    }
  

    void StatusStartSetting() //Start�֐��̓��eStatus����
    {
        for (int i = 0; i < (int)controlPanel.ARREY_LENGTH; ++i)
        {
            str[i] = i.ToString(); 
            str[i] = "Status" + str[i];

            status[i] = GameObject.Find("Canvas/" + str[i]);
            statusPos[i] = status[i].GetComponent<RectTransform>();
        }
    }


    //=================�又�� =========================
    void Update()
    {
        UpdateSetting();
    }

    
    void UpdateSetting() //Update�֐��̓��e
    {
        text.position = inputField.position;
        placeholder.position = inputField.position;

        if (num > 0 && sum > 0)�@//�����A��ʏ�ɃR���g���[����ʂ��\������Ă��Ȃ���Έړ�����
        {
            Button_TextBox_Move(); 
            StatusMove(); 

            counter++;
        }

        if (counter > (int)controlPanel.ARREY_LENGTH - 1) //�z��̗v�f��-1�@
        {
            counter = 0;
            num = 0;
            sum = -1;
        }

        if (num > 0 && sum < 0) //�����A��ʏ�ɃR���g���[����ʂ��\������Ă���΋t�ړ�����
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

    void StatusMove()�@//status�e�L�X�g����ʓ��Ɉړ�����
    {
        for (int i = 0; i < (int)controlPanel.ARREY_LENGTH; ++i)
        {
            statusPos[i].position += new Vector3(-move, 0, 0);
        }
    }


    void StatusReMove()�@//status�e�L�X�g����ʊO�Ɉړ�����
    {
        for (int i = 0; i < (int)controlPanel.ARREY_LENGTH; ++i)
        {
            statusPos[i].position += new Vector3(move, 0, 0);
        }
    }


    void Button_TextBox_Move()�@//�{�^���ƃe�L�X�g�{�b�N�X����ʓ��Ɉړ�����
    {
        //�w�i
        image.position += new Vector3(-move, 0, 0);

        //�{�^��
        adovanceButton.position += new Vector3(-move, 0, 0);
        rotateButton.position += new Vector3(-move, 0, 0);
        Click.position += new Vector3(-move, 0, 0);

        //�e�L�X�g�{�b�N�X
        inputField.position += new Vector3(-move, 0, 0);
    }


    void Button_TextBox_ReMove()�@//�{�^���ƃe�L�X�g�{�b�N�X����ʊO�Ɉړ�����
    {
        //�w�i
        image.position += new Vector3(move, 0, 0);

        //�{�^��
        adovanceButton.position += new Vector3(move, 0, 0);
        rotateButton.position += new Vector3(move, 0, 0);
        Click.position += new Vector3(move, 0, 0);

        //�e�L�X�g�{�b�N�X
        inputField.position += new Vector3(move, 0, 0);
    }


    public void OnClick() //�R���g���[����ʂ̃{�^���������ꂽ��C�x���g����
    {
        audioSource.PlayOneShot(sound1);
        Debug.Log("�����ꂽ!");
    
        num = 1;�@//�R���g���[����ʂ̃{�^���������ꂽ���̔���p
     
    }

}
