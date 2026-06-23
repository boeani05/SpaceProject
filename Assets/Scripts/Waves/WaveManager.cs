using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<WaveData> waves;
    
    private int currentWaveIndex;
    private int aliveCounter;
    private EnemySpawner enemySpawner;

    public Action OnAllWavesCleared;

    void Awake()
    {
        currentWaveIndex = 0;
        enemySpawner = gameObject.GetComponent<EnemySpawner>();
    }

    void Start()
    {
        OnAllWavesCleared += HandleAllWavesCleared;
        StartWave();
    }

    void OnDestroy()
    {
        OnAllWavesCleared -= HandleAllWavesCleared;
    }

    private void StartWave()
    {
        WaveData currentWaveData = waves[currentWaveIndex];

        BaseEnemyHealth[] spawnedEnemies = enemySpawner.Spawn(currentWaveData.GetEnemyPool(), currentWaveData.GetEnemyCount());
        aliveCounter = spawnedEnemies.Length;

        foreach(BaseEnemyHealth enemy in spawnedEnemies)
        {
            enemy.OnDeath += HandleEnemyDeath;
        }
    }

    private void HandleEnemyDeath()
    {
        aliveCounter--;
        
        if(aliveCounter <= 0)
        {
            currentWaveIndex++;

            if(currentWaveIndex < waves.Count)
            {
                StartWave();
            } else
            {
                OnAllWavesCleared?.Invoke();
            }
        }
    }

        private void HandleAllWavesCleared()
    {
        Debug.Log("BOSS WAVE SPAWNING");
    }
}
