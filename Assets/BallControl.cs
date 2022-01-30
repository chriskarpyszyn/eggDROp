using UnityEngine;

public class BallControl : MonoBehaviour
{

    public Rigidbody rigidBody;
    public int rotationSpeed = 100;

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        rigidBody.AddRelativeTorque(Vector3.back * rotation);
    }
}
