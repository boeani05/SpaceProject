using System.Collections;
using UnityEngine;

public abstract class BaseBlackHole : MonoBehaviour
{
    private BaseBlackHoleStats blackHoleStats;

    protected virtual void Awake()
    {
        blackHoleStats = gameObject.GetComponent<BaseBlackHoleStats>();
    }

    protected virtual void Start()
    {
        StartCoroutine(PullRoutine());
        StartCoroutine(DamageRoutine());
    }

    protected abstract void ApplyTickEffect(Collider2D collider);

    private IEnumerator PullRoutine()
    {
        float timePassed = 0f;

        while (timePassed <= blackHoleStats.GetDuration())
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blackHoleStats.GetRadiusOfPull());

            foreach (Collider2D collider in colliders)
            {
                Rigidbody2D rigidbody = collider.GetComponent<Rigidbody2D>();
                if (rigidbody != null)
                {
                    rigidbody.AddForce((transform.position - collider.transform.position) * blackHoleStats.GetPullForce());
                }
            }
            timePassed += Time.deltaTime;

            yield return null;
        }
        Destroy(gameObject);
    }

    private IEnumerator DamageRoutine()
    {

        while (true)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blackHoleStats.GetRadiusOfPull());

            foreach (Collider2D collider in colliders)
            {
                ApplyTickEffect(collider);
            }

            yield return new WaitForSeconds(blackHoleStats.GetTickInterval());
        }
    }
}
