using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeckManager
{
    [SerializeField] private Deck cardsToBeAssigned;
    public List<CardInGame> DeckInGame = new List<CardInGame>();
    private EffectsFactory effectsFactory = new EffectsFactory();
    public void InstantiateDeck()
    {
        DeckInGame = new List<CardInGame>();
        foreach (CardBase card in cardsToBeAssigned.cards)
        {
            var cardInGame = new CardInGame(card);
            cardInGame.id = Utils.CardIdGetter();
            cardInGame.cardEffect = effectsFactory.CreateEffect(
                card.effectTrigger,
                card.effectValidator,
                card.effectConsequence,
                card.effectAmount);
            DeckInGame.Add(cardInGame);
        }
        Utils.ShuffleList(DeckInGame);
    }
    public List<CardInGame> Draw(int howManyCards)
    {
        if (DeckInGame.Count < howManyCards)
            howManyCards = DeckInGame.Count;
        List<CardInGame> cardsToDraw = new List<CardInGame>();
        for (int i = howManyCards-1; i>=0; i--)
        {
            cardsToDraw.Add(DeckInGame[i]);
            DeckInGame.RemoveAt(i);
        }
        return cardsToDraw;
    }
    public bool ContainsCard(int id)
    {
        return Utils.ContainsById(id, DeckInGame);
    }
    public void AssignPlayerId(int id)
    {
        foreach(var card in DeckInGame)
        {
             card.firstOwnerId = id;
        }
    }
}
