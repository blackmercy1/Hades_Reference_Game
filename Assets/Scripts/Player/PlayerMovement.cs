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
        private readonly IsometricCharacterRenderer _isometricCharacterRenderer;

        public PlayerMovement(PlayerInput playerInput, Rigidbody2D playerRigidbody,
            PlayerSettingConfig playerSettingConfig, Joystick joyStick,
            IsometricCharacterRenderer isometricCharacterRenderer)
        {
            _playerInput = playerInput;
            _playerRigidbody = playerRigidbody;
            _playerSettingConfig = playerSettingConfig;
            _joyStick = joyStick;
            _isometricCharacterRenderer = isometricCharacterRenderer;
        }

        public void Move(float fixedDeltaTime)
        {
            var movementKeyBoard = Vector2.zero;
            var inputVector = Vector2.ClampMagnitude(_playerInput.PlayerInputDirection, 1f);
#if UNITY_EDITOR
            movementKeyBoard = _playerInput.PlayerInputDirection * _playerSettingConfig.Speed;
#endif
            var movement = _joyStick.JoyStickInputDirection * _playerSettingConfig.Speed;
            
            var newPosition = (Vector2)_playerRigidbody.transform.position + (movement + inputVector) 
                * fixedDeltaTime;
            
            Debug.Log(newPosition);

            _isometricCharacterRenderer.SetDirections(_joyStick.JoyStickInputDirection);
            _playerRigidbody.MovePosition(newPosition);
        }
    }
}