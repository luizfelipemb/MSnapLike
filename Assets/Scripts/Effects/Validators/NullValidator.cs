using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullValidator : EffectValidator
{
    public override bool PassedIf()
    {
        return true;
    }
}
