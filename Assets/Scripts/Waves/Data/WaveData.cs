using UnityEngine;

[System.Serializable]
public class WaveData
{
    [SerializeField] private int enemyCount;
    [SerializeField] private float delayAfterWave;
    [SerializeField] private GameObject[] enemyPool;

    public int GetEnemyCount() => enemyCount;
    public float GetDelayAfterWave() => delayAfterWave;
    public GameObject[] GetEnemyPool() => enemyPool;
}
