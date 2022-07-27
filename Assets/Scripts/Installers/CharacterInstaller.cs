using FixedUpdates;
using Player;
using UnityEngine;
using Updates;

namespace Installers
{
    public sealed class CharacterInstaller : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private PlayerSettingConfig _playerSettingConfig;

        public void InitializeCharacters(FixedGameUpdates fixedGameUpdates, GameUpdates gameUpdates)
        {
            var playerInput = new PlayerInput();
            var player = CreatePlayer(playerInput, _playerRigidbody, _playerSettingConfig, 
                fixedGameUpdates, gameUpdates);
        }
        
        private MainPlayer CreatePlayer(PlayerInput playerInput, Rigidbody2D playerRigidbody, 
            PlayerSettingConfig playerSettingConfig, FixedGameUpdates fixedGameUpdates, GameUpdates gameUpdates)
        {
            var player = new MainPlayer(playerInput, playerRigidbody, playerSettingConfig);
            gameUpdates.AddToUpdateList(player);
            fixedGameUpdates.AddToUpdateList(player);
            
            return player;
        }
    }
}