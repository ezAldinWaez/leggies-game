using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DieMethod : MonoBehaviour
{
    public abstract void Die();

    protected void DeleteObject()
    {
        Object.Destroy(this.gameObject);
    }
}
