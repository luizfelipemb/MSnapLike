using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Deck")]
public class Deck : ScriptableObject
{
    public List<CardBase> cards;
}
