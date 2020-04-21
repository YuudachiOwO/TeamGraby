using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline_Bounce : MonoBehaviour
{

    public Vector3 playerVelocity;
    public Rigidbody2D playerRB;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerVelocity = playerRB.velocity;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (playerVelocity.y < 0)
        {
            playerVelocity = new Vector3(playerVelocity.x,playerVelocity.y * (-1f), playerVelocity.z);
            playerRB.velocity = playerVelocity;
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (playerVelocity.y <= 0)
        {
            playerVelocity = new Vector3(playerVelocity.x, playerVelocity.y * (-1f), playerVelocity.z);
            playerRB.velocity = playerVelocity;
        }
    }
}
