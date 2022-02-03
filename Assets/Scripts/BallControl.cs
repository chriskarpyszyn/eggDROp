using UnityEngine;

public class BallControl : MonoBehaviour
{

    public Rigidbody rigidBody;
    public int rotationSpeed = 200;
    public int jumpHeight = 8;

    private bool isFalling = false;

    private void Start()
    {
        Application.targetFrameRate = 144;
    }

    // Update is called once per frame
    void Update()
    {

        //handle ball rotation
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        rigidBody.AddRelativeTorque(Vector3.back * rotation);

        //handle jump
        if (Input.GetKeyDown(KeyCode.Space) && !isFalling)
        {
            rigidBody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isFalling = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        isFalling = true;
    }
}
