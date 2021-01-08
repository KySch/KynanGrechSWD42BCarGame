using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //a list of WaveConfigs
    [SerializeField] List<ObstacleWaves> waveConfigs;

    [SerializeField] bool looping = false;

    //we always start  from Wave 0
    int startingWave = 0;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            //start the coroutine that spawns all enemies in our currentWave
            yield return StartCoroutine(SpawnAllWaves());
        }
        //when coroutine SpawnAllWaves finishes check if looping == true
        while (looping);
    }


    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator SpawnAllEnemiesInWave(ObstacleWaves waveConfig)
    {
        //spawns an enemy until enemyCount == GetNumberOfEnemies()
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfObstacles(); enemyCount++)
        {
            //spawn the enemy from 
            //at the position specified by the waveConfig waypoints
            var newEnemy = Instantiate(
                waveConfig.GetObstaclePrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            //the wave will be selected from here and the enemy applied to it
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(1);
        }

    }

    private IEnumerator SpawnAllWaves()
    {
        //this will loop from startingWave until we reach the last within our List
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            //the coroutine will wait for all enemies in Wave to spawn
            //before yielding and going to the next loop
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }


}