﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBoost : MonoBehaviour
{
    GameObject player;
    Rigidbody2D playerRB;
    public float clickBoost;
    RaycastHit raycast;
    public Test_Player testplayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !testplayer.spring.enabled)
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, 0, 0) + new Vector3(0, clickBoost);
        }
    }
}
