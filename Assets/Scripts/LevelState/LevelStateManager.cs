using System;
using UnityEngine;

namespace LevelState
{
    public class LevelStateManager : MonoBehaviour
    {
        private LevelBaseState currentState;
        private InitiateLevelState initiateLevelState = new InitiateLevelState();

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
    }
}