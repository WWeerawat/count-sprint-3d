using UnityEngine;

namespace LevelState
{
    public class ResultLevelState : LevelBaseState
    {
        public override void EnterState(LevelStateManager levelStateManager)
        {
            levelStateManager.DestroyPlayer();
            GameManager.Instance.mainMenuUI.SetActive(true);

            Object.Destroy(levelStateManager.currentLevelObj);
            levelStateManager.SwitchState(levelStateManager.initiateLevelState);
        }

        public override void UpdateState(LevelStateManager levelStateManager)
        {
        }
    }
}