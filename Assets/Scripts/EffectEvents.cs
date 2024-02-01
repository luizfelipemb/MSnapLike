using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EffectEvents
{
    public static UnityEvent<int> CardRevealed = new UnityEvent<int>();
    public static UnityEvent<(int cardIdAffected, int amount)> IncreasePowerOfCard = new UnityEvent<(int cardIdAffected, int amount)>();

}
