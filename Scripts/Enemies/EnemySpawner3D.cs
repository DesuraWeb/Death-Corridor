using UnityEngine;

public class EnemySpawner3D : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float laneOffset = 2f;
    float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        int lane = Random.Range(-2, 3); // 5 lanes : -2 à 2
        Vector3 pos = new Vector3(lane * laneOffset, 0.5f, transform.position.z);
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}
