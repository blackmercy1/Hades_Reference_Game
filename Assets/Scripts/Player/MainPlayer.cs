using System;
using Interfaces;
using UI.JoyStick;
using UnityEngine;
using Updates;

namespace Player
{
    public sealed class MainPlayer : IUpdate, IFixedUpdate, IClean
    {
        public event Action<IFixedUpdate> UpdateFixedRemoveRequested;
        public event Action<IUpdate> UpdateRemoveRequested;

        private readonly Rigidbody2D _playerRigidbody;
        private readonly Joystick _joyStick;
        private readonly PlayerInput _playerInput;
        private readonly PlayerSettingConfig _playerSettingConfig;

        private readonly IsometricCharacterRenderer _iso;

        public PlayerMovement PlayerMovement;

        public MainPlayer(PlayerInput playerInput, Rigidbody2D playerRigidbody,
            PlayerSettingConfig playerSettingConfig, Joystick joystick,
            IsometricCharacterRenderer isometricCharacterRenderer)
        {
            _playerInput = playerInput;
            _playerRigidbody = playerRigidbody;
            _playerSettingConfig = playerSettingConfig;
            _joyStick = joystick;
            _iso = isometricCharacterRenderer;
        }

        public void GameUpdate(float deltaTime)
        {
            _playerInput.GetInput();
        }

        public void FixedGameUpdate(float fixedDeltaTime)
        {
            PlayerMovement = GetMovement();
            PlayerMovement.Move(fixedDeltaTime);
        }

        private PlayerMovement GetMovement()
        {
            return new PlayerMovement(_playerInput, _playerRigidbody, _playerSettingConfig, _joyStick, _iso);
        }

        public void Clean()
        {
            throw new NotImplementedException();
        }
    }
}