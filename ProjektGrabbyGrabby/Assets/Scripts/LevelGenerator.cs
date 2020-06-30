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

    public ObjectPooler breakWall;
    public float randomBreakWallThreshold;

    public ObjectPooler jetpack;
    public float randomJetpackThreshold;

    public ObjectPooler acid;
    public float randomAcidThreshold;

    void Start()
    {
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
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, theObjectPools.Length);
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < randomWallThreshold)
            {
                GameObject newWall = wallPool.GetPooledObject();
                Vector3 wallPosition = new Vector3(0f, 3f, 0f);
                newWall.transform.position = transform.position + wallPosition;
                newWall.transform.rotation = transform.rotation;
                newWall.SetActive(true);
            }

            if (Random.Range(0f, 100f) < randomTrampolineThreshold)
            {
                GameObject newTrampoline = trampolinePool.GetPooledObject();
                Vector3 trampolinePosition = new Vector3(-3f, 1.3f, 0f);

                newTrampoline.transform.position = transform.position + trampolinePosition;
                newTrampoline.transform.rotation = transform.rotation;
                newTrampoline.SetActive(true);
            }

            if (Random.Range(0f, 100f) < randomBreakWallThreshold)
            {
                GameObject newBreakWall = breakWall.GetPooledObject();
                Vector3 BreakWallPosition = new Vector3(-6f, 2.5f, 0f);
                newBreakWall.transform.position = transform.position + BreakWallPosition;
                newBreakWall.transform.rotation = transform.rotation;
                newBreakWall.SetActive(true);
            }

            if (Random.Range(0f, 100f) < randomJetpackThreshold)
            {
                GameObject newJetpack = jetpack.GetPooledObject();
                Vector3 JetpackPosition = new Vector3(-8f, Random.Range(1f, 6f), 0f);
                newJetpack.transform.position = transform.position + JetpackPosition;
                newJetpack.transform.rotation = transform.rotation;
                newJetpack.SetActive(true);
            }

            if (Random.Range(0f, 100f) < randomAcidThreshold)
            {
                GameObject newAcid = acid.GetPooledObject();
                Vector3 AcidPosition = new Vector3(-10f, Random.Range(1f, 6f), 0f);
                newAcid.transform.position = transform.position + AcidPosition;
                newAcid.transform.rotation = transform.rotation;
                newAcid.SetActive(true);
            }


            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }
    }
}