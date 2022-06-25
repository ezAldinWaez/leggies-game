using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    [SerializeField] bool willDieByAttack = true;
    public delegate void DeathAction();
    public event DeathAction OnDying;

    private void Start()
    {
        DetectAttack detectAttack = this.GetComponent<DetectAttack>();
        if (detectAttack != null && willDieByAttack)
            detectAttack.OnAttacked += (bool isAttackLethal) => {
                if(isAttackLethal) SelfDestruct();
            };
    }
    private void SelfDestruct()
    {
        OnDying?.Invoke();
        Object.Destroy(this.gameObject);
    }
}
