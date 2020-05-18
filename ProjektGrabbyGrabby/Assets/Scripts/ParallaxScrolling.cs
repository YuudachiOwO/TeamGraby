﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public Transform[] backgrounds;
    public float parallaxAmount = 1f;
    public float[] parallaxScales;

    public Transform cam;
    public Vector3 previousCamPosition;

    void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {
        previousCamPosition = cam.position;
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * (-1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
     for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;
            Vector3 backgroundsTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundsTargetPos, parallaxAmount * Time.deltaTime);
        }
        previousCamPosition = cam.position;
    }
}