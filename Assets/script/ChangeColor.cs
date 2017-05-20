using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour {
	float startTime,timeCount;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		timeCount = Time.time - startTime;

		if(timeCount < 2.0f){
			GetComponent<SpriteRenderer>().color = new Color(0f, 37/256f, 122/256f, 0.7f);
		}
		else if(timeCount < 4.0f){
			GetComponent<SpriteRenderer>().color = new Color(54/256f, 221/256f, 90/256f, 0.7f);
		}
		else if(timeCount < 6.0f){
			GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.7f);
		}
		else if(timeCount < 8.0f){
			GetComponent<SpriteRenderer>().color = new Color(255/256f, 180/256f, 182/256f, 0.7f);
		}
		else if(timeCount >= 12.0f){
			startTime = Time.time;
		}
		else{
			GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
		}
	}
}
