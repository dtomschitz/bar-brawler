using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public enum spawnState { SPAWNING, WAITING, COUNTING }


    public Transform enemyPrefab;
    public Transform spawnPoint;

    public bool enableSpawing;

    public float timeBetweenWaves = 5.5f;
    private float waveCountdown;

    public Text stateOfGameText;

    private int waveIndex = 0;

    private float searchCountdown = 1f;

    public spawnState state = spawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
        state = spawnState.COUNTING;
    }

    void Update()
    {
        if (state == spawnState.WAITING)
        {
            if (!enemyIsAlive())
            {
                Start();
            }
            else
            {
                return;
            }
        }

        if (enableSpawing)
        {
            if (waveCountdown <= 0f)
            {
                if (state != spawnState.SPAWNING)
                {
                    StartCoroutine(SpawnWave());
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }

        stateOfGameText.text = Mathf.Floor(waveCountdown).ToString();
    }

    bool enemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        stateOfGameText.text = waveIndex.ToString();
        Debug.Log(waveIndex.ToString());
        state = spawnState.SPAWNING;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);

        }

        state = spawnState.WAITING;
        yield break;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}