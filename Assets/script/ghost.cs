using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ghost : MonoBehaviour {

    public Image myPanel;
    float fadeTime = 1f;
    Color colorToFadeTo;
 
    float ghosttime = 2f;
    int ghostappear;
	float ghostscale;
	int ghostpostion_x,ghostpostion_y;

    int time_i;
    float time_f;
    int count = 0;
    int i = 0;

    IEnumerator wait(float s)
	{       
		//FadeIn();
	
		myPanel.GetComponent<CanvasRenderer> ().SetAlpha (0.0f);
		myPanel.GetComponent<RectTransform>().localScale = new Vector2(ghostscale,ghostscale);
		myPanel.GetComponent<RectTransform>().localPosition = new Vector3(ghostpostion_x,ghostpostion_y,0);
		myPanel.GetComponent<Image>().color = new Color(0.6f,0.2f,0.2f,Random.Range (0.5f, 1f));
		//myPanel.transform.
     	   yield return new WaitForSeconds(s);
        myPanel.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
        FadeOut();
    }

    void Start()
    {
 
        myPanel.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
        colorToFadeTo = new Color(1f, 1f, 1f, 0f);
        Random.seed = System.Guid.NewGuid().GetHashCode();
		//Random.state = System.Guid.NewGuid().GetHashCode();
        ghostappear = Random.Range(15,50);
		ghostscale = Random.Range (1f, 3f);
		ghostpostion_x = Random.Range (-400, 400);
		ghostpostion_y = Random.Range (-500, 300);
    }
 
    // Update is called once per frame

    void Update()
    {

        myPanel.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
        if (i == 0)
        {
            myPanel.enabled = false;
            i++;
        }
        if (count == 0)
        {   
            StartCoroutine(wait(ghosttime));
            count++;   
        }
        if (count == 2)
        {  
            myPanel.enabled = true;
            StartCoroutine(wait(ghosttime));
            count++;
        }


        time_f += Time.deltaTime;
        time_i = (int)time_f;
       
        if (time_i >= ghostappear)
        {
            ghostappear = Random.Range(15, 30);
			ghostscale = Random.Range (1f, 3f);
			ghostpostion_x = Random.Range (-400, 400);
			ghostpostion_y = Random.Range (-500, 300);
            count = 2;
            time_f = 0;
        }

    }
    void FadeOut() 
    {
        colorToFadeTo = new Color(1f, 1f, 1f, 0f);
        myPanel.CrossFadeColor(colorToFadeTo, fadeTime, true, true);
    }
	/*
    void FadeIn()
    {
        colorToFadeTo.a = 1.0f;
        myPanel.CrossFadeColor(colorToFadeTo, fadeTime, true, true);

    }
   	*/


}
