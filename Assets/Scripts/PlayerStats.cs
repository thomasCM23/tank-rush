using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public Slider healthSlider, gasSlider;
    public float gasRegenRate;
    public GameObject tankExplosion;
    public bool isDead = false;

    private int maxHealth;
    private int currentHealth;
    private float maxGas;
    private float currentGas;
    private float timerToAddGas = 0f;
    

    // Use this for initialization
    void Start()
    {
        maxHealth = (int)healthSlider.maxValue;
        maxGas = gasSlider.maxValue;
        currentHealth = maxHealth;
        currentGas = maxGas;
    }

    // Update is called once per frame
    void Update()
    {
        //every 10 seconds add gas if needed
        if (timerToAddGas > 2f)
        {
            timerToAddGas = 0.0f;
            RegenGas();
        }
        timerToAddGas += Time.deltaTime;

        if (currentHealth <= 0 && !isDead)
        {
            Dead();
        }
    }
    public void UseGas(float rateOfUse)
    {
        currentGas -= rateOfUse;
        UpdateGasSlider();
    }
    public float GetGas()
    {
        return currentGas;
    }

    private void RegenGas()
    {
        if (currentGas < maxGas)
        {
            currentGas += gasRegenRate;
            UpdateGasSlider();
        }
    }
    public void TakeDamage()
    {
        currentHealth -= 1;
        UpdateHealthSlider();
    }
    public void UpdateHealthSlider()
    {
        healthSlider.value = (float)currentHealth;
    }
    public void UpdateGasSlider()
    {
        gasSlider.value = currentGas;
    }
    public void AddHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
        }
    }
    void Dead()
    {
        GameObject explosion = Instantiate(tankExplosion, transform.position, Quaternion.identity) as GameObject;
        explosion.GetComponent<ParticleSystem>().Play();
        isDead = true;
        Destroy(explosion, 1.5f);
        Invoke("Respawn", 1.5f);
    }
    void Respawn()
    {
        isDead = false;
        transform.position = new Vector3(0f, 0f, 0f);
        transform.rotation = Quaternion.identity;
        currentHealth = maxHealth;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Collider>().isTrigger = false;
        TriggerRender(true);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Collider>().isTrigger = true;
            TriggerRender(false);
            currentHealth = 0; //instadeath when the player hits an enemy;
            
        }
    }
    void TriggerRender(bool trigger)
    {
        foreach(Transform i in transform)
        {
            if(i.name == "TankRenderers")
            {
                i.gameObject.SetActive(trigger);
            }
        }
    }

}
