using System;
using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    public Action OnWaveCleared;
    private int aliveCounter;

    public void TrackWave(BaseEnemyHealth[] enemies)
    {
        aliveCounter = enemies.Length;
        foreach (BaseEnemyHealth enemy in enemies)
        {
            enemy.OnDeath += HandleEnemyDeath;
        }
    }

    private void HandleEnemyDeath()
    {
        aliveCounter--;
        
        if(aliveCounter <= 0) OnWaveCleared?.Invoke();
    }
}