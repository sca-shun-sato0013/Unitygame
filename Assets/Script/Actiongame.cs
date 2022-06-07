
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SoftGear.Strix.Unity.Runtime;







public class Actiongame : StrixBehaviour
{
    AudioSource audioSource;
    public AudioClip sound1;
    private Animator anim;
    private int i = 0;
    private GameObject mainCamera;
    private Rigidbody rb; // Rididbody
    private GameObject text;
    private Text pointText;
    private string str;


    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        anim = GetComponent<Animator>();
        // Rigidbody ‚ðŽæ“¾
        rb = GetComponent<Rigidbody>();
        text = GameObject.Find("Canvas/Text");
        pointText = text.GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();

    }


    void Update()
    {
        if (isLocal == false)
        {
            return;
        }




        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Home");
        }



        anim.SetBool("run", false);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -70, 0) * Time.deltaTime);

            anim.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 70, 0) * Time.deltaTime);

            anim.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(-20, 0, 0) * Time.deltaTime);
            anim.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(20, 0, 0) * Time.deltaTime);
            anim.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(0, 10, 0) * Time.deltaTime);
            anim.SetBool("run", true);

        }

        if (Input.GetKey(KeyCode.T))
        {
            mainCamera.transform.Rotate(new Vector3(50, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Y))
        {
            mainCamera.transform.Rotate(new Vector3(-50, 0, 0) * Time.deltaTime);
        }

    }

    void OnCollisionStay(Collision colition)
    {
        if (colition.gameObject.tag == "Move")
        {
            transform.parent = colition.gameObject.transform;
            Debug.Log("parenting");
        }
    }

    void OnCollisionExit()
    {
        transform.parent = null;
        Debug.Log("exit");
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            ++i;
            audioSource.PlayOneShot(sound1);
            collision.gameObject.SetActive(false);
            str = i.ToString();
            pointText.text = "POINT:" + str;

        }
        if (collision.gameObject.CompareTag("Hell"))
        {
            SceneManager.LoadScene("HomeScreen 2");
        }
        if (collision.gameObject.CompareTag("GameClear") && i == 50)
        {
            SceneManager.LoadScene("GameOver 1");
        }

    }

    
 
}
    
