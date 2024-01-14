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
    private Board board;
    private int turn = 0;
    private TurnInfo currentTurn;

    private void Start()
    {
        InitializeGame();
    }
    private void InitializeGame()
    {
        p1.StartPlayerStuff();
        p2.StartPlayerStuff();
        p1.DrawInitialHand();
        p2.DrawInitialHand();
        UpdateHands?.Invoke();
        NexTurn();
    }
    private void NexTurn()
    {
        turn++;
        p1.energy = turn;
        p2.energy = turn;
        ChangeTurnTo?.Invoke(turn);
        BoardChanged?.Invoke(board);
        currentTurn = new TurnInfo();
    }
    public void PlayerEndedTurn(int playerEndingTurn)
    {
        if (playerEndingTurn == p1.id)
        {
            currentTurn.p1Ready = true;
        }
        else 
        {
            currentTurn.p2Ready = true;
        }

        if(currentTurn.p1Ready && currentTurn.p2Ready)
        {
            NexTurn();
        }
    }
    public Player GetPlayerById(int id)
    {
        if(p1.id == id)
            return p1;
        return p2;
    }
    public void TryPlayCardBy(int playerId,int cardId,int locationid)
    {
        Debug.Log($"TryPlayCardBy player:{playerId}, cardid:{cardId}, locationid:{locationid}");
        Player owner = GetPlayerById(playerId);
        CardLocationTypes cardLocation = owner.LocateCard(cardId);
        int cardCost = owner.GetCardByIdFromHand(cardId).BaseCard.cost;

        bool cardInHand = cardLocation == CardLocationTypes.Hand;
        bool locationAvailable = board.CheckIfLocationIsAvailable(playerId, locationid);
        bool hasEnergyToPlay = owner.energy >= cardCost;

        if (cardInHand && locationAvailable && hasEnergyToPlay)
        {
            Debug.Log("CardInHand AND LocationAvailable AND HasEnergyToPlay");
            var removedCard = owner.RemoveCardFromHand(cardId);
            board.PlaceCardInLocation(playerId,removedCard, locationid);
            owner.energy -= cardCost;

            CardPlayed?.Invoke((playerId,cardId,locationid));
            BoardChanged?.Invoke(board);
            UpdateEnergy?.Invoke();
        }
    }

}
