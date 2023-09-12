using Managers.CardBattleGame;
using Managers.Misc;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers.Data
{
    //Right now use this as singleton, later implement addressables.
    public class DataManager : MonoBehaviour
    {
        [Header("Data")] [SerializeField] private CardObjectContainer _cardObjectContainer;

        [SerializeField] private CharacterCardContainer _characterCardContainer;
        [SerializeField] private ItemCardContainer _itemCardContainer;

        [Header("Mono Data")] [SerializeField] private CardActorMonoContainer _cardActorMonoContainer;

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
            get { return _itemCardContainer; }
            private set { }
        }

        public CardActorMonoContainer CardActorMonoContainer => _cardActorMonoContainer;
        
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

        public T CreateCard<T>(CardType cardType, Transform cardParent) where T : BaseCardObject
        {
            if (!typeof(T).IsSubclassOf(typeof(BaseCardObject)))
                return null;

            switch (cardType)
            {
                case CardType.Character:
                    return (T)(object)Instantiate(_cardObjectContainer.CharacterCardObject, cardParent);
                case CardType.Item:
                    return (T)(object)Instantiate(_cardObjectContainer.ItemCardPF, cardParent);
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