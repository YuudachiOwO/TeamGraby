using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_Player : MonoBehaviour
{
    public SpringJoint2D spring;
    public Rigidbody2D rigid;
    private float releaseDelay;
    public bool whileTouch = false;
    public Vector2 tPosition;
    public Touch touch;
    public bool timeStart = false;
    public float timeAfter;
    public Jetpack_Boost boost;
    public JetPack_PowerUp jetpackPowerUp;
    public GameObject jetpackButton;
    public Button button;

    private void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        rigid = GetComponent<Rigidbody2D>();
        releaseDelay = 1 / (spring.frequency * 4);
    }

    //TOUCHSCREEN FUNCTION / TRANSFORM PLAYER IF TOUCH SCREEN//
    public void Update()
    {
        touch = Input.GetTouch(0);

        if (whileTouch)
        {
            DragBall();
        }
    }

    //Ball Position//
    private void DragBall()
    {
        Vector2 tPosition = Camera.main.ScreenToWorldPoint(touch.position);
        rigid.position = tPosition;
    }

    //Check if ball is touched//
    private void OnMouseDown()
    {
        if (spring.enabled)
        {
            whileTouch = true;
            rigid.isKinematic = true;
        }

    }
    private void OnMouseUp()
    {
        timeStart = true;
        whileTouch = false;
        rigid.isKinematic = false;
        StartCoroutine(Release());
    }

    public void FixedUpdate()
    {

        if (timeStart)
        {
            timeAfter += Time.deltaTime;
        }
    }

    //IEnumerator to deactivate the Spring//
    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        spring.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "JetpackPU")
        {
            button.enabled = true;
            jetpackButton.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
}
