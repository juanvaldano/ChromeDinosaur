using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTests
    {
        [UnityTest]
        public IEnumerator JumpTest()
        {
            //Creation of the Player GameObject with the necessary components
            GameObject player = new GameObject();
            player.AddComponent<PlayerController>();
            player.AddComponent<Rigidbody2D>();

            //Wait to make sure the Player is on the ground
            yield return new WaitForSeconds(1f);
            Vector3 originalPos = player.transform.position;

            //Order it to jump
            player.GetComponent<PlayerController>().Jump();

            //Wait until it's in the air
            yield return new WaitForSeconds(0.2f);

            //Expect the original position it used to occupy when on the ground is not the same now that it's jumping
            Assert.AreNotEqual(originalPos, player.transform.position);
        }
    }
}
