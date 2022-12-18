using System;
using System.Collections.Generic;
using System.Linq;
using Player;
using Player.Enemy;
using UnityEngine;

namespace Level
{
    public class Level : MonoBehaviour
    {
        public GameObject startLine;

        public GameObject finishLine;

        public List<Enemy> enemies;

        public bool IsFinish(GameObject player)
        {
            return Math.Abs(player.transform.position.z - finishLine.transform.position.z) < 1;
        }

        public bool IsBattle(GameObject player)
        {
            return enemies.Any(enemy =>
                Math.Abs(player.transform.position.z - enemy.enemySpawnPoint.transform.position.z) < 2);
        }

        public void SpawnEnemies(GameObject armyObj)
        {
            foreach (Enemy enemy in enemies)
            {
                GameObject enemyObj =
                    Instantiate(armyObj, enemy.enemySpawnPoint.transform.position, Quaternion.identity);
                enemyObj.GetComponent<Army>().Spawn(enemy.enemySpawnCount);
            }
        }

        public int ArmyBattle(int playerCount)
        {
            return playerCount - enemies[0].enemySpawnCount;
        }

        public Army WhoBattle(GameObject player)
        {
            return enemies
                .Find(enemy => Math.Abs(player.transform.position.z - enemy.enemySpawnPoint.transform.position.z) < 2)
                .enemySpawnPoint.transform.GetComponentInChildren<Army>();
        }
    }
}