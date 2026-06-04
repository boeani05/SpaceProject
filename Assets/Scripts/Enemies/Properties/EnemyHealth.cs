using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    private EnemyStat enemyStat;

    void Awake()
    {
        InitializeEnemyStat();
    }
    private void InitializeEnemyStat()
    {
        enemyStat = gameObject.GetComponent<EnemyStat>();
    }
    void Update()
    {
        if (!IsEnemyAlive())
        {
            Destroy(gameObject);
        }
    }

    public void ApplyDamage(float damage)
    {
        enemyStat.SetHealth(enemyStat.GetHealth() - damage);
    }

    private bool IsEnemyAlive()
    {
        return enemyStat.GetHealth() > 0.0f;
    }
}
