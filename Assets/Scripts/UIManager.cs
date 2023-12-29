using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [Header("To be assigned")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject p1Hand;
    [SerializeField] private GameObject p2Hand;
    [Header("Prefabs")]
    [SerializeField] private GameObject CardPrefab;

    private void Awake()
    {
        GameManager.UpdateHands += UpdateHandsLocal;
    }

    public void UpdateHandsLocal()
    {
        UpdateHand(p1Hand.transform, gameManager.p1.hand);
        UpdateHand(p2Hand.transform, gameManager.p2.hand);
    }

    void UpdateHand(Transform handTransform, List<CardInGame> cards)
    {
        RemoveAllChildren(handTransform);

        foreach (CardInGame card in cards)
        {
            var instanceCard = Instantiate(CardPrefab, handTransform);
            instanceCard.GetComponent<CardManager>().Spawned(card.BaseCard, gameManager);
        }
    }

    void RemoveAllChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }
}
