using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickBoost : MonoBehaviour
{
    GameObject player;
    Rigidbody2D playerRB;
    public float clickBoostX;
    public float clickBoostY;
    public Test_Player testplayer;
    public float clickMax;
    public PlayerAnimation playerAnim;
    public GameObject tapObject;
    public Button tapButton;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        tapButton.GetComponentInChildren<Text>().text = "Small Boost: " + clickMax + " remaining";

        if (clickMax == 0)
        {
            tapObject.SetActive(false);
        }
        else
        {
            tapObject.SetActive(true);
        }
    }

    public void JumpFuntion()
    {
        if (!testplayer.spring.enabled && clickMax > 0)
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, 0, 0) + new Vector3(clickBoostX, clickBoostY);
            clickMax--;
        }
    }
}
