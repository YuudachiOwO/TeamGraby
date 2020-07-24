using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_PlayerHit : MonoBehaviour
{
    public GameObject player;
    public AudioSource playerHitAudio;
    public AudioClip[] playerHitClips;
    public PlayerAnimation playerAnim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHitAudio = player.GetComponent<AudioSource>();
    }

    void Update()
    {

        playerHitAudio.clip = playerHitClips[Random.Range(1, 7)];

    }


    void OnCollsionEnter2D(Collision2D coll)
    {
        if (!playerHitAudio.isPlaying && playerAnim.playerAnim.GetBool("hasCollided") == true)
        {
            playerHitAudio.Play();
        }

    }
}
