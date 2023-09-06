using System;
using System.Threading.Tasks;
using Managers.CardBattleGame;

namespace Managers
{
    public static class EventManager
    {
        public static Action<BaseCardObject> OnCardAddedToSelectedDeck;
        public static Action<BaseCardObject> OnCardRemovedFromSelectedDeck;
    }
}