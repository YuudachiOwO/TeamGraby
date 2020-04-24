using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public float distance;
    public Transform checkpoint;
    public Test_Player testPlayer;


    void Update()
    {
        if (!testPlayer.spring.enabled)
        {
            distance = (checkpoint.transform.position.x + transform.position.x);
            scoreText.text = "Score: " + Mathf.Abs(Mathf.Round(distance));
        }

    }

}
