using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Player : MonoBehaviour
{
    private SpringJoint2D spring;
    private float releaseDelay;
    bool whileTouch = false;

    private void Awake()
    {
        spring = GetComponent<SpringJoint2D>();

        releaseDelay = 1 / (spring.frequency * 4);
    }
    void Update()
    {
        //TOUCHSCREEN FUNCTION / TRANSFORM PLAYER IF TOUCH SCREEN//
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition;
        }

        //CUT SPRING / IF BUTTONS IS NOT TOUCHED ANYMORE SPRING RELEASE//
        if (whileTouch)
        {
            StartCoroutine(Release());
        }
    }

    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        spring.enabled = false;
    }

}
