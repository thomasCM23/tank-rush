using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
    private AudioSource audio;
	// Use this for initialization
	void Start ()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefsManager.GetMasterVolume() > 1 || PlayerPrefsManager.GetMasterVolume() < 0 ? .5f : PlayerPrefsManager.GetMasterVolume();

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
