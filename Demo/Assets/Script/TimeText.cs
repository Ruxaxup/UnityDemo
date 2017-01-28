using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimeText : MonoBehaviour {
    private Text textDisplay;
    private float tiempo;
    private int minutos;
    private int segundos;
	// Use this for initialization
	void Start () {
        textDisplay = GetComponent<Text>();
        segundos = 0;
        minutos = 0;
        tiempo = 0;
	}
	
	// Update is called once per frame
	void Update () {
        CalculateTime();
        textDisplay.text = "Time: " + minutos.ToString("00") + ":" + segundos.ToString("00") ;
	}

    private void CalculateTime()
    {
        tiempo += Time.deltaTime;
        minutos = (int)Mathf.Floor(tiempo / 60);
        segundos = (int)Mathf.Floor(tiempo % 60);
    }

    public void ResetTime()
    {
        tiempo = 0;
    }
}
