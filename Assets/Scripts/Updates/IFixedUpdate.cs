using System;

namespace Updates
{
    public interface IFixedUpdate
    {
        event Action<IFixedUpdate> UpdateFixedRemoveRequested;
        void FixedGameUpdate(float fixedDeltaTime);
    }
}