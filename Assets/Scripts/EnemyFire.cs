using UnityEngine;
using System.Collections;

public class EnemyFire : MonoBehaviour
{
    public float minTimeToFire;
    public float maxTimeToFire;
    public GameObject Bullet;
    public Transform ShellParent;
    public Transform Gun;
    public GameObject ShellEffect;
    public Vector3 ShotDirection;
    public float forceOfShot = 700f;
    private float timerToFire = 0f;
    private float rangedNumber;
    private AudioSource audio;


    void Start()
    {
        rangedNumber = Random.Range(minTimeToFire, maxTimeToFire);
        audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefsManager.GetSFXVolume() < 0 || PlayerPrefsManager.GetSFXVolume() > 1 ? .5f : PlayerPrefsManager.GetSFXVolume() * 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerToFire>= rangedNumber)
        {
            Fire();
            timerToFire = 0f;
        }
        timerToFire += Time.deltaTime;
    }
    void Fire()
    {
        audio.Play();
        GameObject shell = Instantiate(Bullet, Gun.position, Quaternion.Euler(ShotDirection)) as GameObject;
        shell.GetComponent<Rigidbody>().AddForce(Gun.transform.forward * forceOfShot);
        shell.transform.parent = ShellParent;
        GameObject particel = Instantiate(ShellEffect, Gun.position, Quaternion.Euler(ShotDirection)) as GameObject;
        particel.transform.parent = Gun.transform;
        particel.GetComponent<ParticleSystem>().Play();
        Destroy(particel, 2f);
        Destroy(shell, 2f);

    }
}
