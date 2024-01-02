using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    public static event System.Action UpdateHands;
    public Player p1;
    public Player p2;
    public Board board;
    public bool p1Turn = true;
    public int turn = 0;
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
