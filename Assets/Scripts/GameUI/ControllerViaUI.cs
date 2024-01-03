using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class ControllerViaUI : MonoBehaviour
    {
        public int myPlayerId;
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
            GameManager.UpdateHands += UpdateHandsLocal;
            GameManager.ChangeTurnTo += GameManager_ChangeTurnTo; ;
        }

        private void GameManager_ChangeTurnTo(TurnInfo turnInfo)
        {
            if(turnInfo.currentPlayerID == myPlayerId)
            {
                //my turn
                Debug.Log(myPlayerId + " my turn");
            }
            else
            {
                //not my turn
                Debug.Log(myPlayerId + " not my turn");
            }
            if (energy)
                energy.text = turnInfo.currentTurn.ToString();
        }

        public void UpdateHandsLocal()
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

        }
        public void EndTurnButton()
        {
            gameManager.NexTurn();
        }
    }
}