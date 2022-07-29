using FixedUpdates;
using Player;
using UI.JoyStick;
using UnityEngine;
using Updates;

namespace Installers
{
    public sealed class CharacterInstaller : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private PlayerSettingConfig _playerSettingConfig;

        [SerializeField] private IsometricCharacterRenderer _iso;

        private Joystick _joyStick;
        
        public void InitializeCharacters(FixedGameUpdates fixedGameUpdates, GameUpdates gameUpdates, Joystick joyStick)
        {
            var playerInput = new PlayerInput();
            _joyStick = joyStick;
            var player = CreatePlayer(playerInput, _playerRigidbody, _playerSettingConfig, 
                fixedGameUpdates, gameUpdates);
        }
        
        private MainPlayer CreatePlayer(PlayerInput playerInput, Rigidbody2D playerRigidbody, 
            PlayerSettingConfig playerSettingConfig, FixedGameUpdates fixedGameUpdates, GameUpdates gameUpdates)
        {
            var player = new MainPlayer(playerInput, playerRigidbody, playerSettingConfig, _joyStick, _iso);
            gameUpdates.AddToUpdateList(player);
            fixedGameUpdates.AddToUpdateList(player);
            
            return player;
        }
    }
}