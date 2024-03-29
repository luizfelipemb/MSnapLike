using GameUI;

using UnityEngine;

namespace GameUI
{
    public class LocationUI : MonoBehaviour
    {
        [SerializeField] private GameObject CardPrefab;
        [SerializeField] private GameObject TempCardPrefab;
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
                    instanceCard.GetComponent<CardManager>().Spawned(card);
                }
            }
        }
        public void AddTempCard()
        {
            Instantiate(TempCardPrefab, grid);
        }
    }
}
