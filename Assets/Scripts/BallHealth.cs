using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BallHealth : MonoBehaviour
{

    public int maxFallDistance = -10;
    private bool isRestarting = false;

    private AudioSource audioSource;
    private AudioClip audioClip;
   
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
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
        audioSource.Play();
        yield return new WaitForSeconds(audioClip.length+(float)0.5);
        SceneManager.LoadScene("Level01");
    }
}
