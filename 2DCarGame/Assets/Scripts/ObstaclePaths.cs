using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePaths : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] Waves waves;

    int waypointIndex = 0;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        waypoints = waves.GetWaypoints();
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMove();
    }

    public void SetWaveConfig(Waves waveToSet)
    {
        waves = waveToSet;
    }


    private void ObstacleMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;

            targetPosition.z = 0f;

            var obstacleMovement = waves.GetEnemyMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, obstacleMovement);

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

