using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

namespace GameUI
{
    public class ControllerViaUI : MonoBehaviour
    {
        public int myId;
        [Header("To be assigned")]
        [SerializeField] private GameManager gameManager;
        [Header("Prefabs")]
        [SerializeField] private GameObject CardPrefab;
        private void Awake()
        {
            GameManager.UpdateHands += UpdateHandsLocal;
        }
        public void UpdateHandsLocal()
        {
            UpdateHand(transform, gameManager.GetPlayerById(myId).hand);
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
    }
}