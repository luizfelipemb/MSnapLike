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
            EventsManager.BoardChanged.AddListener(GameManager_BoardChanged);
        }
        private void GameManager_BoardChanged(Board board)
        {
            locationConjunction0.UpdateLocationConjunction(board.locations[0]);
            locationConjunction1.UpdateLocationConjunction(board.locations[1]);
            locationConjunction2.UpdateLocationConjunction(board.locations[2]);

            foreach ((CardInGame card, int locationId) in board.placeCardsQueue)
            {
                int playerId = Utils.GetLocationOwner(locationId);
                bool p1Side = playerId == GameManager.Player1Id;
                switch (locationId % 3)
                {
                    case 0:
                        {
                            locationConjunction0.AddTempCard(p1Side);
                        }
                        break;
                    case 1:
                        {
                            locationConjunction1.AddTempCard(p1Side);
                        }
                        break;
                    case 2:
                        {
                            locationConjunction2.AddTempCard(p1Side);
                        }
                        break;
                }
            }
        }
    }
}