using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	// ���f�[�^�̍Đ����u���i�[����ϐ�
	 AudioSource audioSource;

	
	public AudioClip sound1;

	// Start is called before the first frame update
	void Start()
	{
		// �Q�[���X�^�[�g����AudioSource�i���Đ����u�j�̃R���|�[�l���g��������
		audioSource = GetComponent<AudioSource>();

	}


	
	

	
}
