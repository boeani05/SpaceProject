using UnityEngine;

public class PlayerLocator : MonoBehaviour
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

    public GameObject GetPlayer() => player;

    public Vector2 GetPlayerPosition()
    {
        return player.transform.position;
    }
}
