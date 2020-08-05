using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimation : MonoBehaviour
{

    public GameObject player;
    public Animator playerAnim;
    public Player_Rotation_Lock playerRotationLock;
    public Test_Player testPlayer;
    public float highSpeed;
    public int damageCounter;
    public int randomGeneration;
    public Sprite[] DamagePhaseOne;
    public Sprite[] DamagePhaseTwo;
    public Sprite[] DamagePhaseThree;
    public ClickBoost clickBoost;
    public EndCardAnimation endCardAnimation;
    public ContactPoint2D[] collisionPoint;
    public Vector3 impact;
    public AcidTrip acidTrip;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
        acidTrip = player.GetComponent<AcidTrip>();
    }

    void Start()
    {
        playerAnim.SetBool("isFlying", false);
        playerAnim.SetBool("wasLaunched", false);
        playerAnim.SetBool("hasCollided", false);
        playerAnim.SetBool("highSpeed", false);
        playerAnim.SetBool("onAcid", false);
    }

    void Update()
    {

        if (acidTrip.allDestructive)
        {
            playerAnim.SetBool("onAcid", true);
        }
        else
        {
            playerAnim.SetBool("onAcid", false);
        }

        if (playerAnim.GetBool("collisionSmash"))
        {
            player.transform.rotation = new Quaternion(0, 0, 0, 1);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

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


        if (damageCounter > 0 && damageCounter <= 5)
        {
            player.GetComponent<SpriteRenderer>().sprite = DamagePhaseOne[randomGeneration];
        }

        if (damageCounter > 5 && damageCounter <= 10)
        {
            player.GetComponent<SpriteRenderer>().sprite = DamagePhaseTwo[randomGeneration];
        }

        if (damageCounter > 10)
        {
            player.GetComponent<SpriteRenderer>().sprite = DamagePhaseThree[randomGeneration];
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        randomGeneration = Random.Range(0, 10);
        damageCounter++;
        playerAnim.SetBool("hasCollided", true);
        playerAnim.enabled = false;


        if (other.gameObject.tag == "Smash" && other.collider.GetType() == typeof(EdgeCollider2D))
        {

            playerAnim.SetBool("isFlying", false);
            playerAnim.SetBool("wasLaunched", false);
            playerAnim.SetBool("hasCollided", false);
            playerAnim.SetBool("highSpeed", false);
            playerAnim.enabled = true;
            playerAnim.SetBool("collisionSmash", true);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }


    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Smash" && other.collider.GetType() == typeof(EdgeCollider2D))
        {
            {
                playerAnim.SetBool("isFlying", false);
                playerAnim.SetBool("wasLaunched", false);
                playerAnim.SetBool("hasCollided", false);
                playerAnim.SetBool("highSpeed", false);
                playerAnim.enabled = true;
                playerAnim.SetBool("collisionSmash", true);
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Smash")
        {
            playerAnim.SetBool("isFlying", false);
            playerAnim.SetBool("wasLaunched", false);
            playerAnim.SetBool("hasCollided", false);
            playerAnim.SetBool("highSpeed", false);
        }

        if (other.gameObject.tag != "Coin")
        {
            damageCounter++;
        }
    }

    private void OnMouseDown()
    {
        if (!testPlayer.spring.enabled && clickBoost.clickMax > 0)
        {
            randomGeneration = Random.Range(0, 10);
            damageCounter++;
            playerAnim.SetBool("hasCollided", true);
            playerAnim.enabled = false;
        }
    }
}
