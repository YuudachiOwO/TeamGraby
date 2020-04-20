using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera_Follow : MonoBehaviour
{
    public Transform playerPos;
    public Test_Player testPlayer;

    void FixedUpdate()
    {
        if (!testPlayer.spring.enabled)
        {
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
        }
    }
}
