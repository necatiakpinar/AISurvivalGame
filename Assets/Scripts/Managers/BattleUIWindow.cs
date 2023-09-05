using System;
using Managers.CardBattleGame;
using Managers.CardBattleGame.Cards;
using Managers.Data;
using Managers.Misc;
using UnityEngine;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

namespace Managers
{
    public class BattleUIWindow : MonoBehaviour
    {
        [SerializeField] private CardDeckUIController _cardDeckController;
        [SerializeField] private SelectedDeckUIController _selectedCardDeckController;

        private DataManager _dataManager;

        private void Start()
        {
            _dataManager = DataManager.Instance;;
            #region Test

            //Fetch data
            CharacterCard characterCardData1 = _dataManager.GetCard<CharacterCard>(CardType.Character, CardElementType.ACard);
            CharacterCard characterCardData2 = _dataManager.GetCard<CharacterCard>(CardType.Character, CardElementType.BCard);
            CharacterCard characterCardData3 = _dataManager.GetCard<CharacterCard>(CardType.Character, CardElementType.CCard);

            //Add those cards the deck 
            Player.CardDeck.AddCard(characterCardData1);
            Player.CardDeck.AddCard(characterCardData2);
            Player.CardDeck.AddCard(characterCardData3);

            _cardDeckController.Init(_selectedCardDeckController);

            #endregion
        }
    }
}