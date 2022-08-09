using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float initialSpawnTime = 1f;
    [SerializeField] float intervalSpawnTime = 3f;

    private Spawner[] spawners;

    void Start()
    {
        spawners = GetComponentsInChildren<Spawner>();
        InvokeRepeating("OrderSpawn", initialSpawnTime, intervalSpawnTime);
    }

    private void OrderSpawn()
    {
        int randomValue = Random.Range(0, spawners.Length);
        spawners[randomValue].SpawnEnemy();
    }
}
