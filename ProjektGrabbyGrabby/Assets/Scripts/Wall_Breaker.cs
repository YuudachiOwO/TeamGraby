using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Breaker : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D playerRB;
    public GameObject WallBreakable;
    public Vector3 rbv;
    public float breakSpeed;
    public AcidTrip acidTrip;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (playerRB.velocity.x > breakSpeed)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            rbv = playerRB.velocity;
            rbv = new Vector3(0, rbv.y, rbv.z);
            playerRB.velocity = rbv;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerRB.velocity.x > breakSpeed)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            rbv = playerRB.velocity;
            rbv = new Vector3(0, rbv.y, rbv.z);
            playerRB.velocity = rbv;
        }

    }
}
