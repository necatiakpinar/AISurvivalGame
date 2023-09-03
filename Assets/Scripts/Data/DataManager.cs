using UnityEngine;

namespace Managers.Data
{
    //Right now use this as singleton, later implement addressables.
    public class DataManager : MonoBehaviour
    {
        [Header("Data")] [SerializeField] private CardContainer _cardContainer;
        [SerializeField] private CharacterCardContainer _characterCardContainer;
        [SerializeField] private ItemCardContainer _itemCardContainer;

        public CardContainer CardContainer
        {
            get { return _cardContainer; }
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
    }
}