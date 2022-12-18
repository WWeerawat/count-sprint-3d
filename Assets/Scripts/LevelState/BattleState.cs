using System;
using Player;
using UnityEngine;

namespace LevelState
{
    public class BattleState : LevelBaseState
    {
        private Army playerArmy;
        private Army enemyArmy;
        public override void EnterState(LevelStateManager levelStateManager)
        {
            playerArmy = levelStateManager.GetSpawnPlayer().GetComponent<Army>();
            enemyArmy = levelStateManager.currentLevel.WhoBattle(levelStateManager.GetSpawnPlayer());

            Vector3 position = enemyArmy.transform.position;
            Vector3 point = position + (playerArmy.transform.position - position) / 2;

            for (int i = 0; i < Math.Max(playerArmy.units.Count, enemyArmy.units.Count); i++) {
                enemyArmy.units[i].GetComponent<Unit>().MoveWorld(point);
                playerArmy.units[i].GetComponent<Unit>().MoveWorld(point);
            }
        }

        public override void UpdateState(LevelStateManager levelStateManager)
        {
            if (!playerArmy.IsAllUnitDies() && !enemyArmy.IsAllUnitDies()) return;

            if (playerArmy.IsAllUnitDies()) {
                levelStateManager.SwitchState(levelStateManager.resultLevelState);
                return;
            }

            playerArmy.SetFormation();
            levelStateManager.SwitchState(levelStateManager.playLevelState);
        }
    }
}