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

    }

    void OnTriggerEnter2D(Collider2D other)
    {
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
