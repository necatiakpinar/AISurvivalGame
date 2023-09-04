using System;
using Managers.CardBattleGame;
using Managers.CardBattleGame.Cards;
using Managers.Data;
using Managers.Misc;
using UnityEngine;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Managers
{
    public class BattleUIWindow : MonoBehaviour
    {
        [SerializeField] private Transform _cardParent;

        private DataManager _dataManager;

        private void Awake()
        {
            _dataManager = DataManager.Instance;
        }

        private void Start()
        {
            #region Test

            //Fetch data
            CharacterCard characterCardData1 = _dataManager.GetCard<CharacterCard>(CardType.Character, CardElementType.ACard);
            CharacterCard characterCardData2 = _dataManager.GetCard<CharacterCard>(CardType.Character, CardElementType.BCard);
            CharacterCard characterCardData3 = _dataManager.GetCard<CharacterCard>(CardType.Character, CardElementType.CCard);

            //Add those cards the deck 
            Player.CardDeck.AddCard(characterCardData1);
            Player.CardDeck.AddCard(characterCardData2);
            Player.CardDeck.AddCard(characterCardData3);


            CreatePlayerBattleDeck();

            #endregion
        }

        public T CreateCard<T>(CardType cardType) where T : BaseCardObject
        {
            if (!typeof(T).IsSubclassOf(typeof(BaseCardObject)))
                return null;

            switch (cardType)
            {
                case CardType.Character:
                    return (T)(object)Instantiate(_dataManager.CardObjectContainer.CharacterCardObject, _cardParent);
                case CardType.Item:
                    return (T)(object)Instantiate(_dataManager.CardObjectContainer.ItemCardPF, _cardParent);
            }

            return null;
        }

        public void CreatePlayerBattleDeck()
        {
            if (Player.CardDeck.Cards.Count == 0)
                return;

            BaseCard baseCard;
            for (int i = 0; i < Player.CardDeck.Cards.Count; i++)
            {
                baseCard = Player.CardDeck.Cards[i];

                //Create card UI
                CharacterCardObject characterCardObject = CreateCard<CharacterCardObject>(CardType.Character);
                characterCardObject.Init(baseCard);
            }
        }
    }
}