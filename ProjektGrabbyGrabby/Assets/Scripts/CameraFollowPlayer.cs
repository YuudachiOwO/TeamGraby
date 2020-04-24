using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Test_Player testPlayer;
    [SerializeField] float yMin = -1;
    [SerializeField] float yMax = 1;


    void FixedUpdate()
    {
        if (!testPlayer.spring.enabled)
        {
            //Define Target to follow
            transform.position = new Vector3(
            //Mathf.Clamp(player.position.x, xMin, xMax),
            player.transform.position.x,
            Mathf.Clamp(player.position.y, yMin, yMax),
            transform.position.z);
            //Smooth Player follow
            //Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            //transform.position = smoothedPosition;


        }

    }
}
