using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline_Bounce : MonoBehaviour
{

    public Vector3 playerVelocity;
    public Rigidbody2D playerRB;
    public GameObject player;
    public float trampoline;
    public EdgeCollider2D edgy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        edgy = GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        playerVelocity = playerRB.velocity;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (playerVelocity.y < 0)
        {
            /*playerVelocity = new Vector3(playerVelocity.x ,playerVelocity.y * (-1f), playerVelocity.z);
            playerRB.velocity = playerVelocity;*/
            playerVelocity = new Vector3(playerVelocity.x, 0, playerVelocity.z);
            playerRB.velocity = playerVelocity;

            playerRB.AddForce(new Vector2(0f, trampoline));
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (playerVelocity.y <= 0)
        {
            /*playerVelocity = new Vector3(playerVelocity.x ,playerVelocity.y * (-1f), playerVelocity.z);
            playerRB.velocity = playerVelocity;*/
            playerRB.AddForce(new Vector2(0f, trampoline));
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        edgy.isTrigger = true;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        edgy.isTrigger = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        edgy.isTrigger = false;
    }
}
