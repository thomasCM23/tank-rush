using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{

    //public members
    public float minSpeed, maxSpeed;
    public ParticleSystem dust;
    public AudioClip[] sounds;
    //private members
    private Rigidbody rb;
    private AudioSource aus;

    //private functions
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aus = GetComponent<AudioSource>();
        aus.volume = PlayerPrefsManager.GetSFXVolume() < 0 || PlayerPrefsManager.GetSFXVolume() > 1 ? .5f : PlayerPrefsManager.GetSFXVolume() * .5f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool isDead = GetComponent<PlayerStats>().isDead;
        if (!isDead)
        {
            Move();
        }
    }
    void Move()
    {
        
        bool isGoingFast = CrossPlatformInputManager.GetButton("Fire3") && GetComponent<PlayerStats>().GetGas() > 0;
        float move = CrossPlatformInputManager.GetAxis("Horizontal") * (!isGoingFast ? minSpeed : maxSpeed);
        PlayEngineSounds(move);
        if (isGoingFast && Mathf.Abs(move) > 1f)
        {
            GetComponent<PlayerStats>().UseGas(1f);
        }
        Vector3 direction = Vector3.zero;
        direction = new Vector3(0.0f, 0f, move);
        dust.Play();
        rb.MovePosition(transform.position + direction * Time.deltaTime);
    }
    void PlayEngineSounds(float speed)
    {
        if (Mathf.Abs(speed) > 1f && aus.clip != sounds[1])
        {
            aus.clip = sounds[1];
            aus.Play();
        }
        else if (Mathf.Abs(speed) < 1f && aus.clip != sounds[0])
        {
            aus.clip = sounds[0];
            aus.Play();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {

        }
    }

    //public functions
}
