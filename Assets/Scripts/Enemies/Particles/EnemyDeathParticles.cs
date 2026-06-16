using UnityEngine;

public class EnemyDeathParticles : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private BaseEnemyHealth enemyHealth;

    void Awake()
    {
        enemyHealth = gameObject.GetComponent<BaseEnemyHealth>();
    }

    void Start()
    {
        enemyHealth.OnDeath += SpawnParticle;
    }

    private void SpawnParticle()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
