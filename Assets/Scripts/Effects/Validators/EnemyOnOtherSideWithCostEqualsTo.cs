using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnOtherSideWithCostEqualsTo : EffectValidator
{
    public override bool Passed()
    {
        LocationConjuction location = GameManager.Instance.board.GetCardLocation(myCardId);
        if (location.p1Side.HasCardById(myCardId) && location.p2Side.HasCardByBaseCost(1))
        {
            return true;
        }
        else if (location.p2Side.HasCardById(myCardId) && location.p1Side.HasCardByBaseCost(1))
        {
            return true;
        }
        return false;
    }
}
