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

    public ObjectPooler trampolinePool1;
    public float randomTrampolineThreshold1;

    public ObjectPooler trampolinePool2;
    public float randomTrampolineThreshold2;

    public ObjectPooler trampolinePool3;
    public float randomTrampolineThreshold3;

    public ObjectPooler trampolinePool4;
    public float randomTrampolineThreshold4;

    public ObjectPooler breakWall;
    public float randomBreakWallThreshold;

    public ObjectPooler cannon;
    public float randomCannonThreshold;

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

            int diceObst = Random.Range(0, 100);
            int dicePU = Random.Range(0, 100);

            if (0 <= diceObst && diceObst < randomWallThreshold)
            {
                GameObject newWall = wallPool.GetPooledObject();
                Vector3 wallPosition = new Vector3(Random.Range(10f, 20f), 3.5f, 0f);
                newWall.transform.position = transform.position + wallPosition;
                newWall.transform.rotation = transform.rotation;
                newWall.SetActive(true);

            }

            if (randomWallThreshold <= diceObst && diceObst < randomWallThreshold + randomTrampolineThreshold1)
            {
                GameObject newTrampoline1 = trampolinePool1.GetPooledObject();
                Vector3 trampolinePosition1 = new Vector3(Random.Range(10f, 20f), 2f, 0f);
                newTrampoline1.transform.position = transform.position + trampolinePosition1;
                newTrampoline1.transform.rotation = transform.rotation;
                newTrampoline1.SetActive(true);
            }
            if (randomWallThreshold + randomTrampolineThreshold1 <= diceObst && diceObst < randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2)
            {
                GameObject newTrampoline2 = trampolinePool2.GetPooledObject();
                Vector3 trampolinePosition2 = new Vector3(Random.Range(10f, 20f), 2f, 0f);
                newTrampoline2.transform.position = transform.position + trampolinePosition2;
                newTrampoline2.transform.rotation = transform.rotation;
                newTrampoline2.SetActive(true);
            }
            if (randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 <= diceObst && diceObst < randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 + randomTrampolineThreshold3)
            {
                GameObject newTrampoline3 = trampolinePool3.GetPooledObject();
                Vector3 trampolinePosition3 = new Vector3(Random.Range(10f, 20f), 2f, 0f);
                newTrampoline3.transform.position = transform.position + trampolinePosition3;
                newTrampoline3.transform.rotation = transform.rotation;
                newTrampoline3.SetActive(true);
            }
            if (randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 + randomTrampolineThreshold3 <= diceObst && diceObst < randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 + randomTrampolineThreshold3 + randomTrampolineThreshold4)
            {
                GameObject newTrampoline4 = trampolinePool4.GetPooledObject();
                Vector3 trampolinePosition4 = new Vector3(Random.Range(10f, 20f), 2f, 0f);
                newTrampoline4.transform.position = transform.position + trampolinePosition4;
                newTrampoline4.transform.rotation = transform.rotation;
                newTrampoline4.SetActive(true);
            }

            if (randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 + randomTrampolineThreshold3 + randomTrampolineThreshold4 <= diceObst && diceObst < randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 + randomTrampolineThreshold3 + randomTrampolineThreshold4 + randomBreakWallThreshold)
            {
                GameObject newBreakWall = breakWall.GetPooledObject();
                Vector3 BreakWallPosition = new Vector3(Random.Range(10f, 20f), 2.3f, 0f);
                newBreakWall.transform.position = transform.position + BreakWallPosition;
                newBreakWall.transform.rotation = transform.rotation;
                newBreakWall.SetActive(true);
            }

            if (randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 + randomTrampolineThreshold3 + randomTrampolineThreshold4 + randomBreakWallThreshold <= diceObst && diceObst < randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 + randomTrampolineThreshold3 + randomTrampolineThreshold4 + randomBreakWallThreshold + randomCannonThreshold)
            {
                GameObject newCannon = cannon.GetPooledObject();
                Vector3 CannonPosition = new Vector3(Random.Range(10f, 20f), 3.21f, 0f);
                newCannon.transform.position = transform.position + CannonPosition;
                newCannon.transform.rotation = transform.rotation;
                newCannon.SetActive(true);
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