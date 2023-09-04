using Managers.CardBattleGame;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers.Data
{
    //Right now use this as singleton, later implement addressables.
    public class DataManager : MonoBehaviour
    {
        [FormerlySerializedAs("_cardContainer")] [Header("Data")] [SerializeField]
        private CardObjectContainer _cardObjectContainer;

        [SerializeField] private CharacterCardContainer _characterCardContainer;
        [SerializeField] private ItemCardContainer _itemCardContainer;

        public CardObjectContainer CardObjectContainer
        {
            get { return _cardObjectContainer; }
            private set { }
        }

        public CharacterCardContainer CharacterCardContainer
        {
            get { return _characterCardContainer; }
            private set { }
        }

        public ItemCardContainer ItemCardContainer
        {
            get { return ItemCardContainer; }
            private set { }
        }

        public static DataManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }

        public BaseCard GetCard(CardType cardType, CardElementType elementType)
        {
            switch (cardType)
            {
                case CardType.Character:
                    CharacterCardContainer.GetCard(elementType);
                    break;
                case CardType.Item:
                    ItemCardContainer.GetCard(elementType);
                    break;
            }

            return null;
        }

        public T GetCard<T>(CardType cardType, CardElementType elementType) where T : BaseCard
        {
            if (!typeof(T).IsSubclassOf(typeof(BaseCard)))
                return null;

            switch (cardType)
            {
                case CardType.Character:
                    return (T)(object)CharacterCardContainer.GetCard(elementType);
                case CardType.Item:
                    return (T)(object)ItemCardContainer.GetCard(elementType);
            }

            return null;
        }
    }
}