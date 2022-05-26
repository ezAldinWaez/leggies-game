using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Die))]
public class PlayerDealWithFire : DealWithFire
{
    public override void OnDetectedFire(float firesTimeSinceLastFire)
    {
        Die myDie = this.GetComponent<Die>();
        Fire myFire = this.transform.GetChild(0).gameObject.GetComponent<Fire>();
        if (myFire == null)
            myDie.SelfDestruct();
        if (myFire.timeSinceLastFire > firesTimeSinceLastFire)
            myDie.SelfDestruct();
    }
}
