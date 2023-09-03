using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Managers.CardBattleGame;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        private Dictionary<CardType, Type> _cardsByType;

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

            var cardTypes = Assembly.GetAssembly(typeof(BaseCardObject))
                .GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BaseCardObject)));

            //Dictionary for finding these by name later (could be an enum/id instead of string)
            _cardsByType = new Dictionary<CardType, Type>();

            //Get the names and put them into the dictionary
            foreach (var type in cardTypes)
            {
                var tempEffect = Activator.CreateInstance(type) as BaseCardObject;
                _cardsByType.Add(tempEffect.CardType, type);
            }
        }

        public BaseCardObject GetCardObject(CardType cardType)
        {
            if (_cardsByType.ContainsKey(cardType))
            {
                Type type = _cardsByType[cardType];
                var cardPF = Activator.CreateInstance(type) as BaseCardObject;
                return cardPF;
            }

            return null;
        }
    }
}