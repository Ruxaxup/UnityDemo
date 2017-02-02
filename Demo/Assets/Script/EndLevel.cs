using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {
    public GameObject endLevelPanel;
    public Text endLevelText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().material.color = new Color(0f,1f,0f);
        AnimatePlayerVictory();
        StartCoroutine(StartEndLevel());
    }

    private void AnimatePlayerVictory()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().EndLevelState();
    }

    private void LoadWorldMapScene()
    {
        
    }

    private void ShowEndLevelWindow()
    {
        GameObject.Find("TimeText").GetComponent<TimeText>().Stop();
        GameObject.Find("ButtonHandler").GetComponent<ButtonHandler>().Pause();
        endLevelText.text = "Felicidades!";
        endLevelPanel.SetActive(true);        
    }

    private IEnumerator StartEndLevel()
    {
        yield return new WaitForSeconds(1);
        ShowEndLevelWindow();
        LoadWorldMapScene();
    }
    
}
