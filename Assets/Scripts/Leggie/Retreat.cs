using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retreat : MonoBehaviour
{
    [SerializeField] private float retreatPower = 1000;
    void Start()
    {
        Rigidbody2D movedBody = this.GetComponent<Rigidbody2D>();
        PlayerInput playerInput = this.GetComponent<PlayerInput>();
        playerInput.Retreat += () =>
        {
            float angle = Mathf.Atan2(movedBody.velocity.y, movedBody.velocity.x);
            movedBody.velocity = new Vector2(0, 0);
            Vector2 movedForce = new Vector2(retreatPower * -Mathf.Cos(angle), retreatPower * -Mathf.Sin(angle));
            movedBody.AddForce(movedForce);
        };
    }
}