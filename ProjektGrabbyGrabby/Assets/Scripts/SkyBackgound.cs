using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBackgound : MonoBehaviour
{
    public Transform camera;
    public Transform background;



    void Update()
    {
        background.position = new Vector3(camera.position.x, background.position.y, background.position.z);
    }
}
