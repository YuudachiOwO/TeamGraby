using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //Components
    [SerializeField] public Transform levelPart_Start;
    [SerializeField] public Transform EndlessGround;
    [SerializeField] public GameObject player;
    public GameObject[] End;
    public Vector3[] EndPos;
    private const float PlayerDistance = 200f;
    private Vector3 lastEndPosition;
    private Vector3 DestroyPosition;


    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Start()
    {
        End = GameObject.FindGameObjectsWithTag("EndPosition");

    }

    //If the player is ?? away from a part, spawn a new LevelPart
    private void Update()
    {
        for (int i = 0; i < End.Length; i++)
        {
            GetComponent<LevelGenerator>().EndPos[i] = End[i].transform.position;
        }
        Debug.Log(EndPos);

        if (Vector3.Distance(player.transform.position, lastEndPosition) < PlayerDistance)
            SpawnLevelPart();

        //if (Vector3.Distance(player.transform.position, End)

    }

    //Spawn a Levelpart at the EndPosition Marker
    private void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    //Spawn LevelPart
    private Transform SpawnLevelPart(Vector3 spawnposition)
    {
        Transform levelPartTransform = Instantiate(EndlessGround, spawnposition, Quaternion.identity);
        return levelPartTransform;
    }
}
