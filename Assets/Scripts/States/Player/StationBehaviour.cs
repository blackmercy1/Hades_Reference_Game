using System.Collections.Generic;
using System.Linq;
using Player;

namespace States.Player
{
    public sealed class StationBehaviour : IStationStateSwitcher
    { 
        private readonly MainPlayer _mainPlayer;

        private BaseState _currentState;
        private readonly List<BaseState> _allStates;

        public StationBehaviour(MainPlayer mainPlayer)
        {
            _mainPlayer = mainPlayer;
            
            _allStates = new List<BaseState>()
            {
                new IdleState(_mainPlayer, this),
                new AttackState(_mainPlayer, this),
                new DashState(_mainPlayer, this),
                new RunState(_mainPlayer, this)
            };

            _currentState = _allStates[0];
        }

        public void Run()
        {
            _currentState.Run();
        }

        public void Idle()
        {
            _currentState.Idle();
        }

        public void Jump()
        {
            _currentState.Dash();
        }

        public void Attack()
        {
            _currentState.Attack();
        }

        public void SwitchState<T>() where T : BaseState
        {
            var state = _allStates.FirstOrDefault(s => s is T);
            _currentState.Stop();
            state.Start();
            _currentState = state;
        }
    }
}