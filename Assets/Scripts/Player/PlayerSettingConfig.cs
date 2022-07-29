using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Configs/PlayerConfig")]
    public sealed class PlayerSettingConfig : ScriptableObject
    {
        public float Speed = .1f;
    }
}