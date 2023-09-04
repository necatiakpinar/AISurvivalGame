using Managers.CardBattleGame;

namespace Managers.Data
{
    /// <summary>
    /// This class is represents all data of the player
    /// </summary>
    public static class Player
    {
        private static CardDeck _cardDeck = new CardDeck();
        private static bool _isInitialized = false;

        public static CardDeck CardDeck
        {
            get { return _cardDeck; }
            private set { }
        }

        public static void InitGameData()
        {
            if (!_isInitialized)
            {
                _cardDeck = new CardDeck();
            }
        }
    }
}