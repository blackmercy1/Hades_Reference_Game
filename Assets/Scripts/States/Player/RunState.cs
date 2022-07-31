using Player;

namespace States.Player
{
    public class RunState : BaseState
    {
        public RunState(MainPlayer mainPlayer, IStationStateSwitcher stateSwitcher) : base(mainPlayer, stateSwitcher)
        {
        }

        public override void Start()
        {
            
        }

        public override void Stop()
        {
            throw new System.NotImplementedException();
        }

        public override void Idle()
        {
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