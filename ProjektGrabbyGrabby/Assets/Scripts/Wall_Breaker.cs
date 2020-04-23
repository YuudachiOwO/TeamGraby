using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Breaker : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D playerRB;
    public GameObject WallBreakable;
    public Vector3 rbv;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D coll)
    {
       // if(coll.gameObject.tag == "Player")
        {
            if (playerRB.velocity.x > 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                rbv = playerRB.velocity;
                rbv = new Vector3(0, rbv.y, rbv.z);
                playerRB.velocity = rbv;
            }
        }
    }
}
