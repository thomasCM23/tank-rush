using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string SFX_VOLUME_KEY = "sfx_volume";
    const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Not good volume value");
        }

    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
    public static void SetSFXVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Difficulty out of range");
        }
    }
    public static float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat(SFX_VOLUME_KEY);
    }
    public static void UnlockLevel(int level)
    {
        if(level <= Application.levelCount -1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //use 1 for true;
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order");
        }

    }
    public static bool IsLevelUnlocked(int level)
    {
        if (level <= Application.levelCount - 1)
        {
            return PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1;
        }
        else{
            Debug.LogError("Trying to unlock level not in build order");
            return false;

        }
    }

}
