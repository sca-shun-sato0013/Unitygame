using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	// 音データの再生装置を格納する変数
	 AudioSource audioSource;

	
	public AudioClip sound1;

	// Start is called before the first frame update
	void Start()
	{
		// ゲームスタート時にAudioSource（音再生装置）のコンポーネントを加える
		audioSource = GetComponent<AudioSource>();

	}


	
	

	
}
