using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour {

	public GameObject Flush;
	private AudioSource flushAudio;

	public GameObject Video, Footprint;
	public MovieTexture movTexture; //電影材質
	private AudioSource movAudio; //影片音軌

	public GameObject Beep;
	private AudioSource beepAudio;

	public GameObject Scream;
	private AudioSource screamAudio;

	public GameObject WallCode, LastCode, pic114;

	bool playedOnce = false;

	// Use this for initialization
	void Start () {
		
		Video.GetComponent<Renderer>().material.mainTexture = movTexture;
		movTexture.loop = false;

		flushAudio = Flush.GetComponent<AudioSource>();
		movAudio = Video.GetComponent<AudioSource>();
		beepAudio = Beep.GetComponent<AudioSource>();
		screamAudio = Scream.GetComponent<AudioSource>();

		Video.SetActive (false);
		Footprint.SetActive (false);
		WallCode.SetActive (false);
		LastCode.SetActive (false);
		pic114.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		// Flush
		if (Input.GetKeyDown(KeyCode.F1))
		{
			flushAudio.Play ();
		}

		// Mirrow
		if (Input.GetKeyDown(KeyCode.F2))
		{
			Video.SetActive(true);
			movTexture.Play();
			movAudio.Play();
			playedOnce = true;
		}
		if (movTexture.isPlaying == false && playedOnce) {
			Video.SetActive (false);
			Footprint.SetActive (true);
		}

		// Beep (for footprint)
		if (Input.GetKeyDown(KeyCode.F3))
		{
			beepAudio.Play ();
		}

		// Scream (for openning box)
		if (Input.GetKeyDown(KeyCode.F4))
		{
			screamAudio.Play();
		}

		// Codes on the wall
		if (Input.GetKeyDown(KeyCode.F5))
		{
			WallCode.SetActive (true);
			LastCode.SetActive (true);
		}
		if (Input.GetKeyDown (KeyCode.F6)) 
		{
			pic114.SetActive (true);
		}

	}
}
