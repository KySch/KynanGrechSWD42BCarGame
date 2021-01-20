using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<ObstacleWaves> waveConfigs;

    [SerializeField] bool looping = false;

    int startingWave = 0;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    void Update()
    {

    }
    private IEnumerator SpawnAllEnemiesInWave(ObstacleWaves waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfObstacles(); enemyCount++)
        {
            var newEnemy = Instantiate(
                waveConfig.GetObstaclePrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(1);
        }

    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}