using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Effect
{
    protected int conseqAmount;
    protected abstract void Apply();
}
