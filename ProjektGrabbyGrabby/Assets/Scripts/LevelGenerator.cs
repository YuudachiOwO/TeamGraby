using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    //Components
    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;

    public ObjectPooler theObjectPool;


    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

    }

    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            //Instantiate(platform, transform.position, transform.rotation);


            GameObject newPlatform = theObjectPool.GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }
    }
}
