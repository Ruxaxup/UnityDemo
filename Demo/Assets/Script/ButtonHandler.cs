using UnityEngine;
using UnityEngine.SceneManagement;
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

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        GameObject.FindGameObjectWithTag("Background").GetComponent<Animator>().Play("Background");
        StartCoroutine(LoadLevel());
    }

    public void LoadMainMenu()
    {
        Debug.Log("Launching Main Menu");
        StartCoroutine(LoadLevel(0));
    }

    private IEnumerator LoadLevel()
    {   
        float fadeTime = GameObject.Find("GameControl").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    private IEnumerator LoadLevel(int level)
    {
        UnPause();
        float fadeTime = GameObject.Find("GameControl").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
    
}
