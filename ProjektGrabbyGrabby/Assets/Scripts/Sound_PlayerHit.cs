using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_PlayerHit : MonoBehaviour
{
    public GameObject player;
    public AudioSource playerHitAudio;
    public AudioClip[] playerHitClips;
    public int randomSoundHit;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHitAudio = player.GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        randomSoundHit = Random.Range(0, playerHitClips.Length);
        playerHitAudio.PlayOneShot(playerHitClips[randomSoundHit]);
    }
}

