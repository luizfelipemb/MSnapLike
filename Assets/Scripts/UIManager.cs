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

    private void Start()
    {
        GameManager.UpdateHands += UpdateHandsLocal;
    }
    public void UpdateHandsLocal()
    {
        RemoveAllChildren(p1Hand.transform);
        foreach(Card card in gameManager.p1.hand)
        {
            var instanceCard = Instantiate(CardPrefab, p1Hand.transform);
            instanceCard.GetComponent<CardManager>().Spawned(card,gameManager);
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
