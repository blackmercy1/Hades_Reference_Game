using Player;

namespace States.Player
{
    public class DashState : BaseState
    {
        public DashState(MainPlayer mainPlayer, IStationStateSwitcher stateSwitcher) : base(mainPlayer, stateSwitcher)
        {
        }

        public override void Start()
        {
            
        }

        public override void Stop()
        {
            
        }

        public override void Idle()
        {
            throw new System.NotImplementedException();
        }

        public override void Run()
        {
            throw new System.NotImplementedException();
        }

        public override void Dash()
        {
            throw new System.NotImplementedException();
        }

        public override void Attack()
        {
            throw new System.NotImplementedException();
        }
    }
}