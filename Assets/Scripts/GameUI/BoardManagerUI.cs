using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI
{
    public class BoardManagerUI : MonoBehaviour
    {
        [SerializeField] private LocationConjunctionUI locationConjunction0;
        [SerializeField] private LocationConjunctionUI locationConjunction1;
        [SerializeField] private LocationConjunctionUI locationConjunction2;
        private void Awake()
        {
            GameManager.BoardChanged.AddListener(GameManager_BoardChanged);
        }
        private void GameManager_BoardChanged(Board board)
        {
            locationConjunction0.UpdateLocationConjunction(board.locations[0]);
            locationConjunction1.UpdateLocationConjunction(board.locations[1]);
            locationConjunction2.UpdateLocationConjunction(board.locations[2]);
        }
    }
}