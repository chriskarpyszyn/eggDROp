using UnityEngine;

public class BallControl : MonoBehaviour
{

    public Rigidbody rigidBody;
    public int rotationSpeed = 200;
    public int jumpHeight = 8;
    public AudioClip hit01, hit02, hit03;


    private float distToGround;
    private bool hasHitOnce = false;
    private AudioSource audioSource;

    private void Start()
    {
        Application.targetFrameRate = 144;

        //get the distance from the center to the ground
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + (float)0.1);
    }

    // Update is called once per frame
    void Update()
    {

        //handle ball rotation
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        rigidBody.AddRelativeTorque(Vector3.back * rotation);

        //handle jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidBody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        playBallCollisionAudio();
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Play Jump Sound");
    }

    private void playBallCollisionAudio()
    {
        audioSource = GetComponent<AudioSource>();
        int randomRange = Random.Range(0, 3);
        switch (randomRange)
        {
            case 0:
                audioSource.clip = hit01;
                break;
            case 1:
                audioSource.clip = hit02;
                break;
            case 2:
                audioSource.clip = hit03;
                break;
        }
        audioSource.pitch = Random.Range((float)0.9, (float)1.1);

        //a bit of a hack to stop this sound from playing on start.
        if (hasHitOnce)
        {
            audioSource.Play(0);
        }
        else
        {
            hasHitOnce = true;
        }
    }
}
