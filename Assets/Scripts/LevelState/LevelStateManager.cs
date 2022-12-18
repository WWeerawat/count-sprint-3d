using Cinemachine;
using UnityEngine;

namespace LevelState
{
    public class LevelStateManager : MonoBehaviour
    {
        private LevelBaseState currentState;
        public readonly InitiateLevelState initiateLevelState = new InitiateLevelState();
        public readonly InitiatePlayerState initiatePlayerState = new InitiatePlayerState();
        public readonly PlayLevelState playLevelState = new PlayLevelState();
        public readonly BattleState battleState = new BattleState();
        public readonly ResultLevelState resultLevelState = new ResultLevelState();

        [Header("Utils")]
        public GameObject playerArmyPrefab;
        public CinemachineVirtualCamera cinemachineVirtualCamera;

        [Header("Levels")]
        public GameObject[] levels;
        public GameObject currentLevelObj;
        public Level.Level currentLevel;
        public int currentCount;
        public GameObject spawnedPlayerArmy;
        
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
            GameManager.Instance.mainMenuUI.SetActive(false);
            SwitchState(initiatePlayerState);
        }

        public void DestroyPlayer()
        {
            Destroy(spawnedPlayerArmy);
        }

        public GameObject GetSpawnPlayer()
        {
            return spawnedPlayerArmy;
        }
    }
}