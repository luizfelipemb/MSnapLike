using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static UnityEvent UpdateEnergy = new UnityEvent();
    public static UnityEvent UpdateHands = new UnityEvent();
    public static UnityEvent<int> ChangeTurnTo = new UnityEvent<int>();
    public static UnityEvent<(int playerId, int cardId, int locationId)> CardPlayed = new UnityEvent<(int playerId, int cardId, int locationId)>();
    public static UnityEvent<Board> BoardChanged = new UnityEvent<Board>();
    [SerializeField] private Player p1;
    [SerializeField] private Player p2;
    private Board board = new Board();
    private int turn = 0;

    private void Start()
    {
        InitializeGame();
        NexTurn();
    }
    private void InitializeGame()
    {
        p1.StartPlayerStuff();
        p2.StartPlayerStuff();
        p1.DrawInitialHand();
        p2.DrawInitialHand();
        UpdateHands?.Invoke();
    }
    private void NexTurn()
    {
        turn++;
        p1.energy = turn;
        p2.energy = turn;
        ChangeTurnTo?.Invoke(turn);
        BoardChanged?.Invoke(board);
        p1.endedTurn = false;
        p2.endedTurn = false;
    }
    public void PlayerEndedTurn(int playerEndingTurn)
    {
        GetPlayerById(playerEndingTurn).endedTurn = true;

        if (p1.endedTurn && p2.endedTurn)
        {
            NexTurn();
        }
    }
    public Player GetPlayerById(int id)
    {
        if (p1.id == id)
            return p1;
        return p2;
    }
    public void TryPlayCardBy(int playerId, int cardId, int locationid)
    {
        Debug.Log($"TryPlayCardBy player:{playerId}, cardid:{cardId}, locationid:{locationid}");
        Player owner = GetPlayerById(playerId);
        CardLocationTypes cardLocation = owner.LocateCard(cardId);
        int cardCost = owner.GetCardByIdFromHand(cardId).BaseCard.cost;

        bool hasNotEndedTurn = !owner.endedTurn;
        bool cardInHand = cardLocation == CardLocationTypes.Hand;
        bool locationAvailable = board.CheckIfLocationIsAvailable(playerId, locationid);
        bool hasEnergyToPlay = owner.energy >= cardCost;

        if (cardInHand && locationAvailable && hasEnergyToPlay && hasNotEndedTurn)
        {
            Debug.Log("CardInHand AND LocationAvailable AND HasEnergyToPlay");
            var removedCard = owner.RemoveCardFromHand(cardId);
            board.PlaceCardInLocation(playerId, removedCard, locationid);
            owner.energy -= cardCost;

            CardPlayed?.Invoke((playerId, cardId, locationid));
            BoardChanged?.Invoke(board);
            UpdateEnergy?.Invoke();
        }
    }

}
