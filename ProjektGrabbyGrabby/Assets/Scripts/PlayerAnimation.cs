using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public GameObject player;
    public Animator playerAnim;
    public Player_Rotation_Lock playerRotationLock;
    public Test_Player testPlayer;
    public float highSpeed;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
    }

    void Start()
    {
        playerAnim.SetBool("isFlying", false);
        playerAnim.SetBool("wasLaunched", false);
        playerAnim.SetBool("hasCollided", false);
        playerAnim.SetBool("highSpeed", false);
    }

    void Update()
    {
        if (!testPlayer.spring.enabled)
        {
            playerAnim.SetBool("wasLaunched", true);
            playerAnim.SetBool("isFlying", true);
        }

        if (player.GetComponent<Rigidbody2D>().velocity.x > highSpeed)
        {
            playerAnim.SetBool("highSpeed", true);

        }
        else
        {
            playerAnim.SetBool("highSpeed", false);
        }

        if (playerRotationLock.grounded)
        {
            playerAnim.SetBool("isFlying", false);
        }
        else
        {
            playerAnim.SetBool("isFlying", true);
        }
    }
}
