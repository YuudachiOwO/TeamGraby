using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShot : MonoBehaviour
{

    public GameObject player;
    public Rigidbody2D playerRB;
    public GameObject cannon;
    public Transform cannonLock;
    public Vector3 cannonLockPoint;


    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        cannon = GameObject.FindGameObjectWithTag("OldCannon");
        cannonLock = cannon.gameObject.gameObject.transform;
    }

    void Update()
    {
        cannonLockPoint = cannonLock.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "OldCannon")
        {
            playerRB.isKinematic = true;
            playerRB.velocity = new Vector3(0, 0, 0);
            player.transform.position = cannonLockPoint;

            if(playerRB.isKinematic)
            {
                StartCoroutine("LaunchDelay");
            }


        }
    }

    /*private IEnumerator LaunchDelay(float waitTime)
    {
        yield return new;
    }*/
}
