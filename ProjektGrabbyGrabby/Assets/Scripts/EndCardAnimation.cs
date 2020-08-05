using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndCardAnimation : MonoBehaviour
{

    public GameObject endCard;
    public GameObject player;
    public GameObject restart;
    public GameObject returnMenu;
    public GameObject scores;
    public GameObject[] buttons;
    public Animator endCardAnimation;
    public Rigidbody2D playerRB;
    public ScoreManager scoreManager;
    public Test_Player testPlayer;
    public bool failSafe = true;

    void Start()
    {
        endCard = this.gameObject;
        endCardAnimation = endCard.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        testPlayer = player.GetComponent<Test_Player>();
        scoreManager = player.GetComponent<ScoreManager>();
        endCardAnimation.SetBool("highScoreBeaten", false);
        endCardAnimation.SetBool("roundFinished", false);
        restart.SetActive(false);
        returnMenu.SetActive(false);
        scores.SetActive(false);

    }

    void Update()
    {

        if (scoreManager.distance > PlayerPrefs.GetFloat("Highscore"))
        {
            endCardAnimation.SetBool("highScoreBeaten", true);
        }

        if (playerRB.velocity == new Vector2(0, 0) && !playerRB.isKinematic && failSafe && !testPlayer.spring.enabled)
        {
            failSafe = false;
            endCardAnimation.SetBool("roundFinished", true);
            foreach (GameObject button in buttons)
            {
                button.SetActive(false);
            }
        }

        if (endCardAnimation.GetBool("roundFinished") == true)
        {
            scores.SetActive(true);
            restart.SetActive(true);
            returnMenu.SetActive(true);
        }
    }


    public void ReturnToMenu()
    {
        endCardAnimation.SetBool("highScoreBeaten", false);
        endCardAnimation.SetBool("roundFinished", false);
        endCardAnimation.StopPlayback();
        scores.SetActive(false);
        restart.SetActive(false);
        returnMenu.SetActive(false);

        if (!endCardAnimation.GetBool("highScoreBeaten") && !endCardAnimation.GetBool("roundFinished"))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void Restart()
    {
        endCardAnimation.SetBool("highScoreBeaten", false);
        endCardAnimation.SetBool("roundFinished", false);
        endCardAnimation.StopPlayback();
        scores.SetActive(false);
        restart.SetActive(false);
        returnMenu.SetActive(false);

        if (!endCardAnimation.GetBool("highScoreBeaten") && !endCardAnimation.GetBool("roundFinished"))
        {
            SceneManager.LoadScene("Teste_scene_(Kevin)");
        }
    }
}
