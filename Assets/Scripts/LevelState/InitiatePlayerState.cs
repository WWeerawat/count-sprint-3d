using Player;
using UnityEngine;

namespace LevelState
{
    public class InitiatePlayerState : LevelBaseState
    {
        public override void EnterState(LevelStateManager levelStateManager)
        {
            InstantiatePlayer(levelStateManager);
        }

        public override void UpdateState(LevelStateManager levelStateManager)
        {
            if (levelStateManager.spawnedPlayerArmy.GetComponent<Army>().units.Count == 0)
                return;
            levelStateManager.SwitchState(levelStateManager.playLevelState);
        }

        private void InstantiatePlayer(LevelStateManager levelStateManager)
        {
            Vector3 startPos = levelStateManager.currentLevel.startLine.transform.position;
            levelStateManager.spawnedPlayerArmy = Object.Instantiate(levelStateManager.playerArmyPrefab, new Vector3(startPos.x, startPos.y + 0.5f, startPos.z), Quaternion.identity);
            levelStateManager.cinemachineVirtualCamera.Follow = levelStateManager.spawnedPlayerArmy.transform;

            levelStateManager.spawnedPlayerArmy.GetComponent<Army>().Spawn(levelStateManager.currentCount);
        }
    }
}