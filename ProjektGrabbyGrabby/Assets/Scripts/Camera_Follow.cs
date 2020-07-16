using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera_Follow : MonoBehaviour
{
    public Transform playerPos;
    public Test_Player testPlayer;
    public float smoothSpeed = 0.125f;
    public Transform playerZ;
    public Vector3 pp;

    void FixedUpdate()
    {
        if (!testPlayer.spring.enabled)
        {
            transform.position = new Vector3(playerPos.position.x + 6.5f, playerPos.position.y, playerZ.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, pp = new Vector3 (playerPos.position.x, playerPos.position.y, -1f), smoothSpeed);
            transform.position = smoothedPosition;
        }
    }



}
