using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallHealth : MonoBehaviour
{

    public int maxFallDistance = -10;
   
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= maxFallDistance)
        {
            //todo-ck add checkpoints
            SceneManager.LoadScene("Level01");
            resetOnDeath();
            
        }
    }

    private void resetOnDeath()
    {
        GameManager.currentScore = 0;
    }
}
