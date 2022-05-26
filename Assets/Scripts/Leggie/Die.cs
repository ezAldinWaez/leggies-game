using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public delegate void DeathAction();
    public event DeathAction OnDying;
    public void SelfDestruct()
    {
        OnDying?.Invoke();
        Object.Destroy(this.gameObject);
    }
}
