using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Die))]
public abstract class DieAccessory : MonoBehaviour
{
    void Start(){
        this.GetComponent<Die>().OnDying += AccessoryAction;
    }

    protected abstract void AccessoryAction();
}
