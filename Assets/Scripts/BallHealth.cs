using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BallHealth : MonoBehaviour
{

    public int maxFallDistance = -10;
    private bool isRestarting = false;

    public AudioClip gameOverSound;

    private AudioSource audioSource;
   
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= maxFallDistance && !isRestarting)
        {
            //todo-ck add checkpoints
            StartCoroutine(RestartLevel());
            
        }
    }

    private IEnumerator RestartLevel()
    {
        isRestarting = true;
        yield return playGameOverSound();
        //SceneManager.LoadScene("Level01");
        transform.position = CheckPoint.ReachedPoint;
        isRestarting = false;
        GameManager.currentScore = 0;
    }

    private IEnumerator playGameOverSound()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameOverSound;
        audioSource.pitch = (float)0.85;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length + (float)0.5);
    }
}
