using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    //Subscribes to events on GameManager to update UI according to the game state
    //Read Actions on the UI and sends to GameManager to validate
    //  and execute the action.
    public class ControllerViaUI : MonoBehaviour
    {
        public int myPlayerId;
        private int cardClickedId;
        [Header("To be assigned")]
        [SerializeField] private GameManager gameManager;
        [SerializeField] private LocationUI location0;
        [SerializeField] private LocationUI location1;
        [SerializeField] private LocationUI location2;
        [SerializeField] private TextMeshProUGUI energy;
        [Header("Prefabs")]
        [SerializeField] private GameObject CardPrefab;

        private void Awake()
        {
            GameManager.UpdateHands.AddListener(GameManager_UpdateHandsLocal);
            GameManager.ChangeTurnTo.AddListener(GameManager_ChangeTurnTo);
            GameManager.CardPlayed.AddListener(GameManager_CardPlayed);
        }
        private void GameManager_CardPlayed((int playerId, int cardId, int locationId) eventData)
        {
            int playerId = eventData.playerId;
            int cardId = eventData.cardId;
            int locationId = eventData.locationId;

            // Your logic for handling the event data...
            Debug.Log($"Card played by Player {playerId} with Card ID {cardId} at Location {locationId}");
        }
        private void GameManager_ChangeTurnTo(int energy)
        {
            if (this.energy)
                this.energy.text = energy.ToString();
        }

        public void GameManager_UpdateHandsLocal()
        {
            UpdateHand(transform, gameManager.GetPlayerById(myPlayerId).hand);
        }
        private void UpdateHand(Transform handTransform, List<CardInGame> cards)
        {
            RemoveAllChildren(handTransform);

            foreach (CardInGame card in cards)
            {
                var instanceCard = Instantiate(CardPrefab, handTransform);
                instanceCard.GetComponent<CardManager>().Spawned(card.BaseCard);
                instanceCard.GetComponent<Button>().
                    onClick.AddListener(()=>CardClicked(card.id));
            }
        }

        private void RemoveAllChildren(Transform parent)
        {
            foreach (Transform child in parent)
            {
                Destroy(child.gameObject);
            }
        }
        private void CardClicked(int cardId)
        {
            Debug.Log(cardId);
            cardClickedId = cardId;
        }
        public void LocationClicked(int locationId)
        {
            Debug.Log(locationId);
            if(cardClickedId != 0)
            {
                gameManager.TryPlayCardBy(myPlayerId, cardClickedId, locationId);
            }
        }
        public void EndTurnButton()
        {
            gameManager.PlayerEndedTurn(myPlayerId);
        }
    }
}