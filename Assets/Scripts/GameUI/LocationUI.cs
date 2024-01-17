using GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI
{
    public class LocationUI : MonoBehaviour
    {
        [SerializeField] private GameObject CardPrefab;
        [SerializeField] private Transform grid;
        public void UpdateLocation(LocationTile tile)
        {
            Utils.RemoveAllChildren(grid);
            bool TileHasCards = tile.cards.Count > 0;
            if (TileHasCards)
            {
                foreach (var card in tile.cards)
                {
                    var instanceCard = Instantiate(CardPrefab, grid);
                    instanceCard.GetComponent<CardManager>().Spawned(card.BaseCard);
                }
            }

        }
    }
}
