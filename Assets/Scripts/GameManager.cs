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
    public static int Player1Id;
    public static int Player2Id;
    private Board board = new Board();
    private int turn = 0;

    private void Awake()
    {
        Player1Id = p1.id;
        Player2Id = p2.id;
    }
    private void Start()
    {
        board = new Board();
        InitializeGame();
        NexTurn();
    }
    private void InitializeGame()
    {
        p1.StartPlayerStuff();
        p2.StartPlayerStuff();
        p1.Draw(3);
        p2.Draw(3);
        UpdateHands?.Invoke();
    }
    private void NexTurn()
    {
        turn++;
        p1.energy = turn;
        p2.energy = turn; 
        p1.Draw();
        p2.Draw();
        p1.endedTurn = false;
        p2.endedTurn = false;
        ChangeTurnTo?.Invoke(turn);
        BoardChanged?.Invoke(board);
        UpdateHands?.Invoke();
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
        bool PlayingAtOwnLocation = playerId == Utils.GetLocationOwner(locationid);
        if (!PlayingAtOwnLocation)
            return;
        Player owner = GetPlayerById(playerId);
        CardLocationTypes cardLocation = owner.LocateCard(cardId);
        int cardCost = owner.GetCardByIdFromHand(cardId).BaseCard.cost;

        bool hasNotEndedTurn = !owner.endedTurn;
        bool cardInHand = cardLocation == CardLocationTypes.Hand;
        bool locationAvailable = board.CheckIfLocationIsAvailable(locationid);
        bool hasEnergyToPlay = owner.energy >= cardCost;

        if (cardInHand && locationAvailable && hasEnergyToPlay && hasNotEndedTurn)
        {
            Debug.Log("CardInHand AND LocationAvailable AND HasEnergyToPlay");
            var removedCard = owner.RemoveCardFromHand(cardId);
            board.PlaceCardInLocation(removedCard, locationid);
            board.UpdateLocationsPoints();
            owner.energy -= cardCost;

            CardPlayed?.Invoke((playerId, cardId, locationid));
            BoardChanged?.Invoke(board);
            UpdateEnergy?.Invoke();
        }
    }

}
