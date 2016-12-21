using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class OptionsController : MonoBehaviour {
    public Slider mainMusic;
    public Slider SFXMusic;
    public MusicManager mm;
    private float currentMain;
    private float currentSFX;

	// Use this for initialization
	void Start ()
    {
        if (PlayerPrefsManager.GetMasterVolume() > 1 || PlayerPrefsManager.GetMasterVolume() < 0)
        {
            currentMain = mainMusic.value;
            currentSFX = SFXMusic.value;
            PlayerPrefsManager.SetMasterVolume(currentMain);
            PlayerPrefsManager.SetSFXVolume(currentSFX);
        }
        else
        {
            mainMusic.value = PlayerPrefsManager.GetMasterVolume();
            currentMain = mainMusic.value;
            SFXMusic.value = PlayerPrefsManager.GetSFXVolume();
            currentSFX = PlayerPrefsManager.GetSFXVolume();
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        SetSFX();
        SetMain();
	
	}
    void SetSFX()
    {
        if(currentSFX != SFXMusic.value)
        {
            currentSFX = SFXMusic.value;
            PlayerPrefsManager.SetSFXVolume(currentSFX);
        }
    }
    void SetMain()
    {
        if (currentMain != mainMusic.value)
        {
            currentMain = mainMusic.value;
            PlayerPrefsManager.SetMasterVolume(currentMain);
            mm.GetComponent<AudioSource>().volume = currentMain;
        }
    }
}
