using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip sound1;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClick()
    {   audioSource.PlayOneShot(sound1);
        SceneManager.LoadScene("MazeGame");
        
    }

    public void GameClick()
    {   audioSource.PlayOneShot(sound1);
        SceneManager.LoadScene("ActionGame");
        
    }
    public void Home1()
    {   audioSource.PlayOneShot(sound1);
        SceneManager.LoadScene("GameSelection");
        
    }
}
