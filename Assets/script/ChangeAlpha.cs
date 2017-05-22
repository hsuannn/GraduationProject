using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAlpha : MonoBehaviour {
	
	Color startColor = new Color (152/256f, 114/256f, 114/256f, 0.01f);
	Color endColor = new Color (152/256f, 114/256f, 114/256f, 0.25f);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer> ().color = Color.Lerp(startColor, endColor, Mathf.PingPong (Time.time, 3));
	}
}
