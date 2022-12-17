namespace LevelState
{
    public abstract class LevelBaseState
    {
        public virtual void EnterState(LevelStateManager levelStateManager)
        {
        }
        public virtual void UpdateState(LevelStateManager levelStateManager)
        {
        }
    }
}