using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 randomPos = transform.position + new Vector3(
                Random.Range(-5f, 5f),
                0,
                Random.Range(-5f, 5f)
            );

            Instantiate(enemyPrefab, randomPos, Quaternion.identity);
        }
    }
}