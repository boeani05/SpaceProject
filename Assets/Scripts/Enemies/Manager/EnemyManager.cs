using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private EnemyCombat enemyCombat;
    private EnemyHealth enemyHealth;
    private EnemyKnockback enemyKnockback;
    private EnemyNavigation enemyNavigation;

    void Awake()
    {
        InitalizeEnemyMovement();
        InitializeEnemyCombat();
        InitializeEnemyHealth();
        InitializeEnemyKnockback();
        InitializeEnemyNavigation();
    }

    void Start()
    {
        Debug.Log("SUBSCRIBED");
        enemyHealth.OnDeath += () => Destroy(gameObject);
    }

    private void InitalizeEnemyMovement()
    {
        enemyMovement = gameObject.GetComponent<EnemyMovement>();
    }

    private void InitializeEnemyCombat()
    {
        enemyCombat = gameObject.GetComponent<EnemyCombat>();
    }

    private void InitializeEnemyHealth()
    {
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
    }

    private void InitializeEnemyKnockback()
    {
        enemyKnockback = gameObject.GetComponent<EnemyKnockback>();
    }

    private void InitializeEnemyNavigation()
    {
        enemyNavigation = gameObject.GetComponent<EnemyNavigation>();
    }
}
