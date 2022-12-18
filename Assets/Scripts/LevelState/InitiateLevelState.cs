using UnityEngine;

namespace LevelState
{
    public class InitiateLevelState : LevelBaseState
    {
        public override void EnterState(LevelStateManager levelStateManager)
        {
            Debug.Log("Init level");
            levelStateManager.currentLevelObj = levelStateManager.levels[0];
            levelStateManager.currentLevel = levelStateManager.currentLevelObj.GetComponent<Level.Level>();
            levelStateManager.currentLevelObj = Object.Instantiate(levelStateManager.currentLevelObj, Vector3.zero, Quaternion.identity);

            levelStateManager.currentLevel.SpawnEnemy(levelStateManager.player);
        }

        public override void UpdateState(LevelStateManager levelStateManager)
        {
        }
    }
}