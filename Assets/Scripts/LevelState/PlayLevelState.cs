using Player;

namespace LevelState
{
    public class PlayLevelState : LevelBaseState
    {
        public override void EnterState(LevelStateManager levelStateManager)
        {
            levelStateManager.spawnedPlayerArmy.GetComponent<Army>().ActiveUnitMoveAnimation(true);
        }
        public override void UpdateState(LevelStateManager levelStateManager)
        {
            levelStateManager.spawnedPlayerArmy.GetComponent<Army>().ForceMove();

            if (levelStateManager.currentLevel.IsBattle(levelStateManager.spawnedPlayerArmy)) {
                levelStateManager.SwitchState(levelStateManager.battleState);
            }

            if (levelStateManager.spawnedPlayerArmy.GetComponent<Army>().IsAllUnitDies()) {
                levelStateManager.SwitchState(levelStateManager.resultLevelState);
            }

            if (levelStateManager.currentLevel.IsFinish(levelStateManager.spawnedPlayerArmy)) {
                levelStateManager.SwitchState(levelStateManager.resultLevelState);
            }
        }
    }
}