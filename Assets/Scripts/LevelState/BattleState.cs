using System.Collections.Generic;
using Player;
using UnityEngine;

namespace LevelState
{
    public class BattleState : LevelBaseState
    {
        public override void EnterState(LevelStateManager levelStateManager)
        {
            Debug.Log("Battle!!");
            int armyCount = levelStateManager.spawnedPlayer.GetComponent<Army>().units.Count;
            int diff = levelStateManager.currentLevel.ArmyBattle(armyCount);
            Debug.Log($"Battle result: {diff}");
            levelStateManager.SwitchState(levelStateManager.playLevelState);
        }

        public override void UpdateState(LevelStateManager levelStateManager)
        {
        }
    }
}