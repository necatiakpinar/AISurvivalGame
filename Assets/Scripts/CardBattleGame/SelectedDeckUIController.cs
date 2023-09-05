using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.CardBattleGame
{
    public class SelectedDeckUIController : MonoBehaviour
    {
        [SerializeField] private Transform _deckContainer;
        [SerializeField] private Button _selectButton;

        private List<BaseCardObject> _selectedCards;
        
        public void AddSelectedCardsToDeck(List<BaseCardObject> selectedCards)
        {
            for (int i = 0; i < selectedCards.Count; i++)
            {
                BaseCardObject cardObject = selectedCards[i];
                cardObject.transform.parent = _deckContainer;
                cardObject.transform.position = Vector3.zero;

            }
        }
        
    }
}