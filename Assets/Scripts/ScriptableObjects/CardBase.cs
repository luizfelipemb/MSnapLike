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
    public EffectType effect;
    public Sprite sprite;
}
