using UnityEngine;

public abstract class BaseEnemyNavigation : MonoBehaviour
{
    private GameObject player;

    void Awake()
    {
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        player = GameObject.FindWithTag("Player");
    }
    public Vector2 EvaluateDirection()
    {
        return (player.transform.position - transform.position).normalized;
    }
}
