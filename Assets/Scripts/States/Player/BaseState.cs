using Player;

namespace States.Player
{
    public abstract class BaseState
    {
        protected readonly MainPlayer _mainPlayer;
        protected readonly IStationStateSwitcher _stateSwitcher;

        protected BaseState(MainPlayer mainPlayer, IStationStateSwitcher stateSwitcher)
        {
            _mainPlayer = mainPlayer;
            _stateSwitcher = stateSwitcher;
        }

        public abstract void Start();
        public abstract void Stop();
        public abstract void Idle();
        public abstract void Run();
        public abstract void Dash();
        public abstract void Attack();
    }
}