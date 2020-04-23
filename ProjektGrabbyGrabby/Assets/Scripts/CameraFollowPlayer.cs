using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Test_Player testPlayer;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    [SerializeField] float xMin = -1;
    [SerializeField] float xMax = 1;
    [SerializeField] float yMin = -1;
    [SerializeField] float yMax = 1;


    void FixedUpdate()
    {
        if (!testPlayer.spring.enabled)
        {
            //Define Target to follow
            Vector3 targetPosition = player.position + offset;
            float x = Mathf.Clamp(targetPosition.x, xMin, xMax);
            float y = Mathf.Clamp(targetPosition.y, yMin, yMax);
            //Smooth Player follow
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            transform.position = smoothedPosition;


        }

    }
}
