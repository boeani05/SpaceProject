using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageData
{
    [SerializeField] private List<WaveData> waves;
    [SerializeField] private GameObject bossPrefab;

    public List<WaveData> GetWaves() => waves;
    public GameObject GetBossPrefab() => bossPrefab;
}
