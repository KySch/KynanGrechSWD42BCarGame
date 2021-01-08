using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] ObstacleWaves waveConfig;

    int waypointIndex = 0;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        waypoints = waveConfig.GetWaypoints();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    //setting up a WaveConfig
    public void SetWaveConfig(ObstacleWaves waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }


    private void EnemyMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;

            targetPosition.z = 0f;

            var enemyMovement = waveConfig.GetObstacleMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovement);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }

        }

        else
        {
            Destroy(gameObject);
        }

    }
}
