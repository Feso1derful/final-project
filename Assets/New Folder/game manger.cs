using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentRound = 1;
    public int enemiesRemaining;
    public EnemySpawner spawner;

    void Start()
    {
        if (spawner == null)
        {
            Debug.LogError("Spawner not assigned!");
            return;
        }

        StartRound();
    }

    public void StartRound()
    {
        Debug.Log("Round " + currentRound);
        enemiesRemaining = currentRound * 3;
        spawner.SpawnEnemies(enemiesRemaining);
    }

    public void EnemyKilled()
    {
        enemiesRemaining--;

        if (enemiesRemaining <= 0)
        {
            currentRound++;
            Invoke(nameof(StartRound), 2f);
        }
    }
}