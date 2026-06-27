using UnityEngine;

public abstract class BaseEnemyCombat : MonoBehaviour
{
    private IDamageSource damageSource;

    protected virtual void Awake()
    {
        InitializeDamageSource();
    }

    private void InitializeDamageSource()
    {
        damageSource = gameObject.GetComponent<IDamageSource>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        DealDamage(collision.gameObject);
    }

    protected virtual void DealDamage(GameObject target)
    {
        target.gameObject.GetComponent<IDamageable>()?.ApplyDamage(damageSource.GetDamage(), Element.NONE);
    }
}
