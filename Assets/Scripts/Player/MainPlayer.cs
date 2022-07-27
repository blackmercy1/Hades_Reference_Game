using System;
using UnityEngine;
using Updates;

namespace Player
{
    public sealed class MainPlayer : IUpdate, IFixedUpdate
    {
        public event Action<IFixedUpdate> UpdateFixedRemoveRequested;
        public event Action<IUpdate> UpdateRemoveRequested;

        private readonly Rigidbody2D _playerRigidbody;
        private readonly PlayerInput _playerInput;
        private readonly PlayerSettingConfig _playerSettingConfig;

        public MainPlayer(PlayerInput playerInput, Rigidbody2D playerRigidbody, 
            PlayerSettingConfig playerSettingConfig)
        {
            _playerInput = playerInput;
            _playerRigidbody = playerRigidbody;
            _playerSettingConfig = playerSettingConfig;
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
            return new PlayerMovement(_playerInput, _playerRigidbody, _playerSettingConfig);
        }
    }
}