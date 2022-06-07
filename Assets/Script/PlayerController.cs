//�\�[�X�R�[�h�̖��ߋK��
//�֐��A�^����(UCC�FUpper Camel Case)/�p�X�J���P�[�X (Pascal Case)(LCC�FLower Camel Case�j
//�ϐ���(LCC�FLower Camel Case�j

using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    
  
    private Animator anim;
    private Rigidbody rb;


    //speed�������l������ƃX���[�v�ɓ���Œ�12f

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {

            Debug.Log("�����ꂽ!");
            SceneManager.LoadScene("HomeScreen");�@//GameOver�̊ԈႢ�ł�
            Stop();


        }
        if (collision.gameObject.CompareTag("GameClear"))
        {
            Debug.Log("�����ꂽ!");
            SceneManager.LoadScene("GameOver");�@//HomeScreen�̊ԈႢ�ł�
            Stop();

        }
    }




    //===== �������� ====================================
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
      

    }


    //===== �又�� ===========================================
    void FixedUpdate()�@//FixedUpdate�֐��͈��b�����ƂɌĂ΂��B��{�I�ɂ�0.02�b�Ԋu        
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Home");
            Stop();

        }


        if (AdovanceButton.positiveNegative == 0)
        {
            for (int i = 0; i < 20; ++i)
            {
                if (AdovanceButton.number[i] != 0)
                {
                    Animation(i);
                }
            }

        }

        if (AdovanceButton.positiveNegative == 1)
        {
            for (int i = 0; i < 20; ++i)
            {
                if (AdovanceButton.number[i] != 0)
                {
                    Rotate(i);

                }
            }

        }


    }


    void Stop()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }


    void Animation(int number)
    {

        for (int i = 0; i < 20; ++i)
        {
            if (number == i)
            {
                anim.speed = 1;
                anim.SetBool("run", true);
                this.gameObject.transform.Translate(-0.005f, 0, 0);

                Invoke("Stop", AdovanceButton.number[i]);
            }

        }
    }

    void Rotate(int number)
    {

        for (int i = 0; i < 20; ++i)
        {
            if (number == i)
            {
                anim.speed = 1;
                anim.SetBool("run", true);
                transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime);

                Invoke("Stop", AdovanceButton.number[i]);

            }
        }
    }
} 
 




 
