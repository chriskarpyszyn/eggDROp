using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static public int currentScore;
    public Transform musicPrefab;
    public float offsetY = 40;
    public float sizeX = 80;
    public float sizeY = 25;

    public void Start()
    {
        currentScore = 0;

        if (!GameObject.FindGameObjectWithTag("MusicManager"))
        {
            Transform musicManager = Instantiate(musicPrefab, transform.position, Quaternion.identity);
            musicManager.name = musicPrefab.name;
            DontDestroyOnLoad(musicManager);
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width/2-sizeX/2, offsetY, sizeX, sizeY), "Score: " + currentScore);
    }
}
