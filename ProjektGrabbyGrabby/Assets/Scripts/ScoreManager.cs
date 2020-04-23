using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public float scoreCount;
    public Text highscoreText;
    public float highScoreCount;
    public float pointsPerSecond;
    public bool scoredeath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (scoredeath)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
        }

        scoreText.text = "Score: " + Mathf.Round (scoreCount);
        highscoreText.text = "Highscore: " + Mathf.Round (highScoreCount);
    }
}
