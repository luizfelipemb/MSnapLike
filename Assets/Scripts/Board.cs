using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

[System.Serializable]
public class Board
{
    public LocationConjuction[] locations { get; private set; } = new LocationConjuction[3];
    public int GameWinnerId { get; private set; } = GameManager.NullId;
    private Queue<(CardInGame card, int locationId)> placeCardsQueue;
    public Board()
    {
        placeCardsQueue = new Queue<(CardInGame card, int locationId)>();
        for (int i = 0; i < 3; i++)
        {
            locations[i] = new LocationConjuction();
        }
    }
    public bool CheckIfLocationIsAvailable(int locationId)
    {
        return GetLocationTile(locationId).HasSpace();
    }
    public void UpdateLocationsPoints()
    {
        foreach (LocationConjuction location in locations)
        {
            location.UpdatePoints();
            location.CalculateWinner();
        }
    }
    public void PrePlaceCardInLocation(CardInGame card, int locationId)
    {
        placeCardsQueue.Enqueue((card, locationId));
    }
    public void TurnPrePlacedCards()
    {
        foreach ((CardInGame card, int locationId) in placeCardsQueue)
        {
            Console.WriteLine($"Card: {card}, Location ID: {locationId}");
            GetLocationTile(locationId).PlaceCard(card);
            EffectsApplicator.CardRevealed?.Invoke(card.id);
        }
        placeCardsQueue.Clear();
    }
    public int GetGameWinnerId()
    {
        (int p1wins, int p2wins) = (0, 0);
        foreach (LocationConjuction location in locations)
        {
            int locationWinnerId = location.CalculateWinner();
            if (locationWinnerId == GameManager.Player1Id)
            {
                p1wins++;
            }
            else if(locationWinnerId == GameManager.Player2Id)
            {
                p2wins++;
            }
        }
        if (p1wins > p2wins)
            return GameManager.Player1Id;
        else if(p2wins > p1wins)
            return GameManager.Player2Id;

        //both have same wins, then count by points
        int comparisonPoints = 0;
        foreach (LocationConjuction location in locations)
        {
            comparisonPoints += location.P1PointsMinusP2Points();
        }
        if (comparisonPoints > 0)
            return GameManager.Player1Id;
        else if(comparisonPoints < 0)
            return GameManager.Player2Id;

        //both have same points then its a draw
        return GameManager.NullId;
    }
    public LocationTile GetLocationTile(int locationId)
    {
        int playerId = Utils.GetLocationOwner(locationId);
        if (playerId == GameManager.Player1Id)
        {
            return locations[locationId].p1Side;
        }
        return locations[locationId - 3].p2Side;
    }
    public CardInGame GetCardInGame(int id)
    {
        foreach (LocationConjuction location in locations)
        {
            CardInGame card = location.p1Side.GetCard(id) ?? location.p2Side.GetCard(id);
            if (card != null)
            {
                return card;
            }
        }
        return null;
    }
}
