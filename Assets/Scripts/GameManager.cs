using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurnInfo
{
    public int currentPlayerID;
    public int currentTurn;
}


public class GameManager : MonoBehaviour
{
    public static event System.Action UpdateHands;
    public static event System.Action<TurnInfo> ChangeTurnTo;
    public Player p1;
    public Player p2;
    public Board board;
    public int turn = 0;
    public int playersTurnId;
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
    public void NexTurn()
    {
        currentTurn.currentPlayerID = SwitchPlayer(currentTurn.currentPlayerID);
        currentTurn.currentTurn++;
        ChangeTurnTo?.Invoke(currentTurn);
    }
    public int SwitchPlayer(int currentPlayerID)
    {
        if (currentPlayerID == p2.id)
        {
            return p1.id;
        }
        else
        {
            return p2.id;
        }
    }
    public Player GetPlayerById(int id)
    {
        if(p1.id == id)
            return p1;
        return p2;
    }
    public void TryPlayCardBy(int playerId,CardBase card)
    {

    }

}
