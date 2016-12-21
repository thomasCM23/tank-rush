using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    public bool recording = true;
    public bool isPause = false;


    private float fixedDeltaTime;
	// Use this for initialization
    void Start()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(CrossPlatformInputManager.GetButtonDown("Cancel") && !isPause)
        {
            PauseGame();
        }
        else if(CrossPlatformInputManager.GetButtonDown("Cancel") && isPause)
        {
            ResumeGame();
        }

	
	}
    void PauseGame()
    {
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
        isPause = true;
    }
    void ResumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedDeltaTime;
        isPause = false;
    }
    void OnApplicationPause(bool pauseStatus)
    {
        isPause = pauseStatus;
       /* if(isPause)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }*/
    }

    public void LoadLevelNamed(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
