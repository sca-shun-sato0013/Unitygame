//�\�[�X�R�[�h�̖��ߋK��
//�֐��A�^����(UCC�FUpper Camel Case)/�p�X�J���P�[�X (Pascal Case)(LCC�FLower Camel Case�j
//�ϐ���(LCC�FLower Camel Case�j

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeUp : MonoBehaviour
{
    
    private float countMeter = 300.0f; //��������

    private GameObject timeMeter, timeUpText;

    //���Ԃ�\������Text�^�̕ϐ�
    private�@Text�@time, timeText;

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
        if(countMeter >= 0 ){countMeter -= Time.deltaTime;}//���Ԃ��J�E���g�_�E������
        

        //���Ԃ�\������
        time.text = countMeter.ToString("f2") + "�b"; //f2 �����_����

        //countdown��0�ȉ��ɂȂ����Ƃ�
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






    

