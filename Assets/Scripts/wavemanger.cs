using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    public int baseEnemies = 3;
    public int enemiesPerWave = 2;
    public float spawnRadius = 8f;

    public TMP_Text waveIntroText;
    public float introDuration = 2f;
    public float spawnDelayAfterIntro = 0.5f;

    int currentWave = 0;
    int enemiesAlive = 0;

    bool isStartingWave = false;

    void Start()
    {
        StartWave();
    }

    void Update()
    {
        if (!isStartingWave && enemiesAlive <= 0)
        {
            StartWave();
        }
    }

    void StartWave()
    {
        currentWave++;
        isStartingWave = true;

        int enemyCount = baseEnemies + (currentWave - 1) * enemiesPerWave;
        enemiesAlive = enemyCount;

        ShowWaveIntro();

        // Wait for intro + extra delay before spawning
        Invoke(nameof(SpawnEnemies), introDuration + spawnDelayAfterIntro);
    }

    void SpawnEnemies()
    {
        int enemyCount = enemiesAlive;

        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 spawnPos = (Vector2)player.position +
                               Random.insideUnitCircle.normalized * spawnRadius;

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }

        isStartingWave = false;
    }

    void ShowWaveIntro()
    {
        if (waveIntroText != null)
        {
            waveIntroText.gameObject.SetActive(true);
            waveIntroText.text = "Wave " + currentWave + " Incoming";
        }

        Invoke(nameof(HideWaveIntro), introDuration);
    }

    void HideWaveIntro()
    {
        if (waveIntroText != null)
        {
            waveIntroText.gameObject.SetActive(false);
        }
    }

    public void EnemyDied()
    {
        enemiesAlive--;
        if (enemiesAlive < 0) enemiesAlive = 0;
    }
}