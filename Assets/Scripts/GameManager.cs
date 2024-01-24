using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player p1;
    [SerializeField] private Player p2;
    public static int Player1Id, Player2Id;
    public static int NullId = -1;
    private Board board = new Board();
    private int turn = 0;
    private const int MaxTurns = 6;

    private void Awake()
    {
        Player1Id = p1.id;
        Player2Id = p2.id;
    }
    private void Start()
    {
        StartNewGame();
    }
    public void StartNewGame()
    {
        InitializeGame();
        NexTurn();
    }
    private void InitializeGame()
    {
        board = new Board();
        turn = 0;
        p1.StartPlayerStuff();
        p2.StartPlayerStuff();
        p1.Draw(3);
        p2.Draw(3);
        EventsManager.UpdateHands?.Invoke();
    }
    private void NexTurn()
    {
        bool EndOfGame = turn >= MaxTurns;
        if (EndOfGame)
        {
            int winner = board.GetGameWinnerId();
            EventsManager.GameEndedWithWinner.Invoke(winner);
        }
        turn++;
        p1.energy = turn;
        p2.energy = turn; 
        p1.Draw();
        p2.Draw();
        p1.endedTurn = false;
        p2.endedTurn = false;
        EventsManager.ChangeTurnTo?.Invoke(turn);
        EventsManager.BoardChanged?.Invoke(board);
        EventsManager.UpdateHands?.Invoke();
    }
    public void PlayerRetreated(int playerId)
    {
        if(playerId == Player1Id)
            EventsManager.GameEndedWithWinner.Invoke(Player2Id);
        else
            EventsManager.GameEndedWithWinner.Invoke(Player1Id);
    }
    public void PlayerEndedTurn(int playerEndingTurn)
    {
        GetPlayerById(playerEndingTurn).endedTurn = true;

        if (p1.endedTurn && p2.endedTurn)
        {
            EndTurnPlaceCards();
        }
    }
    public void EndTurnPlaceCards()
    {
        board.TurnPrePlacedCards();
        board.UpdateLocationsPoints();
        EventsManager.BoardChanged?.Invoke(board);
        NexTurn();
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
        int cardCost = owner.GetCardByIdFromHand(cardId).baseCard.cost;

        bool hasNotEndedTurn = !owner.endedTurn;
        bool cardInHand = cardLocation == CardLocationTypes.Hand;
        bool locationAvailable = board.CheckIfLocationIsAvailable(locationid);
        bool hasEnergyToPlay = owner.energy >= cardCost;

        if (cardInHand && locationAvailable && hasEnergyToPlay && hasNotEndedTurn)
        {
            Debug.Log("CardInHand AND LocationAvailable AND HasEnergyToPlay");
            var removedCard = owner.RemoveCardFromHand(cardId);
            board.PrePlaceCardInLocation(removedCard, locationid);
            owner.energy -= cardCost;

            EventsManager.CardPlayed?.Invoke((playerId, cardId, locationid));
            EventsManager.BoardChanged?.Invoke(board);
            EventsManager.UpdateEnergy?.Invoke();
        }
    }

}
