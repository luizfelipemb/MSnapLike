using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Card")]
[System.Serializable]
public class CardBase : ScriptableObject
{
    public string description;
    public int cost;
    public int power;
    public EffectTriggers effectTrigger;
    public CardEffectValidators effectValidator;
    public CardEffectConsequences effectConsequence;
    public int effectAmount;
    public Sprite sprite;
}
