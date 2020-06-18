using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Test_Player testPlayer;
    public float yMin = -1;
    public float yMax = 10000;


    void FixedUpdate()
    {
        if (!testPlayer.spring.enabled)
        {         
            transform.position = new Vector3(player.transform.position.x, Mathf.Clamp(player.position.y, yMin, yMax), player.transform.position.z);

        }

    }
}
