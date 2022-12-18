using Player;
using UnityEngine;

namespace LevelState
{
    public class PlayLevelState : LevelBaseState
    {
        public override void EnterState(LevelStateManager levelStateManager)
        {
            Debug.Log("Play level");
            levelStateManager.spawnedPlayer.GetComponent<Army>().ActiveUnitMoveAnimation(true);
        }
        public override void UpdateState(LevelStateManager levelStateManager)
        {
            Debug.Log(levelStateManager.spawnedPlayer.GetComponent<Army>().units.Count);
            levelStateManager.spawnedPlayer.GetComponent<Army>().FreeMove();
            if (levelStateManager.spawnedPlayer.GetComponent<Army>().IsAllUnitDies()) {
                levelStateManager.ResetLevel();
            }

            if (levelStateManager.currentLevel.IsFinish(levelStateManager.spawnedPlayer)) {
                levelStateManager.SwitchState(levelStateManager.resultLevelState);
            }
        }
    }
}