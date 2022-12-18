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
        public Transform startLine;

        public Transform finishLine;

        public List<Enemy> enemies;

        public bool IsFinish(GameObject playerArmy)
        {
            return Math.Abs(playerArmy.transform.position.z - finishLine.position.z) < 1;
        }

        public bool IsBattle(GameObject playerArmy)
        {
            return enemies.Any(enemy =>
                Math.Abs(playerArmy.transform.position.z - enemy.spawnPoint.position.z) < 2);
        }

        public void SpawnEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                GameObject enemyArmy =
                    Instantiate(enemy.armyPrefab, enemy.spawnPoint.position, Quaternion.identity);
                enemyArmy.transform.parent = enemy.spawnPoint;
                enemyArmy.GetComponent<Army>().Spawn(enemy.unitCount);

                foreach (GameObject unit in enemyArmy.GetComponent<Army>().units)
                {
                    unit.transform.rotation = new Quaternion(0, 180, 0, 0);
                }
            }
        }

        public Army WhoBattle(GameObject player)
        {
            return enemies
                .Find(enemy => Math.Abs(player.transform.position.z - enemy.spawnPoint.position.z) < 2)
                .spawnPoint.GetComponentInChildren<Army>();
        }
    }
}