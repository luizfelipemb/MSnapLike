using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectsApplicator
{
    private Board board;
    public static UnityEvent<int> CardRevealed = new UnityEvent<int>();
    public static UnityEvent<(int cardIdAffected, int amount)> IncreasePowerOfCard = new UnityEvent<(int cardIdAffected, int amount)>();
    public EffectsApplicator(Board board)
    { 
        this.board = board;
        SubscribeToEvents();
    }
    private void SubscribeToEvents()
    {
        IncreasePowerOfCard.AddListener(IncreasePower);
    }
    private void IncreasePower((int cardIdAffected, int amount) eventData)
    {
        Debug.Log($"Power Increased of card:{eventData.cardIdAffected} by {eventData.amount}");
        var card = board.GetCardInGame(eventData.cardIdAffected);
        if (card != null)
            board.GetCardInGame(eventData.cardIdAffected).currentPower += eventData.amount;
        else
            Debug.LogWarning("Tried to IncreasePower of card not in board!");
    }
}
