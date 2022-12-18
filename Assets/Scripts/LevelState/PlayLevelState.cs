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
            levelStateManager.spawnedPlayer.GetComponent<Army>().FreeMove();

            if (levelStateManager.currentLevel.IsBattle(levelStateManager.spawnedPlayer)) {
                levelStateManager.SwitchState(levelStateManager.battleState);
            }

            if (levelStateManager.spawnedPlayer.GetComponent<Army>().IsAllUnitDies()) {
                levelStateManager.SwitchState(levelStateManager.resultLevelState);
            }

            if (levelStateManager.currentLevel.IsFinish(levelStateManager.spawnedPlayer)) {
                levelStateManager.SwitchState(levelStateManager.resultLevelState);
            }
        }
    }
}