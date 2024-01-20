using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerMessage : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public void PlayAgainClick()
    {
        gameManager.StartNewGame();
    }
}
