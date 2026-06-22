using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    enum ScreenSide
    {
        TOP,
        RIGHT,
        BOTTOM,
        LEFT
    }

    [SerializeField] private float offset;

    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    public BaseEnemyHealth[] Spawn(GameObject[] pool, int count)
    {
        BaseEnemyHealth[] spawnedEnemies = new BaseEnemyHealth[count];

        for (int i = 0; i < count; i++)
        {
            spawnedEnemies[i] = Instantiate(pool[Random.Range(0, pool.Length)], GetRandomEdgePosition(), Quaternion.identity).GetComponent<BaseEnemyHealth>();
        }
        return spawnedEnemies;
    }

    private Vector3 GetRandomEdgePosition()
    {
        ScreenSide screenSide = (ScreenSide) Random.Range(0, 4);
        Vector2 randomEdgePosition;

        switch(screenSide)
        {
            case ScreenSide.TOP:
                randomEdgePosition = new Vector2(Random.Range(0.0f, 1.0f), 1.0f + offset);
                break;
            
            case ScreenSide.RIGHT:
                randomEdgePosition = new Vector2(1.0f + offset, Random.Range(0.0f, 1.0f));
                break;

            case ScreenSide.BOTTOM:
                randomEdgePosition = new Vector2(Random.Range(0.0f, 1.0f), -offset);
                break;

            default:
                randomEdgePosition = new Vector2(-offset, Random.Range(0.0f, 1.0f));
                break;
        }

        Vector3 convertedWorldPosition = mainCamera.ViewportToWorldPoint(randomEdgePosition);
        convertedWorldPosition.z = 0;

        return convertedWorldPosition;
    }
}
