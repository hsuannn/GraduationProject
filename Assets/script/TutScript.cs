using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class TutScript : MonoBehaviour {

	public float speed;
	private float amountToMove;

	// check serial port (Arduino)
	SerialPort sp = new SerialPort("/dev/cu.usbmodem1421", 115200);

	// Use this for initialization
	void Start () {
		sp.Open ();
		sp.ReadTimeout = 1;
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
		if (Direction == 1) {
			//water box hahaha
			//do something here...
		}

		if (Direction == 2) {
			//mirror hehehe
			//do something here...
		}
	}

}
