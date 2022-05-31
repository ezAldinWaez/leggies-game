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
            detectAttack.OnAttacked += CheckIfAttackWillKillAndDie;
    }
    private void SelfDestruct()
    {
        OnDying?.Invoke();
        Object.Destroy(this.gameObject);
    }


    private void CheckIfAttackWillKillAndDie(float attacksTimeSinceLastAttack)
    {
        // TODO: Refactor this stuff ...
        if (this.transform.childCount > 0)
        {
            Attack myAttack = this.transform.GetChild(0).gameObject.GetComponent<Attack>();
            if (myAttack == null)
                SelfDestruct();
            if (myAttack.timeSinceLastAttack > attacksTimeSinceLastAttack)
                SelfDestruct();
        }
        else
            SelfDestruct();
    }
}
