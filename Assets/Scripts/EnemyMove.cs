using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 5f || transform.position.x < -5f)
        {
            moveSpeed *= -1;
        }
        transform.position += transform.forward * moveSpeed;
    }
}
