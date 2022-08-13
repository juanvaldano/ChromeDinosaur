using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float initialSpawnTime = 1f;
    [SerializeField] float intervalSpawnTime = 3f;
    [SerializeField] int enemyAmount = 5;

    private Queue<GameObject> enemyQueue;
    private Spawner[] spawners;

    public static SpawnManager SMInstance { get; private set; }

    private void Awake()
    {
        if (SMInstance != null && SMInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            SMInstance = this;
        }

        enemyQueue = new Queue<GameObject>();
        InitiateEnemyQueue();
        spawners = GetComponentsInChildren<Spawner>();
        InvokeRepeating("OrderSpawn", initialSpawnTime, intervalSpawnTime);
    }

    private void InitiateEnemyQueue()
    {
        if(enemyAmount <= 0)
        {
            Debug.LogError("Enemy amount must be a positive integer");
            return;
        }

        for(int i=0; i<enemyAmount; i++)
        {
            GameObject enemy = Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"), transform.position, transform.rotation);
            enemyQueue.Enqueue(enemy);
        }
    }

    private void OrderSpawn()
    {
        int randomValue = Random.Range(0, spawners.Length);
        spawners[randomValue].SpawnEnemy(enemyQueue.Dequeue());
    }

    public void AddEnemyToQueue(GameObject enemy)
    {
        enemyQueue.Enqueue(enemy);
    }
}
