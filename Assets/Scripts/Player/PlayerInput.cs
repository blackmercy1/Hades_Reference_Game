using UnityEngine;

namespace Player
{
    public sealed class PlayerInput 
    {
        public Vector2 PlayerInputDirection => _playerInputDirection;

        private Vector2 _playerInputDirection;

        private const string VERTICAL = "Vertical";
        private const string HORIZONTAL = "Horizontal";
        
        public void GetInput()
        {
            _playerInputDirection = new Vector2(Input.GetAxis(HORIZONTAL), Input.GetAxisRaw(VERTICAL));
        }
    }
}