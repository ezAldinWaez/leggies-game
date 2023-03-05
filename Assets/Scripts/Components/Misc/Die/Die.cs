using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeggiesLibrary;

public class Die : MonoBehaviour
{
    // TODO: Update docs about this.

    public delegate void DeathAction();
    public event DeathAction OnDying;

    private void Start()
    {
        foreach (DieCause dieCause in this.GetComponents(typeof(DieCause)))
        {
            dieCause.OnDieCauseLethal += () =>
            {
                OnDying?.Invoke();
                dieCause.dieMethod.Die();
            };
        }
    }
}
