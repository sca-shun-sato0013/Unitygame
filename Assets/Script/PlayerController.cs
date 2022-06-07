//ソースコードの命令規則
//関数、型名は(UCC：Upper Camel Case)/パスカルケース (Pascal Case)(LCC：Lower Camel Case）
//変数は(LCC：Lower Camel Case）

using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    
  
    private Animator anim;
    private Rigidbody rb;


    //speed小さい値を入れるとスリープに入る最低12f

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {

            Debug.Log("押された!");
            SceneManager.LoadScene("HomeScreen");　//GameOverの間違いです
            Stop();


        }
        if (collision.gameObject.CompareTag("GameClear"))
        {
            Debug.Log("押された!");
            SceneManager.LoadScene("GameOver");　//HomeScreenの間違いです
            Stop();

        }
    }




    //===== 初期処理 ====================================
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
      

    }


    //===== 主処理 ===========================================
    void FixedUpdate()　//FixedUpdate関数は一定秒数ごとに呼ばれる。基本的には0.02秒間隔        
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
 




 
