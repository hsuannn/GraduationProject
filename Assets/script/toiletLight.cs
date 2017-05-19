using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toiletLight: MonoBehaviour
{
    public Light lt;
	public Material material;

    float lighttime;
    float lightshine;
    float time_f;
    int count = 0;
	Color c = new Color(0.6f, 0.6f, 0.5f);

    // Use this for initialization
    void Start()
    {
         lightshine = Random.Range(1.0f, 10.0f);
    }

    // Update is called once per frame

    IEnumerator wait(float s)
    {
        lt.intensity = 0.3f;
		material.SetColor ("_EmissionColor", c);
        yield return new WaitForSeconds(s);
        lt.intensity = 0;
		material.SetColor ("_EmissionColor", Color.black);
    }  
 
    void Update()
    {
        lt.intensity = 0.3f;
        lighttime = Random.Range(0f, 3.0f);
        if (count == 0)
        {
            StartCoroutine(wait(lighttime));
            count++;
        }  
        lt.intensity = 0.3f;
		material.SetColor ("_EmissionColor", c);
        time_f += Time.deltaTime; 

        if (time_f >= lightshine)
        {
            count = 0;
            time_f = 0;
        }
        
    }

}
