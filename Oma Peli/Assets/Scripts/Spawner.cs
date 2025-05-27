using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public List<Transform> SpawnPositions;
    public GameObject Enemy;
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1.5f / (1 + Mathf.Floor(GameManager.Instance.gameTime / 10)));
        Instantiate(Enemy, SpawnPositions[UnityEngine.Random.Range(0, SpawnPositions.Count)].position, Quaternion.identity);
        StartCoroutine(SpawnEnemy());
    }

}