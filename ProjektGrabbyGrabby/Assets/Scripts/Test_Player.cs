using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Player : MonoBehaviour
{
    private SpringJoint2D spring;
    private Rigidbody2D rigid;
    private float releaseDelay;
    bool whileTouch = false;
    public Vector2 tPosition;
    public Touch touch;

    private void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        rigid = GetComponent<Rigidbody2D>();

        releaseDelay = 1 / (spring.frequency * 4);
    }
    public void Update()
    {
        //TOUCHSCREEN FUNCTION / TRANSFORM PLAYER IF TOUCH SCREEN//
        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition;
        } */

        touch = Input.GetTouch(0);
        Debug.Log(touch.position);

        if (whileTouch)
        {
            DragBall();
        }
    }
    private void DragBall()
    {
        Vector2 tPosition = Camera.main.ScreenToWorldPoint(touch.position);
        rigid.position = tPosition;
    }
    //CUT SPRING / IF BUTTONS IS NOT TOUCHED ANYMORE SPRING RELEASE//
    private void OnMouseDown()
    {
        whileTouch = true;
        Debug.Log("istouched");
        rigid.isKinematic = true;
    }

    private void OnMouseUp()
    {
        whileTouch = false;
        Debug.Log("isnottouched");
        rigid.isKinematic = false;
        StartCoroutine(Release());
    }

    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        spring.enabled = false;
    }

}
