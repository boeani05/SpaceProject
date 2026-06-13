using System.Collections;
using UnityEngine;

public class BattleShipCombat : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    private BattleShipDistanceChecker distanceChecker;
    private PlayerLocator playerLocator;
    private BattleShipCombatStats combatStats;

    private bool canShoot;

    void Awake()
    {
        distanceChecker = gameObject.GetComponent<BattleShipDistanceChecker>();
        playerLocator = gameObject.GetComponent<PlayerLocator>();
        combatStats = gameObject.GetComponent<BattleShipCombatStats>();
        canShoot = true;
    }

    void Update()
    {
        if (distanceChecker.IsInRange() && canShoot)
        {
            canShoot = false;
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        GameObject spawnedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        SetDirectionOfProjectile(spawnedProjectile, (playerLocator.GetPlayerPosition() - (Vector2)transform.position).normalized);
        yield return new WaitForSeconds(combatStats.GetCooldown());
        canShoot = true;
    }

    private void SetDirectionOfProjectile(GameObject projectile, Vector2 direction)
    {
        projectile.GetComponent<IProjectile>().SetDirection(direction);
    }
}
