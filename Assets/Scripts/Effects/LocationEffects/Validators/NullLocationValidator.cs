using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullLocationValidator : LocationEffectValidator
{
    public override bool Passed()
    {
        return true;
    }
}
