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
    public AudioSource asYeet;
    public AudioClip asYeetClip;

    private void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        rigid = GetComponent<Rigidbody2D>();
        asYeet = GetComponent<AudioSource>();
        releaseDelay = 1 / (spring.frequency * 4);
    }

    private void Start()
    {
        asYeetClip = asYeet.clip;
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
        whileTouch = true;
        rigid.isKinematic = true;
    }
    private void OnMouseUp()
    {
        whileTouch = false;
        rigid.isKinematic = false;
        StartCoroutine(Release());
        if (!asYeet.isPlaying)
        {
            asYeet.Play();
        }
    }

    //IEnumerator to deactivate the Spring//
    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        spring.enabled = false;
    }

}
