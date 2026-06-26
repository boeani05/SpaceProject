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
        StartCoroutine(Suck());
    }

    protected abstract void AffectEnemy(Collider2D collider);

    private IEnumerator Suck()
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
                AffectEnemy(collider);
            }
            timePassed += Time.deltaTime;

            yield return null;
        }
        Destroy(gameObject);
    }
}
