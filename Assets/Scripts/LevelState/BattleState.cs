using System.Collections.Generic;
using Player;
using Player.Enemy;
using UnityEngine;

namespace LevelState
{
    public class BattleState : LevelBaseState
    {
        public override void EnterState(LevelStateManager levelStateManager)
        {
            Debug.Log("Battle!!");

            // Army playerArmy = levelStateManager.GetSpawnPlayer().GetComponent<Army>();
            // Army enemyArmy = levelStateManager.currentLevel.WhoBattle(levelStateManager.GetSpawnPlayer());
            //
            //
            //
            // int armyCount = levelStateManager.spawnedPlayer.GetComponent<Army>().units.Count;
            // int diff = levelStateManager.currentLevel.ArmyBattle(armyCount);
            // Debug.Log($"Battle result: {diff}");
            levelStateManager.SwitchState(levelStateManager.playLevelState);
        }

        public override void UpdateState(LevelStateManager levelStateManager)
        {
        }
    }
}