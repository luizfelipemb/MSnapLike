using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Card")]
public class Card : ScriptableObject
{
    public int id;
    public string description;
    public int cost;
    public int power;
    public EffectType effect;
}
