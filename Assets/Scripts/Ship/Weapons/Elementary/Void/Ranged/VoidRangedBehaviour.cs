using System.Collections;
using UnityEngine;

public class VoidRangedBehaviour : MonoBehaviour
{
    private VoidRangedCombatStats stats;

    void Awake()
    {
        InitializeStats();
        StartCoroutine(Suck());
    }

    private void InitializeStats()
    {
        stats = gameObject.GetComponent<VoidRangedCombatStats>();
    }

    private IEnumerator Suck()
    {
        float timePassed = 0f;

        while(timePassed <= stats.GetDuration())
        {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, stats.GetRadiusOfPull());

            foreach (Collider2D collider in colliders)
            {
                collider.GetComponent<Rigidbody2D>().AddForce((transform.position - collider.transform.position) * stats.GetPullForce());
                collider.gameObject.GetComponent<IDamageable>()?.ApplyDamage(stats.GetDamage() * Time.deltaTime);
            }

            timePassed += Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
    }
}
