using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text highScoreText;
    public float distance;
    public float highScore;
    public Transform checkpoint;
    public Test_Player testPlayer;


    void Update()
    {
        highScoreText.text = "HighScore: " + Mathf.Abs(Mathf.Round(highScore));
        highScore = PlayerPrefs.GetFloat("Highscore");

        if (!testPlayer.spring.enabled)
        {
            distance = (checkpoint.transform.position.x + transform.position.x);
            scoreText.text = "Score: " + Mathf.Abs(Mathf.Round(distance));
        }

        if (distance > PlayerPrefs.GetFloat("Highscore") && testPlayer.rigid.velocity == new Vector2(0,0))
        {
            PlayerPrefs.SetFloat("Highscore", distance);
        }

    }

}
