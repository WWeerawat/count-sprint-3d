using System;
using System.Collections.Generic;
using DG.Tweening;
using Player;
using Player.Enemy;
using UnityEngine;

namespace LevelState
{
    public class BattleState : LevelBaseState
    {
        private Army playerArmy;
        private Army enemyArmy;
        public override void EnterState(LevelStateManager levelStateManager)
        {
            Debug.Log("Battle!!");

            playerArmy = levelStateManager.GetSpawnPlayer().GetComponent<Army>();
            enemyArmy = levelStateManager.currentLevel.WhoBattle(levelStateManager.GetSpawnPlayer());
            
            Vector3 point = enemyArmy.transform.position + (playerArmy.transform.position - enemyArmy.transform.position) / 2;
            
            for (int i = 0; i < Math.Max(playerArmy.units.Count, enemyArmy.units.Count); i++)
            {
                enemyArmy.units[i].GetComponent<Character>().MoveWorld(point);
                playerArmy.units[i].GetComponent<Character>().MoveWorld(point);
            }
        }

        public override void UpdateState(LevelStateManager levelStateManager)
        {
            if (!playerArmy.IsAllUnitDies() && !enemyArmy.IsAllUnitDies()) return;

            if (playerArmy.IsAllUnitDies())
            {
                levelStateManager.SwitchState(levelStateManager.resultLevelState);
                return;
            }
            
            levelStateManager.SwitchState(levelStateManager.playLevelState);
        }
    }
}