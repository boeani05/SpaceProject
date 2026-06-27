using TMPro;
using UnityEngine;

public class DamageNumbersSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector2 offset;

    public void ShowDamageNumber(float damage, float multiplier)
    {
        DamageNumber damageNumber = Instantiate(prefab, transform.position + (Vector3)offset, Quaternion.identity).GetComponent<DamageNumber>();

        damageNumber.VisualizeDamageNumber(damage, multiplier);
    }
}
