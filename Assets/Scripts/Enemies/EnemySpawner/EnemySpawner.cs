using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    void Awake()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
