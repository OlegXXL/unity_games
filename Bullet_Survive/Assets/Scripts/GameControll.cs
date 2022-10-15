using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField] enum gameStatus
{
    statusPause,
    statusBoss,
    statusGame
}

public class GameControll : MonoBehaviour
{
    [SerializeField] private Text timeText;
    private gameStatus currentStatus = gameStatus.statusGame;
    private float gameTime = 10;


    private void Update()
    {
        if (currentStatus == gameStatus.statusGame)
        {
            gameTime += Time.deltaTime;
            float minutes = Mathf.FloorToInt(gameTime / 60);
            float seconds = Mathf.FloorToInt(gameTime % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
