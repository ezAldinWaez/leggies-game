using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmediateDieMethod : DieMethod
{
    // TODO: Make docs about this.
    public override void Die()
    {
        DeleteObject();
    }
}
