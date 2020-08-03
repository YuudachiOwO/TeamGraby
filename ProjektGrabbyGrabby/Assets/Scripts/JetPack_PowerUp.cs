﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.UI;

public class JetPack_PowerUp : MonoBehaviour
{
    public GameObject player;
    public Jetpack_Boost boost;
    public float duration = 5f;
    public float timePassed;
    public float durationCount;
    public GameObject button;

    void Awake()
    {
        timePassed = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        boost = player.GetComponent<Jetpack_Boost>();
        boost.enabled = false;
        boost.jetpackBurning = true;
        if (PlayerPrefs.GetInt("JetpackBought") == 0)
        {
            button.SetActive(false);
        }
    }

    void Update()
    {
        Debug.Log(timePassed);
        durationCount = duration - timePassed;

        if (boost.enabled)
        {

            boost.playerRB.velocity = new Vector3(boost.playerRB.velocity.x, 0, 0);
            player.transform.rotation = new Quaternion(0, 0, 0, 1);
            boost.jetpackBurning = true;
        }
        else
        {
            boost.jetpackBurning = false;
        }

        if (timePassed >= duration)
        {
            boost.jetpackBurning = false;
            boost.enabled = false;
        }

        if (boost.jetpackBurning)
        {
            timePassed += Time.deltaTime;
            Mathf.RoundToInt(timePassed);
        }


    }

    public void ButtonActivate()
    {
        timePassed = 0;
        boost.enabled = true;
        button.SetActive(false);
        PlayerPrefs.SetInt("JetpackBought", 0);
    }

}
