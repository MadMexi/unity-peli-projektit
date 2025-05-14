using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public GameObject squarePrefab;
    public float spawnInterval = 0.5f;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    /*
    private void Start()
    {
        InvokeRepeating(nameof(SpawnSquare), 1f, spawnInterval);
    }

    void SpawnSquare()
    {
        if (!GameManager.Instance.isGameActive) return;

        Vector2 randomPos = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        Instantiate(squarePrefab, randomPos, Quaternion.identity);
    }*/
}