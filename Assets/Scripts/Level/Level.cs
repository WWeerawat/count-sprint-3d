using System;
using Player;
using UnityEngine;

namespace Level
{
    public class Level : MonoBehaviour
    {
        public GameObject startLine;

        public GameObject finishLine;

        public GameObject enemySpawnPoint;
        public int enemySpawnCount;

        public bool IsFinish(GameObject player)
        {
            return Math.Abs(player.transform.position.z - finishLine.transform.position.z) < 1;
        }

        public bool IsBattle(GameObject player, GameObject enemy)
        {
            return Math.Abs(player.transform.position.z - enemy.transform.position.z) < 2;
        }
        
        public void SpawnEnemy(GameObject armyObj)
        {
            GameObject enemyObj = Instantiate(armyObj, enemySpawnPoint.transform.position, Quaternion.identity);
            enemyObj.GetComponent<Army>().Spawn(enemySpawnCount);
        }

        public int ArmyBattle(int playerCount)
        {
            return playerCount - enemySpawnCount;
        }
    }
}