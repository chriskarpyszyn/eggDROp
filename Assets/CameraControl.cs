using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public float distance = -30;
    public float height = 3f;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, height, distance);
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
