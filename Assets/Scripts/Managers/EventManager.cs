using System;
using System.Threading.Tasks;

namespace Managers
{
    public static class EventManager
    {
        public static Func<PlayerActor> GetActivePlayer;
        public static Func<GridManager> GetGridManager;

        public static Func<Task<AIResponse>> SendCommand;
    }
}