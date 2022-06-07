//�\�[�X�R�[�h�̖��ߋK��
//�֐��A�^����(UCC�FUpper Camel Case)/�p�X�J���P�[�X (Pascal Case)(LCC�FLower Camel Case�j
//�ϐ���(LCC�FLower Camel Case�j
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameclear : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip sound1;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        anim.SetBool("GameClear", true);
    }

    public void Continue()
    {
        audioSource.PlayOneShot(sound1);
        SceneManager.LoadScene("SampleScene");
    }
}
