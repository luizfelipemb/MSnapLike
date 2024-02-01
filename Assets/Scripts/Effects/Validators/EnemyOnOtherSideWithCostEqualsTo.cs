using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnOtherSideWithCostEqualsTo : EffectValidator
{
    public override bool Passed()
    {
        return GameManager.Instance.board.CardOppositeWithCost(myCardId, 1);
    }
}
