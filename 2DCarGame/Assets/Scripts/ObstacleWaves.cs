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
        //each wave can have different waypoints
        var waveWayPoints = new List<Transform>();
        
        //go into Path prefab and for each child, add it to the List waveWaypoints
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
