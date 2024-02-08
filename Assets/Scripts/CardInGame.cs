[System.Serializable]
public class CardInGame
{
    public int id;
    public CardBase baseCard;
    public int currentPower;
    public int currentCost;
    public int firstOwnerId;
    public CardEffect cardEffect;

    public static bool operator ==(CardInGame card, int id)
    {
        return (card.id == id);
    }
    public static bool operator !=(CardInGame card, int id)
    {
        return !(card.id==id);
    }
    public CardInGame(CardBase card)
    {
        this.baseCard = card;
        currentPower = baseCard.power;
        currentCost = baseCard.cost;
    }
}
