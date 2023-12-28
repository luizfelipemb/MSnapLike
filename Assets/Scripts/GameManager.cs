using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event System.Action UpdateHands;
    public Player p1;
    public Player p2;
    public bool p1Turn = true;
    public int turn = 0;

    private void Start()
    {
        InitializeGame();
    }
    private void InitializeGame()
    {
        p1.DrawInitialHand();
        p2.DrawInitialHand();
        UpdateHands?.Invoke();
    }
    public void TryPlayCardBy(int playerId,Card card)
    {

    }

}
