using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private EnemyHealth enemyHealth;

    void Awake()
    {
        InitializeEnemyHealth();
    }

    void Start()
    {
        enemyHealth.OnDeath += () => Destroy(gameObject);
    }

    private void InitializeEnemyHealth()
    {
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
    }
}
