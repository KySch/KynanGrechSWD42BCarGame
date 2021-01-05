using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class Waves : ScriptableObject
{

    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] int numberOfObstacles = 5;
    [SerializeField] float obstacleMoveSpeed = 2f;


    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWayPoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
    }


    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfObstacles;
    }

    public float GetEnemyMoveSpeed()
    {
        return obstacleMoveSpeed;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
