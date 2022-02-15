using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public static Vector3 ReachedPoint = new Vector3(0, (float)1.027473, 0);
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && transform.position.x > ReachedPoint.x)
        {
            ReachedPoint = transform.position;
        }
    }
}
