using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //todo-ck add coin counter 
            Destroy(gameObject);
        }
    }
}
