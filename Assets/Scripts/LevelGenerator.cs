using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 50f;

    [SerializeField]
    private Transform _player;
    [SerializeField]
    private Transform levelPart_start;
    [SerializeField]
    private List<Transform> levelPartList;
    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelPart_start.Find("EndPosition").position;
        SpawnLevelPart();
    }
    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
    private void Update()
    {
        if (_player == null)
        {
            Debug.LogError("Player not found");
            return;
        }
        else
        {
            if (Vector3.Distance(_player.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
            {
                SpawnLevelPart();
            }
        }

    }
}
