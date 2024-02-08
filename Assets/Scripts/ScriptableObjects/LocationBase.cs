using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Location")]
[System.Serializable]
public class LocationBase : ScriptableObject
{
    public string description;
    public EffectTriggers effectTrigger;
    public LocationEffectValidators effectValidator;
    public LocationEffectConsequences effectConsequence;
    public int effectAmount;
    public Sprite sprite;
}