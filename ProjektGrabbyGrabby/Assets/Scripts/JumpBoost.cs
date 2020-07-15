using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpBoost : MonoBehaviour
{
    public GameObject jumpObject;
    public Button jumpButton;
    GameObject player;
    Rigidbody2D playerRB;
    public float jumpBoost;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
    }
    public void OnJumpPress()
    {
        if (!playerRB.isKinematic)
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, 0, 0) + new Vector3(0, jumpBoost, 0);
            jumpObject.SetActive(false);
            jumpButton.enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            jumpObject.SetActive(true);
            jumpButton.enabled = true;
        }
    }
}
