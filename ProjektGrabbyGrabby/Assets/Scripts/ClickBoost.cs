using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickBoost : MonoBehaviour
{
    GameObject player;
    Rigidbody2D playerRB;
    public float clickBoost;
    RaycastHit raycast;
    public Test_Player testplayer;
    public float clickMax;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        if (!testplayer.spring.enabled && clickMax > 0)
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, 0, 0) + new Vector3(0, clickBoost);
            clickMax--;
        }
    }
}
