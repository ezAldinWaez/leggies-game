using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DieMethod : MonoBehaviour
{
    // TODO: Make docs about this.
    public abstract void Die();

    protected void DeleteObject()
    {
        Object.Destroy(this.gameObject);
    }
}
