using FixedUpdates;
using UnityEngine;
using Updates;

namespace Installers
{
    public sealed class GameInstaller : MonoBehaviour
    {
        [Header("Prefabs to spawn")] 
        [SerializeField] private GameUpdates _gameUpdates;
        [SerializeField] private FixedGameUpdates _fixedGameUpdates;

        [Header("Installers")] 
        [SerializeField] private UIInstaller _uiInstaller = null;
        [SerializeField] private EnvironmentInstaller _environmentInstaller = null;
        [SerializeField] private CharacterInstaller _characterInstaller;
        
        private void Start() => InstallGame();

        private void InstallGame()
        {
            _characterInstaller.InitializeCharacters(_fixedGameUpdates, _gameUpdates);
        }
    }
}