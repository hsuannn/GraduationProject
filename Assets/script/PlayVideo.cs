using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour {

	public GameObject Video,Footprint,Code;
	public MovieTexture movTexture; //電影材質
	private AudioSource movAudio; //影片音軌

	bool playedOnce = false;

	// Use this for initialization
	void Start () {
		Video.GetComponent<Renderer>().material.mainTexture = movTexture;
		movTexture.loop = false;
		movAudio = Video.GetComponent<AudioSource>();
		Video.SetActive (false);
		Footprint.SetActive (false);
		Code.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F1))
		{
			//GetComponent<AudioSource>().Play();
			Video.SetActive(true);
			movTexture.Play();
			movAudio.Play();
			playedOnce = true;
		}
		if (Input.GetKeyDown(KeyCode.F2))
		{
			//GetComponent<AudioSource>().Pause();
			movTexture.Pause();
			movAudio.Pause();
		}
		if (Input.GetKeyDown(KeyCode.F3))
		{
			//GetComponent<AudioSource>().Stop();
			movTexture.Stop();
			movAudio.Stop();
		}
		if (Input.GetKeyDown(KeyCode.F4))
		{
			Code.SetActive (true);
		}
		if (movTexture.isPlaying == false && playedOnce) {
			Video.SetActive (false);
			Footprint.SetActive (true);
		}
	}
}
