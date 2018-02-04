using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text TimerText;

    private float StartTime;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject); //Esta en todas las Scenes
    }

    // Use this for initialization
    void Start ()
    {
        StartTime = Time.time; //Inicio del Tiempo	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    float T = Time.time - StartTime;

        string minutes = ((int)T / 60).ToString();  
        string secons = (T % 60).ToString("f0");  //F0 = 0:0  / F2 = 0:0.0

        TimerText.text = 0 + minutes + ":" + secons;
	}
}
