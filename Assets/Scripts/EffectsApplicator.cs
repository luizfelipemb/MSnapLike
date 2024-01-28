using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsApplicator
{
    private Board board;
    public EffectsApplicator(Board board)
    { 
        this.board = board;
        SubscribeToEvents();
    }
    private void SubscribeToEvents()
    {
        EventsManager.IncreasePowerOfCard.AddListener(IncreasePower);
    }
    private void IncreasePower((int cardIdAffected, int amount) eventData)
    {
        Debug.Log($"Power Increased of card:{eventData.cardIdAffected} by {eventData.amount}");
        var card = board.GetCardInGame(eventData.cardIdAffected);
        if (card != null)
            board.GetCardInGame(eventData.cardIdAffected).baseCard.power += eventData.amount;
        else
            Debug.LogWarning("Tried to IncreasePower of card not in board!");
    }
}
