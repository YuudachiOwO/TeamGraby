using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    public Transform player;
    public Test_Player testPlayer;
    public float yMin = -.5f;
    public float yMax = 1000;

    Transform t;

    void Awake()
    {
        t = transform;
    }


    void LateUpdate()
    {
        if(!testPlayer.spring.enabled)
        {
        float x = player.position.x + 6.5f;
        float y = Mathf.Clamp(player.position.y, yMin, yMax);
        t.position = new Vector3(x ,y ,t.position.z);
        }
    }
}
