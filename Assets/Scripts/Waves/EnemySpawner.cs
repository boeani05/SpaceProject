using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public BaseEnemyHealth[] Spawn(GameObject[] pool, int count)
    {
        BaseEnemyHealth[] spawnedEnemies = new BaseEnemyHealth[count];

        for (int i = 0; i < count; i++)
        {
            spawnedEnemies[i] = Instantiate(pool[Random.Range(0, pool.Length)], transform.position, Quaternion.identity).GetComponent<BaseEnemyHealth>();
        }
        return spawnedEnemies;
    }
}
