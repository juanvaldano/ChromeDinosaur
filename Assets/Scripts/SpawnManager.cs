using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float initialSpawnTime = 1f;
    [SerializeField] float intervalSpawnTime = 3f;
    [SerializeField] int enemyAmount = 5;

    /*A queue was used rather than a list since it accomplishes the specific
    purpose we're after and it's more function appropriate*/
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
            SMInstance = this;
        }

        enemyQueue = new Queue<GameObject>();
        InitiateEnemyQueue();
        spawners = GetComponentsInChildren<Spawner>();

        if(!Utils.AllPositiveValues(initialSpawnTime, intervalSpawnTime))
        {
            Debug.LogError("Float values for spawn start must be positive");
        }
        else
        {
            InvokeRepeating("OrderSpawn", initialSpawnTime, intervalSpawnTime);
        }
    }

    private void InitiateEnemyQueue()
    {
        //Guard clause, it stops the program into running into an unexpected error
        if(!Utils.AllPositiveValues(enemyAmount))
        {
            Debug.LogError("Enemy amount must be a positive integer");
            return;
        }

        //Spawn enemies and add them to the queue
        for(int i=0; i<enemyAmount; i++)
        {
            GameObject enemy = Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"), transform.position, transform.rotation);
            enemyQueue.Enqueue(enemy);
        }
    }

    //Tell a random spawner to "spawn" an enemy
    private void OrderSpawn()
    {
        int randomValue = Random.Range(0, spawners.Length);
        spawners[randomValue].SpawnEnemy(enemyQueue.Dequeue());
    }

    //Allow enemies to add themselved back to the queue
    public void AddEnemyToQueue(GameObject enemy)
    {
        enemyQueue.Enqueue(enemy);
    }
}
