
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip sound1;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        anim.SetBool("GameOver", true);
    }
    public void Continue()
    {
        audioSource.PlayOneShot(sound1);
        SceneManager.LoadScene("MazeGame");
    }
}