using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private WinnerMessage winnerUI;
        private GameObject winnerUIcanvas;
        private void Start()
        {
            EventsManager.GameEndedWithWinner.AddListener(GameManager_GameEndedWithWinner);
            winnerUIcanvas = winnerUI.gameObject;
        }
        private void GameManager_GameEndedWithWinner(int winnerId)
        {
            winnerUIcanvas.SetActive(true);
            winnerUI.UpdateUI(winnerId);
        }
        public void PlayAgainClick()
        {
            gameManager.StartNewGame();
            winnerUIcanvas.SetActive(false);
        }
    }
}