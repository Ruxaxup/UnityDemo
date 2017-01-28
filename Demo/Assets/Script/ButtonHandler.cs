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

    private void Pause()
    {
        Time.timeScale = 0;
    }

    private void UnPause()
    {
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        //GameObject.FindGameObjectWithTag("Background").GetComponent<Animator>().Play("Background");
        StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel()
    {        
        //float fadeTime = GameObject.Find("GameControl").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
    }
}
