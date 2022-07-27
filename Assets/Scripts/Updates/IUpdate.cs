using System;

namespace Updates
{
    public interface IUpdate
    {
        event Action<IUpdate> UpdateRemoveRequested;
        void GameUpdate(float deltaTime);
    }
}