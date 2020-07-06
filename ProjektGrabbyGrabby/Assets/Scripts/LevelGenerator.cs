using JetBrains.Annotations;
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
    public Test_Player player;
    public ObjectPooler[] theObjectPools;

    public ObjectPooler wallPool;
    public float randomWallThreshold;
    public float wallRadius;

    public ObjectPooler trampolinePool;
    public float randomTrampolineThreshold;
    public float trampolineRadius;

    public ObjectPooler breakWall;
    public float randomBreakWallThreshold;
    public float breakWallRadius;

    public ObjectPooler jetpack;
    public float randomJetpackThreshold;
    public float jetpackRadius;

    public ObjectPooler acid;
    public float randomAcidThreshold;
    public float acidRadius;

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

            int diceObst = Random.Range(0,100);
            int dicePU = Random.Range(0, 100);

            if (0 <= diceObst && diceObst < randomWallThreshold)
            {
                GameObject newWall = wallPool.GetPooledObject();
                Vector3 wallPosition = new Vector3(Random.Range(2f, 4f), 3.5f, 0f);
                newWall.transform.position = transform.position + wallPosition;
                newWall.transform.rotation = transform.rotation;
                newWall.SetActive(true);

            }

            if (randomWallThreshold <= diceObst && diceObst < randomWallThreshold + randomTrampolineThreshold)
            {
                GameObject newTrampoline = trampolinePool.GetPooledObject();
                Vector3 trampolinePosition = new Vector3(Random.Range(2f, 4f), 1.2f, 0f);
                newTrampoline.transform.position = transform.position + trampolinePosition;
                newTrampoline.transform.rotation = transform.rotation;
                newTrampoline.SetActive(true);            
            }

            if (randomWallThreshold + randomTrampolineThreshold <= diceObst && diceObst < randomWallThreshold + randomTrampolineThreshold + randomBreakWallThreshold)
            {
                GameObject newBreakWall = breakWall.GetPooledObject();
                Vector3 BreakWallPosition = new Vector3(Random.Range(2f, 4f), 2.3f, 0f);
                newBreakWall.transform.position = transform.position + BreakWallPosition;
                newBreakWall.transform.rotation = transform.rotation;
                newBreakWall.SetActive(true);
            }

            if (0 <= dicePU && dicePU < randomJetpackThreshold)
            {
                GameObject newJetpack = jetpack.GetPooledObject();
                Vector3 JetpackPosition = new Vector3(Random.Range(4f, 10f), Random.Range(1f, 30f), 0f);
                newJetpack.transform.position = transform.position + JetpackPosition;
                newJetpack.transform.rotation = transform.rotation;
                newJetpack.SetActive(true);
            }


            if (randomJetpackThreshold <= dicePU && dicePU < randomJetpackThreshold + randomAcidThreshold)
            {
                GameObject newAcid = acid.GetPooledObject();
                Vector3 AcidPosition = new Vector3(Random.Range(4f, 10f), Random.Range(1f, 30f), 0f);
                newAcid.transform.position = transform.position + AcidPosition;
                newAcid.transform.rotation = transform.rotation;
                newAcid.SetActive(true);
            }


            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }
    }
}