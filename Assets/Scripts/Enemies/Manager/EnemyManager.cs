using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private BaseEnemyHealth enemyHealth;

    void Awake()
    {
        InitializeEnemyHealth();
    }

    private void InitializeEnemyHealth()
    {
        enemyHealth = gameObject.GetComponent<BaseEnemyHealth>();
    }

    void Start()
    {
        enemyHealth.OnDeath += () => Destroy(gameObject);
    }
}
