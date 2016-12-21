using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class FireGun : MonoBehaviour {
    //public members
    public GameObject gun;
    public Transform ShellParent;
    public GameObject shell;
    public GameObject shotEffect;
    public float forceOfShot;
    public float timeForReload;
    public float rotationSensitivity = 1f;
    public AudioClip shellFired;
    //private members
    private float reloadTime = 0f;
    private float rotationX = 0f;
    private AudioSource audio;
    // Use this for initialization
    void Start ()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefsManager.GetSFXVolume() < 0 || PlayerPrefsManager.GetSFXVolume() > 1 ? .5f : PlayerPrefsManager.GetSFXVolume() * 2.5f;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        reloadTime -= Time.deltaTime;
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && reloadTime <= 0)
        {
            Fire();
        }
        LockRotation();


    }
    void Fire()
    {
        audio.Play();
        reloadTime = timeForReload;
        GameObject shellFired = Instantiate(shell, gun.transform.position, transform.rotation) as GameObject;
        shellFired.transform.parent = ShellParent;
        GameObject particel = Instantiate(shotEffect, gun.transform.position - new Vector3(0.0f, 0.0f, .2f), Quaternion.identity) as GameObject;
        particel.transform.parent = gun.transform;
        particel.GetComponent<ParticleSystem>().Play();
        shellFired.GetComponent<Rigidbody>().AddForce(gun.transform.forward * forceOfShot);
        Destroy(particel, 2f);
        Destroy(shellFired, 3f);
        
    }
    void LockRotation()
    {
        rotationX += CrossPlatformInputManager.GetAxis("Mouse Y") * rotationSensitivity;
        rotationX = Mathf.Clamp(rotationX, 0f, 25f);
        transform.localEulerAngles = new Vector3(-rotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
