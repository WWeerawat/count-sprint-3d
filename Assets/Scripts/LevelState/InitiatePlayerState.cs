using System.Collections.Generic;
using Player;
using UnityEngine;

namespace LevelState
{
    public class InitiatePlayerState : LevelBaseState
    {
        public override void EnterState(LevelStateManager levelStateManager)
        {
            Debug.Log("Init Player");
            InstantiatePlayer(levelStateManager);
        }

        public override void UpdateState(LevelStateManager levelStateManager)
        {
            if (levelStateManager.spawnedPlayer.GetComponent<Army>().units.Count == 0)
                return;
            levelStateManager.SwitchState(levelStateManager.playLevelState);
        }
        
        private void InstantiatePlayer(LevelStateManager levelStateManager)
        {
            Vector3 startPos = levelStateManager.currentLevel.startLine.transform.position;
            levelStateManager.spawnedPlayer = Object.Instantiate(levelStateManager.player, new Vector3(startPos.x, startPos.y + 0.5f, startPos.z), Quaternion.identity);
            levelStateManager.cinemachineVirtualCamera.Follow = levelStateManager.spawnedPlayer.transform;

            levelStateManager.spawnedPlayer.GetComponent<Army>().Spawn(levelStateManager.currentCount);
        }
    }
}