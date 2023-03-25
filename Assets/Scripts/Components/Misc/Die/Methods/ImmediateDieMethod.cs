using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmediateDieMethod : DieMethod
{
    public override void Die()
    {
        DeleteObject();
    }
}
