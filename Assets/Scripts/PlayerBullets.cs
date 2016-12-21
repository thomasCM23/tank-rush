using UnityEngine;
using System.Collections;

public class PlayerBullets : MonoBehaviour {

    public GameObject ShellExplosion;
    public AudioClip explosionSound;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy" || collision.transform.tag == "EnemyBullet")
        {
            if (collision.transform.tag == "Enemy")
            {
                collision.transform.GetComponent<EnemyStats>().TakeDamage();
            }
            else
            {
                Destroy(collision.gameObject);
            }

            GameObject tempSoundObject = new GameObject();
            tempSoundObject.AddComponent<AudioSource>();
            tempSoundObject.AddComponent<AudioSource>().playOnAwake = false;
            tempSoundObject.GetComponent<AudioSource>().clip = explosionSound;
            tempSoundObject.transform.position = transform.position;
            tempSoundObject.GetComponent<AudioSource>().Play();
            GameObject part = Instantiate(ShellExplosion, transform.position, transform.rotation) as GameObject;
            part.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            Destroy(tempSoundObject, explosionSound.length);
            Destroy(part, 2f);

        }

    }
}
