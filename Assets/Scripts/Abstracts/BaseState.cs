using System;

namespace Managers.CardBattleGame
{
    public abstract class BaseState
    {
        public abstract void Start();
        public abstract void Update();
        public abstract void End();
    }
}