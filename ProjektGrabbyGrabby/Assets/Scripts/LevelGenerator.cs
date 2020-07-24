using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public ObjectPooler jump;
    public float randomJumpThreshold;

    public ObjectPooler bird;
    public float randomBirdThreshold;

    public ObjectPooler coin1;
    public float randomCoinThreshold1;

    public ObjectPooler coin2;
    public float randomCoinThreshold2;

    public ObjectPooler coin3;
    public float randomCoinThreshold3;

    public ObjectPooler platform1;
    public float randomPlatformThreshold1;

    public ObjectPooler platform2;
    public float randomPlatformThreshold2;

    public ObjectPooler platform3;
    public float randomPlatformThreshold3;

    public Collider2D[] colliders;
    public Collider2D[] colliderOverlap;
    public Vector3 colliderPoints;
    public float colliderRadius;
    public GameObject[] spawnedObjects;
    public Transform[] spawnedFind;





    void Start()
    {
        spawnedObjects = GameObject.FindObjectsOfType<GameObject>();

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
        foreach (Collider2D collider in colliders)
        {
            colliderPoints = collider.GetComponentInParent<Transform>().position;
        }

        colliderOverlap = Physics2D.OverlapCircleAll(colliderPoints, colliderRadius);

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
            int diceBird = Random.Range(0, 100);
            int diceCollect1 = Random.Range(0, 100);
            int diceCollect2 = Random.Range(0, 100);
            int diceCollect3 = Random.Range(0, 100);
            int diceAirPlatform1 = Random.Range(0, 100);
            int diceAirPlatform2 = Random.Range(0, 100);
            int diceAirPlatform3 = Random.Range(0, 100);

            if (0 <= diceObst && diceObst < randomWallThreshold)
            {
                GameObject newWall = wallPool.GetPooledObject();
                Vector3 wallPosition = new Vector3(Random.Range(10f, 60f), 3.5f, 0f);
                newWall.transform.position = transform.position + wallPosition;
                newWall.transform.rotation = transform.rotation;
                newWall.SetActive(true);

            }

            if (randomWallThreshold <= diceObst && diceObst < randomWallThreshold + randomTrampolineThreshold1)
            {
                GameObject newTrampoline1 = trampolinePool1.GetPooledObject();
                Vector3 trampolinePosition1 = new Vector3(Random.Range(10f, 60f), 2f, 0f);
                newTrampoline1.transform.position = transform.position + trampolinePosition1;
                newTrampoline1.transform.rotation = transform.rotation;
                newTrampoline1.SetActive(true);
            }
            if (randomWallThreshold + randomTrampolineThreshold1 <= diceObst && diceObst < randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2)
            {
                GameObject newTrampoline2 = trampolinePool2.GetPooledObject();
                Vector3 trampolinePosition2 = new Vector3(Random.Range(10f, 60f), 2f, 0f);
                newTrampoline2.transform.position = transform.position + trampolinePosition2;
                newTrampoline2.transform.rotation = transform.rotation;
                newTrampoline2.SetActive(true);
            }
            if (randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 <= diceObst && diceObst < randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 + randomTrampolineThreshold3)
            {
                GameObject newTrampoline3 = trampolinePool3.GetPooledObject();
                Vector3 trampolinePosition3 = new Vector3(Random.Range(10f, 60f), 2f, 0f);
                newTrampoline3.transform.position = transform.position + trampolinePosition3;
                newTrampoline3.transform.rotation = transform.rotation;
                newTrampoline3.SetActive(true);
            }
            if (randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 + randomTrampolineThreshold3 <= diceObst && diceObst < randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 + randomTrampolineThreshold3 + randomTrampolineThreshold4)
            {
                GameObject newTrampoline4 = trampolinePool4.GetPooledObject();
                Vector3 trampolinePosition4 = new Vector3(Random.Range(10f, 60f), 2f, 0f);
                newTrampoline4.transform.position = transform.position + trampolinePosition4;
                newTrampoline4.transform.rotation = transform.rotation;
                newTrampoline4.SetActive(true);
            }

            if (randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 + randomTrampolineThreshold3 + randomTrampolineThreshold4 <= diceObst && diceObst < randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 + randomTrampolineThreshold3 + randomTrampolineThreshold4 + randomBreakWallThreshold)
            {
                GameObject newBreakWall = breakWall.GetPooledObject();
                Vector3 BreakWallPosition = new Vector3(Random.Range(10f, 60f), 2.3f, 0f);
                newBreakWall.transform.position = transform.position + BreakWallPosition;
                newBreakWall.transform.rotation = transform.rotation;
                newBreakWall.SetActive(true);
            }

            if (randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 + randomTrampolineThreshold3 + randomTrampolineThreshold4 + randomBreakWallThreshold <= diceObst && diceObst < randomWallThreshold + randomTrampolineThreshold1 + randomTrampolineThreshold2 + randomTrampolineThreshold3 + randomTrampolineThreshold4 + randomBreakWallThreshold + randomCannonThreshold)
            {
                GameObject newCannon = cannon.GetPooledObject();
                Vector3 CannonPosition = new Vector3(Random.Range(10f, 60f), 3.21f, 0f);
                newCannon.transform.position = transform.position + CannonPosition;
                newCannon.transform.rotation = transform.rotation;
                newCannon.SetActive(true);
            }


            if (0 <= dicePU && dicePU < randomJetpackThreshold && colliderOverlap.Length == 0)
            {
                GameObject newJetpack = jetpack.GetPooledObject();
                Vector3 JetpackPosition = new Vector3(Random.Range(10f, 60f), Random.Range(5f, 30f), 0f);
                newJetpack.transform.position = transform.position + JetpackPosition;
                newJetpack.transform.rotation = transform.rotation;
                newJetpack.SetActive(true);
            }


            if (randomJetpackThreshold <= dicePU && dicePU < randomJetpackThreshold + randomAcidThreshold && colliderOverlap.Length == 0)
            {
                GameObject newAcid = acid.GetPooledObject();
                Vector3 AcidPosition = new Vector3(Random.Range(10f, 60f), Random.Range(5f, 30f), 0f);
                newAcid.transform.position = transform.position + AcidPosition;
                newAcid.transform.rotation = transform.rotation;
                newAcid.SetActive(true);
            }

            if (randomJetpackThreshold + randomAcidThreshold <= dicePU && dicePU < randomJetpackThreshold + randomAcidThreshold + randomJumpThreshold && colliderOverlap.Length == 0)
            {
                GameObject newJump = jump.GetPooledObject();
                Vector3 JumpPosition = new Vector3(Random.Range(10f, 60f), Random.Range(5f, 30f), 0f);
                newJump.transform.position = transform.position + JumpPosition;
                newJump.transform.rotation = transform.rotation;
                newJump.SetActive(true);
            }

            if (0 <= diceBird && diceBird <= randomBirdThreshold && colliderOverlap.Length == 0)
            {
                GameObject newBird = bird.GetPooledObject();
                Vector3 BirdPosition = new Vector3(Random.Range(10f, 60f), Random.Range(10, 30f), 0f);
                newBird.transform.position = transform.position + BirdPosition;
                newBird.transform.rotation = transform.rotation;
                newBird.SetActive(true);
            }

            if (0 <= diceCollect1 && diceCollect1 <= randomCoinThreshold1 && colliderOverlap.Length == 0)
            {
                GameObject newCoin1 = coin1.GetPooledObject();
                Vector3 CoinPosition1 = new Vector3(Random.Range(10f, 60f), Random.Range(5f, 30f), 0f);
                newCoin1.transform.position = transform.position + CoinPosition1;
                newCoin1.transform.rotation = transform.rotation;
                newCoin1.SetActive(true);
            }

            if (0 <= diceCollect2 && diceCollect2 <= randomCoinThreshold2 && colliderOverlap.Length == 0)
            {
                GameObject newCoin2 = coin2.GetPooledObject();
                Vector3 CoinPosition2 = new Vector3(Random.Range(10f, 60f), Random.Range(5f, 30f), 0f);
                newCoin2.transform.position = transform.position + CoinPosition2;
                newCoin2.transform.rotation = transform.rotation;
                newCoin2.SetActive(true);
            }


            if (0 <= diceCollect3 && diceCollect3 <= randomCoinThreshold3 && colliderOverlap.Length == 0)
            {
                GameObject newCoin3 = coin3.GetPooledObject();
                Vector3 CoinPosition3 = new Vector3(Random.Range(10f, 60f), Random.Range(5f, 30f), 0f);
                newCoin3.transform.position = transform.position + CoinPosition3;
                newCoin3.transform.rotation = transform.rotation;
                newCoin3.SetActive(true);
            }

            if (0 <= diceAirPlatform1 && diceAirPlatform1 <= randomPlatformThreshold1 && colliderOverlap.Length == 0)
            {
                GameObject newPlatform1 = platform1.GetPooledObject();
                Vector3 PlatformPosition1 = new Vector3(Random.Range(10f, 60f), Random.Range(10, 30f), 0f);
                newPlatform1.transform.position = transform.position + PlatformPosition1;
                newPlatform1.transform.rotation = transform.rotation;
                newPlatform1.SetActive(true);
            }

            if (0 <= diceAirPlatform2 && diceAirPlatform2 <= randomPlatformThreshold2 && colliderOverlap.Length == 0)
            {
                GameObject newPlatform2 = platform2.GetPooledObject();
                Vector3 PlatformPosition2 = new Vector3(Random.Range(10f, 60f), Random.Range(10, 30f), 0f);
                newPlatform2.transform.position = transform.position + PlatformPosition2;
                newPlatform2.transform.rotation = transform.rotation;
                newPlatform2.SetActive(true);
            }

            if (0 <= diceAirPlatform3 && diceAirPlatform3 <= randomPlatformThreshold3 && colliderOverlap.Length == 0)
            {
                GameObject newPlatform3 = platform3.GetPooledObject();
                Vector3 PlatformPosition3 = new Vector3(Random.Range(10f, 60f), Random.Range(10, 30f), 0f);
                newPlatform3.transform.position = transform.position + PlatformPosition3;
                newPlatform3.transform.rotation = transform.rotation;
                newPlatform3.SetActive(true);
            }


            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }
    }
}