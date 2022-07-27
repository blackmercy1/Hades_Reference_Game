using UnityEngine;

namespace Player
{
    public class PlayerMovement
    {
        private readonly Rigidbody2D _playerRigidbody;
        private readonly PlayerInput _playerInput;
        private readonly PlayerSettingConfig _playerSettingConfig;

        public PlayerMovement(PlayerInput playerInput, Rigidbody2D playerRigidbody, PlayerSettingConfig playerSettingConfig)
        {
            _playerInput = playerInput;
            _playerRigidbody = playerRigidbody;
            _playerSettingConfig = playerSettingConfig;
        }

        public void Move(float fixedDeltaTime)
        {
            // _playerRigidbody.MovePosition(_playerRigidbody.position * _playerInput.PlayerInputDirection *10000f* fixedDeltaTime);
            var inputVector = Vector2.ClampMagnitude(_playerInput.PlayerInputDirection, 1f);
            var movement = inputVector * _playerSettingConfig.Speed ;
            var newPosition = (Vector2)_playerRigidbody.transform.position + movement * fixedDeltaTime;

            Debug.Log($"{movement}");
            
            _playerRigidbody.MovePosition(newPosition);
        }
    }
}