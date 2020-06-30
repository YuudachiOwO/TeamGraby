using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack_Boost : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public bool jetpackBurning;
    public float boosterStrengthUp = 1f;
    public float boosterStrengthSide = 1f;

    
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        jetpackBurning = false;
    }
    void Update()
    {

        if (jetpackBurning)
        {
            playerRB.AddForce(new Vector2(boosterStrengthSide, boosterStrengthUp), ForceMode2D.Force);
        }

        else 
        {
            playerRB.AddForce(new Vector2(0f, 0f), ForceMode2D.Force);
        }
    }
}
