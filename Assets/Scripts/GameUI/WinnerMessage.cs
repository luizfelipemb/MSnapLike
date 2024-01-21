using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameUI
{
    public class WinnerMessage : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI winnerMessage;
        public void UpdateUI(int winnerPlayer)
        {
            if(winnerPlayer == GameManager.NullId)
            {
                winnerMessage.text = $"Draw!";
            }
            else
            {
                winnerMessage.text = $"Player {winnerPlayer} Wins!";
            }
            
        }
    }
}