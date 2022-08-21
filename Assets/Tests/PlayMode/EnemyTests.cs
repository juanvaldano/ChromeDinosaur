using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EnemyTests
    {
        [UnityTest]
        public IEnumerator EnemyMovementTest()
        {
            //Create a new Enemy Gameobject with the necessary components
            GameObject enemy = new GameObject();
            enemy.AddComponent<EnemyController>();

            //Check if the original position of the enemy is the center of the screen
            Assert.AreEqual(enemy.transform.position, new Vector3(0f, 0f, 0f));

            //Store exposed speed attribute
            float speed = enemy.GetComponent<EnemyController>().speed;

            //Change RigidbodyType2D to Kinematic to avoid it being affected by gravity
            enemy.AddComponent<Rigidbody2D>();
            enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

            //Wait for it to move (it starts moving as soon as it wakes up)
            float timeToWait = 1.0f;
            yield return new WaitForSeconds(timeToWait);

            //Check the distance between the place where the enemy is and where we expect it to be
            float minAcceptableDiscrepancy = Vector3.Distance(enemy.transform.position, new Vector3(-speed * timeToWait, 0f, 0f));

            Assert.Less(minAcceptableDiscrepancy, 0.1f);
        }
    }
}
