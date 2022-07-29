using UnityEngine;

namespace Player
{
    public class IsometricCharacterRenderer : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private readonly string[] _idleDirections =
        {
            "Idle_0", "Idle_7", "Idle_6", "Idle_5",
            "Idle_4", "Idle_3", "Idle_2", "Idle_1"
        };
        
        private int _lastDirection;
        
        public void SetDirections(Vector2 direction)
        {
            if (direction.magnitude > .01f)
            {
                var directionArray = _idleDirections;
                _lastDirection = DirectionToIndex(direction, directionArray.Length);
                print(_lastDirection);
                _animator.Play(directionArray[_lastDirection]);
            }
        }

        private int DirectionToIndex(Vector2 direction, int sliceCounts)
        {
            var normDirection = direction.normalized;
            var step = 360f / sliceCounts;
            
            var halfStep = step / 2;
            var angle = Vector2.SignedAngle(Vector2.up, normDirection);

            angle += halfStep;
            if (angle < 0)
            {
                angle += 360;
            }

            var stepCount = angle / step;
            return Mathf.RoundToInt(stepCount);
        }
    }
}