using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DealWithFire : MonoBehaviour
{
    public abstract void OnDetectedFire(float firesTimeSinceLastFire);
}
