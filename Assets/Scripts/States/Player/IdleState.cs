using Player;

namespace States.Player
{
    public class IdleState : BaseState
    {
        public IdleState(MainPlayer mainPlayer, IStationStateSwitcher stateSwitcher) : base(mainPlayer, stateSwitcher)
        {
        }

        public override void Start()
        {
            _mainPlayer.PlayerMovement.PlayerMoved += Run;
        }

        public override void Stop()
        {
            _mainPlayer.PlayerMovement.PlayerMoved -= Run;
        }

        public override void Idle()
        {
        }

        public override void Run()
        {
            _stateSwitcher.SwitchState<RunState>();
        }

        public override void Dash()
        {
        }

        public override void Attack()
        {
        }
    }
}