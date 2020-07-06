using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class CannonShot : MonoBehaviour
{

    public GameObject player;
    public Rigidbody2D playerRB;
    public GameObject cannon;
    public Transform cannonLock;
    public Vector3 cannonLockPoint;
    public float waitTime;
    public float timeMax;
    public float xLaunch;
    public float yLaunch;
    public float xOffset;
    public float yOffset;
    public Animator cannonAnim;
    public Test_Player testPlayer;


    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        cannon = GameObject.FindGameObjectWithTag("OldCannon");
        cannonLock = cannon.gameObject.gameObject.transform;
        cannonAnim.enabled = true;
    }

    void Update()
    {
        cannonLockPoint = cannonLock.position;
        if (!playerRB.isKinematic)
        {
            cannonAnim.SetBool("isFiring", false);
            waitTime = 0;
        }
        if (playerRB.isKinematic && !testPlayer.spring.enabled)
        {
            waitTime += Time.deltaTime;
            cannonAnim.SetBool("isFiring", true);

            if (playerRB.isKinematic && waitTime >= timeMax)
            {
                playerRB.velocity = new Vector3(xLaunch, yLaunch);
                playerRB.isKinematic = false;
            }

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "OldCannon")
        {
            playerRB.isKinematic = true;
            playerRB.velocity = new Vector3(0, 0, 0);
            player.transform.position = cannonLockPoint + new Vector3(xOffset, yOffset);

        }
    }
}
