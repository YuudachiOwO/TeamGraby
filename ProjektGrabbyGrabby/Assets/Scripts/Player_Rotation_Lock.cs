﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Rotation_Lock : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D playerRB;
    public Vector3 playerVelocity;
    public Test_Player testPlayer;
    public bool grounded = false;
    public float timeOnGround;
    public AcidTrip acidTrip;
    public PlayerAnimation playerAnim;
    public float cosRotation;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        playerVelocity = playerRB.velocity;
    }

    void Update()
    {

        if (!playerAnim.playerAnim.GetBool("hasCollided"))
        {
            player.transform.rotation = new Quaternion(0, 0, 0, 1);

        }

        if (playerAnim.playerAnim.GetBool("hasCollided") && !grounded)
        {
            player.transform.rotation *= new Quaternion(0, 0, -1 * Time.deltaTime, 1);
        }

        if (grounded)
        {
            timeOnGround += Time.deltaTime;
            if (timeOnGround > 3f)
            {
                playerVelocity = new Vector2(0, playerRB.velocity.y);
                playerRB.velocity = playerVelocity;
            }
        }

        if (playerVelocity.x < 0 && !testPlayer.spring.enabled)
        {
            playerVelocity = new Vector2(0, playerRB.velocity.y);
            playerRB.velocity = playerVelocity;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        grounded = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        grounded = false;
        timeOnGround = 0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (acidTrip.allDestructive && other.gameObject.tag == "Smash")
        {
            other.gameObject.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (acidTrip.allDestructive && other.gameObject.tag == "Smash")
        {
            other.gameObject.SetActive(false);
        }
    }
}
