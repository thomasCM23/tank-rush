using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

    public GameObject explosion;
    public AudioClip explosionSound;
    public int maxHealth;
    private int currentHealth;
    private bool isDead = false;


    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0 && !isDead)
        {
            Dead();
        }
    }
    
    public void TakeDamage()
    {
        currentHealth -= 1;
    }
    void Dead()
    {
        GivePlayerHealth();
        isDead = true;
        GameObject explo = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        explo.GetComponent<ParticleSystem>().Play();
        explo.AddComponent<AudioSource>();
        explo.GetComponent<AudioSource>().clip = explosionSound;
        explo.GetComponent<AudioSource>().Play();
        Destroy(gameObject);
        Destroy(explo, 2f);
        
    }
    void GivePlayerHealth()
    {
        int ranNum = Random.Range(0, 5);
        if(ranNum >= 1)
        {
            GameObject.FindObjectOfType<PlayerStats>().AddHealth();
        }
    }
}
