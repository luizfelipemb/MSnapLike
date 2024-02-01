using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Utils
{
    private static System.Random random = new System.Random();
    public static void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            // Swap list[i] and list[j]
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
    public static bool ContainsById(int id, List<CardInGame> list)
    {
        return list.Any(card => card.id == id);
    }
    public static CardInGame FindById(int id, List<CardInGame> list)
    {
        return list.Find(card => card.id == id);
    }
    private static int cardIdGetter = 0;
    public static int CardIdGetter()
    {
        return ++cardIdGetter;
    }
    public static void RemoveAllChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Object.Destroy(child.gameObject);
        }
    }
    public static int GetLocationOwner(int locationId)
    {
        if (locationId <= 2)
        {
            return GameManager.Player1Id;
        }
        return GameManager.Player2Id;
    }
}
