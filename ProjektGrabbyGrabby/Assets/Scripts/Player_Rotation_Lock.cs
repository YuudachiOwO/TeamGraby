using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Rotation_Lock : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D playerRB;
    public Vector3 playerVelocity;
    public Test_Player testPlayer;
    public bool grounded = false;
    public float timeOnGround;
    public AcidTrip acidTrip;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        playerVelocity = playerRB.velocity;
    }

    void Update()
    {
        player.transform.rotation = new Quaternion(0, 0, 0, 1);

        if (grounded)
        {
            timeOnGround += Time.deltaTime;
            if (timeOnGround > 3f)
            {
                playerVelocity = new Vector2(0, playerRB.velocity.y);
                playerRB.velocity = playerVelocity;
            }
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
        if (acidTrip.allDestructive)
        {
            other.gameObject.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (acidTrip.allDestructive)
        {
            other.gameObject.SetActive(false);
        }
    }
}
