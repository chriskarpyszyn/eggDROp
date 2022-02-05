using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    public Transform coinEffect;
    private int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //todo-ck add coin counter 
            GameManager.currentScore += coinValue;
            Transform effect = Instantiate(coinEffect, transform.position, transform.rotation);
            Destroy(effect.gameObject, 3);
            Destroy(gameObject);
        }
    }
}
