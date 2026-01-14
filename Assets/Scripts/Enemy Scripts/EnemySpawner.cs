using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnInfo
    {
        public GameObject enemy;
        public int count;
        public float timeBetweenSpawns = 1;
    }

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public EnemySpawnInfo[] enemies;
        public float timeBetweenWaves = 3;
    }

    public Transform[] spawnPoints;
    public Wave[] waves;

    private bool playWave = false;
    private bool autoPlay = false;
    private int enemiesRemaining;

    [SerializeField] GameObject spawnParticles;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        // iterate through all the waves
        for (int i = 0; i <= waves.Length - 1; i++)
        {
            //iterate through each waves enemy info to ge the amount or whatever 
            Debug.Log("on wave: " + waves[i].waveName);
            for (int j = 0; j <= waves[i].enemies.Length - 1; j++)
            {
                // spawn the next wave and set play back to 0
                playWave = false;
                enemiesRemaining = waves[i].enemies[j].count;
                //iterate and spawn the enemies in each wave
                for (int k = 0; k < waves[i].enemies[j].count; k++)
                {
                    // if autoplay is not on...
                    if(autoPlay != true)
                    {
                        //wait until play is pressed
                        yield return new WaitUntil(() => playWave);
                    }
                    //else just continue the next wave
                    
                    //acwuire a rando spawn point
                    Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                    //spawn warning spawnParticles effect before enemy spawns
                    if(spawnParticles != null){
                        Instantiate(spawnParticles, spawnPoint);
                    }
                    //wait for a bit
                    yield return new WaitForSeconds(0.5f);
                    //spawn the enemy at that spawn point
                    Instantiate(waves[i].enemies[j].enemy, spawnPoint);
                    yield return new WaitForSeconds(waves[i].enemies[j].timeBetweenSpawns);
                }
                yield return new WaitUntil(() => enemiesRemaining <= 0);

                
            }
        }
    }
    public void AutoPlay()
    {
        if(autoPlay != true)
        {
            autoPlay = true;
        }
        else
        {
            autoPlay = false;
        }
    }

    

    public void Play()
    {
        playWave = true;
    }
    private void OnEnable()  => EnemyHealth.OnEnemyDied += HandleEnemyDeath;
    private void OnDisable() => EnemyHealth.OnEnemyDied -= HandleEnemyDeath;

    private void HandleEnemyDeath()
    {
        enemiesRemaining--;
    }





}
