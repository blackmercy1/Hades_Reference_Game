using UnityEngine;

namespace Installers
{
    public sealed class UIInstaller : MonoBehaviour
    {
        public void Init()
        {
            DestroySelf();
        }

        private void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}