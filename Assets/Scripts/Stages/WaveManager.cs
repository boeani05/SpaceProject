using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private StageData stageData;
    private int currentWaveIndex;
    private EnemySpawner enemySpawner;
    private EnemyDeathHandler enemyDeathHandler;
    public Action OnAllWavesCleared;
    
    void Awake()
    {
        currentWaveIndex = 0;
        enemySpawner = gameObject.GetComponent<EnemySpawner>();
        enemyDeathHandler = gameObject.GetComponent<EnemyDeathHandler>();
    }

    void Start()
    {
        enemyDeathHandler.OnWaveCleared += HandleWaveCleared;
        OnAllWavesCleared += HandleAllWavesCleared;
        StartWave();
    }

    void OnDestroy()
    {
        enemyDeathHandler.OnWaveCleared -= HandleWaveCleared;
        OnAllWavesCleared -= HandleAllWavesCleared;
    }

    private void StartWave()
    {
        WaveData currentWaveData = stageData.GetWaves()[currentWaveIndex];

        BaseEnemyHealth[] enemies = enemySpawner.Spawn(currentWaveData.GetEnemyPool(), currentWaveData.GetEnemyCount());
        enemyDeathHandler.TrackWave(enemies);
    }

    private void HandleWaveCleared()
    {
        currentWaveIndex++;
        
        if (currentWaveIndex < stageData.GetWaves().Count)
        {
            StartWave();
        } else
        {
            OnAllWavesCleared?.Invoke();
        }
    }

    private void HandleAllWavesCleared()
    {
        Debug.Log("BOSS WAVE SPAWNING");
    }
}
