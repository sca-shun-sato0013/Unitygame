//�\�[�X�R�[�h�̖��ߋK��
//�֐��A�^����(UCC�FUpper Camel Case)/�p�X�J���P�[�X (Pascal Case)(LCC�FLower Camel Case�j
//�ϐ���(LCC�FLower Camel Case�j

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip sound1;
    // Start is called before the first frame update
    public RectTransform 

        image, //�R���g���[����ʔw�i
            
    //�{�^����
    //=================
        Click,
        adovanceButton,
        rotateButton,
    //=================    

    //�e�L�X�g�{�b�N�X   
    //=================    
        inputField,
        placeholder,
        text,
    //=================


    //�R���g���[����ʕ\��[�z��ɂ��Ă��܂���]
    //=====================================================
        status,   status1,  status2 , status3 , status4,    
        status5,  status6,  status7 , status8 , status9,    
        status10, status11, status12, status13, status14,   
        status15, status16, status17, status18, status19;
    //=====================================================


    private int   counter = 0, num = 0, sum = 1;
    private float    move = 10.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }





    void Update()
    {
       
               text.position = inputField.position;
        placeholder.position = inputField.position;

        if (num > 0 && sum > 0)
        {
            
                  �@image.position += new Vector3(-move, 0, 0);


           adovanceButton.position += new Vector3(-move, 0, 0);
           �@rotateButton.position += new Vector3(-move, 0, 0);
                    Click.position += new Vector3(-move, 0, 0);


          �@�@ inputField.position += new Vector3(-move, 0, 0);
            �@�@�@�@


           �@ status.position += new Vector3(-move, 0, 0);
             status1.position += new Vector3(-move, 0, 0);
             status2.position += new Vector3(-move, 0, 0);
             status3.position += new Vector3(-move, 0, 0);
             status4.position += new Vector3(-move, 0, 0);
             status5.position += new Vector3(-move, 0, 0);
             status6.position += new Vector3(-move, 0, 0);
             status7.position += new Vector3(-move, 0, 0);
           �@status8.position += new Vector3(-move, 0, 0);
             status9.position += new Vector3(-move, 0, 0);
            status10.position += new Vector3(-move, 0, 0);
            status11.position += new Vector3(-move, 0, 0);
            status12.position += new Vector3(-move, 0, 0);
            status13.position += new Vector3(-move, 0, 0);
            status14.position += new Vector3(-move, 0, 0);
            status15.position += new Vector3(-move, 0, 0);
            status16.position += new Vector3(-move, 0, 0);
            status17.position += new Vector3(-move, 0, 0);
            status18.position += new Vector3(-move, 0, 0);
            status19.position += new Vector3(-move, 0, 0);
           

            counter++;
        }
        if (counter > 19)
        {
            counter = 0;
            �@�@num = 0;
            �@�@sum = -1;
        }
        if (num > 0 && sum < 0)
        {




               image.position += new Vector3(move, 0, 0);


      adovanceButton.position += new Vector3(move, 0, 0);
        rotateButton.position += new Vector3(move, 0, 0);


          inputField.position += new Vector3(move, 0, 0);
               Click.position += new Vector3(move, 0, 0);



              status.position += new Vector3(move, 0, 0);
             status1.position += new Vector3(move, 0, 0);
             status2.position += new Vector3(move, 0, 0);
             status3.position += new Vector3(move, 0, 0);
             status4.position += new Vector3(move, 0, 0);
             status5.position += new Vector3(move, 0, 0);
             status6.position += new Vector3(move, 0, 0);
             status7.position += new Vector3(move, 0, 0);
             status8.position += new Vector3(move, 0, 0);
             status9.position += new Vector3(move, 0, 0);
            status10.position += new Vector3(move, 0, 0);
            status11.position += new Vector3(move, 0, 0);
            status12.position += new Vector3(move, 0, 0);
            status13.position += new Vector3(move, 0, 0);
            status14.position += new Vector3(move, 0, 0);
            status15.position += new Vector3(move, 0, 0);
            status16.position += new Vector3(move, 0, 0);
            status17.position += new Vector3(move, 0, 0);
            status18.position += new Vector3(move, 0, 0);
            status19.position += new Vector3(move, 0, 0);
            
           

            counter++;
        }
        if (counter > 19)
        {
            counter = 0;
                num = 0;
                sum = 1;
        }
    }
    
    

    public void OnClick()
    {
        audioSource.PlayOneShot(sound1);
        Debug.Log("�����ꂽ!");

        
        
        num = 1;    
           
        
    }

}
