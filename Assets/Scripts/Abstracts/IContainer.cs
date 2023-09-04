namespace Managers.CardBattleGame
{
    public interface IContainer<T>
    {
        public T GetCard(CardElementType elementType);
    }
}