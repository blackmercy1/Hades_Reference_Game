using System;
using UI.JoyStick;
using UnityEngine;
using Updates;

namespace Player
{
    public sealed class MainPlayer : IUpdate, IFixedUpdate
    {
        public event Action<IFixedUpdate> UpdateFixedRemoveRequested;
        public event Action<IUpdate> UpdateRemoveRequested;

        private readonly Rigidbody2D _playerRigidbody;
        private readonly Joystick _joyStick;
        private readonly PlayerInput _playerInput;
        private readonly PlayerSettingConfig _playerSettingConfig;

        public MainPlayer(PlayerInput playerInput, Rigidbody2D playerRigidbody, 
            PlayerSettingConfig playerSettingConfig, Joystick joystick)
        {
            _playerInput = playerInput;
            _playerRigidbody = playerRigidbody;
            _playerSettingConfig = playerSettingConfig;
            _joyStick = joystick;
        }

        public void GameUpdate(float deltaTime)
        {
            _playerInput.GetInput();
        }

        public void FixedGameUpdate(float fixedDeltaTime)
        {
            var movement = GetMovement();
            movement.Move(fixedDeltaTime);
        }

        private PlayerMovement GetMovement()
        {
            return new PlayerMovement(_playerInput, _playerRigidbody, _playerSettingConfig, _joyStick);
        }
    }
}