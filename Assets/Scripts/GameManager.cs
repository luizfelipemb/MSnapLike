using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uimanager;
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
        uimanager.UpdateHands();
    }

}
