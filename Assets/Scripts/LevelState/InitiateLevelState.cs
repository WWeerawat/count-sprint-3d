using TMPro;
using UnityEngine;

namespace LevelState
{
    public class InitiateLevelState : LevelBaseState
    {
        public override void EnterState(LevelStateManager levelStateManager)
        {
            Debug.Log("Init level");
            SetLevel(levelStateManager);
            InstantiateLevel(levelStateManager);
            
            levelStateManager.currentLevel.SpawnEnemies(levelStateManager.player);
        }

        public override void UpdateState(LevelStateManager levelStateManager)
        {
        }

        private void SetLevel(LevelStateManager levelStateManager)
        {
            levelStateManager.currentLevelObj = levelStateManager.levels[0];
            levelStateManager.currentLevel = levelStateManager.currentLevelObj.GetComponent<Level.Level>();
        }

        private void InstantiateLevel(LevelStateManager levelStateManager)
        {
            levelStateManager.currentLevelObj = Object.Instantiate(levelStateManager.currentLevelObj, Vector3.zero, Quaternion.identity);
        }
    }
}