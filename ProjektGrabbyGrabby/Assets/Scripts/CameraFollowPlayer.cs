using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Test_Player testPlayer;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;


    void FixedUpdate()
    {
        if (!testPlayer.spring.enabled)
        {
            //Define Target to follow
            Vector3 targetPosition = player.position + offset;
            //Smooth Player follow
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }




    }
}
