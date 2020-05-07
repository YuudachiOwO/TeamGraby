using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    //Components
    public GameObject[] platforms;
    public Transform generationPoint;
    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    private float platformWidth;
    private float[] platformWidths;
    private int platformSelector;
    public ObjectPooler[] theObjectPools;
    public float randomWallThreshold;
    public ObjectPooler wallPool;
    public Test_Player player;

    public ObjectPooler trampolinePool;
    public float randomTrampolineThreshold;

    void Start()
    {
        //platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths = new float[theObjectPools.Length];
        }

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
    }


    void Update()
    {
        if (transform.position.x < generationPoint.position.x/*&& !player.spring.enabled*/)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, theObjectPools.Length);
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);

            //Instantiate(platform thePlatforms[platformSelector], transform.position, transform.rotation);
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);



            if (Random.Range(0f, 100f) < randomWallThreshold)
            {
                GameObject newWall = wallPool.GetPooledObject();
                //float wallXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f + 1f);
                Vector3 wallPosition = new Vector3(0f, 3f, 0f);

                newWall.transform.position = transform.position + wallPosition;
                newWall.transform.rotation = transform.rotation;
                newWall.SetActive(true);
            }


            if (Random.Range(0f, 100f) < randomTrampolineThreshold)
            {
                GameObject newTrampoline = trampolinePool.GetPooledObject();
                //float wallXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f + 1f);
                Vector3 trampolinePosition = new Vector3(-3f, 1.3f, 0f);

                newTrampoline.transform.position = transform.position + trampolinePosition;
                newTrampoline.transform.rotation = transform.rotation;
                newTrampoline.SetActive(true);
            }


            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }
    }
}