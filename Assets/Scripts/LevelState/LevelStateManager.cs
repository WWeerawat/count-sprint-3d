using System;
using Cinemachine;
using UnityEngine;

namespace LevelState
{
    public class LevelStateManager : MonoBehaviour
    {
        private LevelBaseState currentState;
        public InitiateLevelState initiateLevelState = new InitiateLevelState();
        public InitiatePlayerState initiatePlayerState = new InitiatePlayerState();
        public PlayLevelState playLevelState = new PlayLevelState();
        public ResultLevelState resultLevelState = new ResultLevelState();

        [Header("Utils")]
        public GameObject player;

        [Header("Levels")]
        public GameObject[] levels;
        public GameObject currentLevelObj;
        public Level.Level currentLevel;
        public int currentCount;

        public GameObject spawnedPlayer;

        public CinemachineVirtualCamera cinemachineVirtualCamera;

        private void Start()
        {
            currentState = initiateLevelState;
            currentState.EnterState(this);
        }
        private void Update()
        {
            currentState.UpdateState(this);
        }

        public void SwitchState(LevelBaseState state)
        {
            currentState = state;
            currentState.EnterState(this);
        }

        public void StartLevel()
        {
            SwitchState(initiatePlayerState);
            GameManager.Instance.mainMenuUI.SetActive(false);
        }

        // public void SetToStartPosition()
        // {
        //     Vector3 startPos = currentLevel.startLine.transform.position;
        //     player.transform.position = new Vector3(startPos.x, startPos.y + 0.5f, startPos.z);
        // }
        public void ResetLevel()
        {
            Debug.Log("YOU DIED");
            DestroyPlayer();
            SwitchState(initiatePlayerState);
        }

        private void InstantiatePlayer()
        {
            Vector3 startPos = currentLevel.startLine.transform.position;
            spawnedPlayer = Instantiate(player, new Vector3(startPos.x, startPos.y + 0.5f, startPos.z), Quaternion.identity);
            cinemachineVirtualCamera.Follow = spawnedPlayer.transform;
        }
        public void DestroyPlayer()
        {
            Destroy(spawnedPlayer);
        }

        public GameObject GetSpawnPlayer()
        {
            return spawnedPlayer;
        }
    }
}