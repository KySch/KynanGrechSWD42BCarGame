using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")]

public class ObstacleWaves : ScriptableObject
{

    [SerializeField] GameObject obstaclePrefab;

    [SerializeField] GameObject pathPrefab;

    [SerializeField] public float obstacleMoveSpeed = 2f;

    [SerializeField] public int numberOfObstacles = 5;

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


    public int GetNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float GetObstacleMoveSpeed()
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
