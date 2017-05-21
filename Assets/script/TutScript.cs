using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class TutScript : MonoBehaviour {

	public float speed;
	private float amountToMove;

	public GameObject Video,Footprint;    // play the video & enable footprints after pulling the tank rope
	public GameObject WallCode;     // enable code on the wall after opening the box

	public MovieTexture movTexture; //電影材質
	private AudioSource movAudio; //影片音軌

	bool playedOnce;


	// check serial port (Arduino)
	//SerialPort spR = new SerialPort("COM4", 9600);
	//SerialPort spL = new SerialPort("COM5", 9600);
	SerialPort sp = new SerialPort("COM6", 9600);

	// Use this for initialization
	void Start () {
		//spR.Open ();
		//spR.ReadTimeout = 1;
		sp.Open ();
		sp.ReadTimeout = 1;

		// for video
		Video.GetComponent<Renderer>().material.mainTexture = movTexture;
		movTexture.loop = false;
		//movAudio = Video.GetComponent<AudioSource>();

		playedOnce = false;
		Video.SetActive (false);
		Footprint.SetActive (false);
		WallCode.SetActive (false);

	}

	// Update is called once per frame
	void Update () {
		amountToMove = speed * Time.deltaTime;

		if (sp.IsOpen) {
			try{
				MoveObject(sp.ReadByte());
				print(sp.ReadByte());
			}
			catch (System.Exception){

			}
		}
	}

	void MoveObject(int Direction){
		// 2 : mirror video + footprint
		if (Direction == 2) {
			print ("inininininin 2");
			/* Video */
			Video.SetActive (true);
			movTexture.Play();
			movAudio.Play();
			if (movTexture.isPlaying == false) {
				Video.SetActive (false);
			}

		}
		if (movTexture.isPlaying == false && playedOnce) {
			gameObject.SetActive (false);

			/* Footprint */
			Footprint.SetActive (true);
		}

		// 3 : wallcode
		if (Direction == 3) {
			print ("in ______3");
			//screamAudio.Play();
			//wall code
			WallCode.SetActive(true);
		}
	}

}

