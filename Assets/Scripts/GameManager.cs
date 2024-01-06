using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event System.Action UpdateHands;
    public static event System.Action<int> ChangeTurnTo;
    public Player p1;
    public Player p2;
    public Board board;
    public int turn = 0;
    public TurnInfo currentTurn;
    private static int cardIdGetter = 0;
    public static int CardIdGetter()
    {
        return ++cardIdGetter;
    }
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
        var owner = GetPlayerById(playerId);
        var cardLocation = owner.LocateCard(cardId);
        //check if card is in its hand
        if(cardLocation == CardLocationTypes.Hand)
        {
            Debug.Log("Card in Hand!");
        }
        //check if player has energy to play
        //ignored by now: if(owner.energy >= )

        //check if location is available
        if (board.CheckIfLocationIsAvailable(playerId, locationid))
        {
            Debug.Log("Location Available!");
        }
        //make it happen
    }

}
