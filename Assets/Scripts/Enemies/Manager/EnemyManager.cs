using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private EnemyHealth enemyHealth;

    void Awake()
    {
        InitializeEnemyHealth();
    }

    private void InitializeEnemyHealth()
    {
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
    }

    void Start()
    {
        enemyHealth.OnDeath += () => Destroy(gameObject);
    }
}
