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
    public Animator wallBreakAnim;
    public BoxCollider2D coll;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        wallBreakAnim = WallBreakable.GetComponent<Animator>();

        wallBreakAnim.enabled = false;
    }

    void Update()
    {
        if (!WallBreakable.activeSelf)
        {
            wallBreakAnim.enabled = false;
        } 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerRB.velocity.x > breakSpeed)
        {
            this.coll.enabled = false;
            wallBreakAnim.enabled = true;
        }
        else
        {
            rbv = playerRB.velocity;
            rbv = new Vector3(0, rbv.y, rbv.z);
            playerRB.velocity = rbv;
        }

    }
}
