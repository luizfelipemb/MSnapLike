using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventsManager
{
    public static UnityEvent UpdateEnergy = new UnityEvent();
    public static UnityEvent UpdateHands = new UnityEvent();
    public static UnityEvent<int> ChangeTurnTo = new UnityEvent<int>();
    public static UnityEvent<(int playerId, int cardId, int locationId)> CardPlayed = new UnityEvent<(int playerId, int cardId, int locationId)>();
    public static UnityEvent<Board> BoardChanged = new UnityEvent<Board>();
    public static UnityEvent<int> GameEndedWithWinner = new UnityEvent<int>();
}
