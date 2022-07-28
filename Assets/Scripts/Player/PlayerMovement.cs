using UI.JoyStick;
using UnityEngine;

namespace Player
{
    public class PlayerMovement
    {
        private readonly Rigidbody2D _playerRigidbody;
        private readonly PlayerInput _playerInput;
        private readonly PlayerSettingConfig _playerSettingConfig;
        private readonly Joystick _joyStick;

        public PlayerMovement(PlayerInput playerInput, Rigidbody2D playerRigidbody, 
            PlayerSettingConfig playerSettingConfig, Joystick joyStick)
        {
            _playerInput = playerInput;
            _playerRigidbody = playerRigidbody;
            _playerSettingConfig = playerSettingConfig;
            _joyStick = joyStick;
        }

        public void Move(float fixedDeltaTime)
        {
            var inputVector = Vector2.ClampMagnitude(_playerInput.PlayerInputDirection, 1f);
            var movement = _joyStick.JoyStickInputDirection * _playerSettingConfig.Speed;
            var newPosition = (Vector2)_playerRigidbody.transform.position + movement * fixedDeltaTime;

            _playerRigidbody.MovePosition(newPosition);
        }
    }
}