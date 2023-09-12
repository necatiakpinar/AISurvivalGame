using System;
using Managers.CardBattleGame;
using Managers.CardBattleGame.Cards;
using Managers.Data;
using Managers.Misc;
using UnityEngine;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Managers
{
    public class BattleUIWindow : MonoBehaviour
    {
        [SerializeField] private CardDeckUIController _cardDeckController;
        [SerializeField] private SelectedDeckUIController _selectedCardDeckController;
        [SerializeField] private Button _enterBattleButton;

        private DataManager _dataManager;

        private void OnEnable()
        {
            _enterBattleButton.onClick.AddListener(OnEnterBattleButtonClicked);
        }

        private void OnDestroy()
        {
            _enterBattleButton.onClick.RemoveListener(OnEnterBattleButtonClicked);
        }

        private void Start()
        {
            _dataManager = DataManager.Instance;
            
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
            _selectedCardDeckController.Init(_cardDeckController);

            #endregion
        }

        private void OnEnterBattleButtonClicked()
        {
            if (_selectedCardDeckController.SelectedCards.Count > 0)
                SceneManager.LoadScene((int)Scenes.BattleGameplay);
            
            Debug.LogError("You don't have any selected card to enter the GAME!");
        }
    }
}