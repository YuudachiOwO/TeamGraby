using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBackwards : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D playerRB;
    public Test_Player testPlayer;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        testPlayer = player.GetComponent<Test_Player>();
    }

    void Update()
    {
        if (playerRB.velocity.x < 0 && !testPlayer.spring.enabled)
        {
            playerRB.velocity = new Vector3(0, playerRB.velocity.y, 0);
        }
    }





}

