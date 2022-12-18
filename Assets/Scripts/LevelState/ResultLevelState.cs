using UnityEngine;

namespace LevelState
{
    public class ResultLevelState : LevelBaseState
    {
        public override void EnterState(LevelStateManager levelStateManager)
        {
            Debug.Log("Finished!!");
            levelStateManager.DestroyPlayer();
            GameManager.Instance.mainMenuUI.SetActive(true);
        }
        public override void UpdateState(LevelStateManager levelStateManager)
        {
        }
    }
}