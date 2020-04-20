using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform levelPart_1;
   

    private void Awake()
    {
        SpawnLevelPart(new Vector3(38, -4));
    }
    private void SpawnLevelPart(Vector3 spawnPosition)
    {
        Instantiate(levelPart_1, spawnPosition, Quaternion.identity);
    }
}
