using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonHandler : MonoBehaviour {
    public Button pauseButton;
    public GameObject pausePanel;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowPauseMenu()
    {
        Pause();
        pausePanel.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        UnPause();
        pausePanel.SetActive(false);
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    private void UnPause()
    {
        Time.timeScale = 1;
    }
}
