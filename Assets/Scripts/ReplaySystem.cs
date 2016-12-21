using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour
{

    private const int bufferFrames = 100;
    private MyKeyFrame[] keyframes = new MyKeyFrame[bufferFrames];
    private Rigidbody rb;
    private GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.recording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }

    }
    void Record()
    {
        rb.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        keyframes[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
    void PlayBack()
    {
        rb.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        transform.position = keyframes[frame].pos;
        transform.rotation = keyframes[frame].rot;
    }
}
public struct MyKeyFrame
{
    public float time;
    public Vector3 pos;
    public Quaternion rot;

    public MyKeyFrame(float time, Vector3 pos, Quaternion rot)
    {
        this.time = time;
        this.pos = pos;
        this.rot = rot;
    }


}
