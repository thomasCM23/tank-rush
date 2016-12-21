using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelFinished : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //would load next level but since there is none load start screen
            SceneManager.LoadScene("Start");
        }
    }
}
