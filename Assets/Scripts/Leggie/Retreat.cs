using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retreat : MonoBehaviour
{
    private Rigidbody2D body;
    private PlayerInput playerInput;

    [SerializeField] private float retreatPower = 1000;

    void RetreatRigidbody2D()
    {
        float angle = Mathf.Atan2(body.velocity.y, body.velocity.x);
        body.velocity = new Vector2(0, 0);
        Vector2 force = new Vector2(retreatPower * -Mathf.Cos(angle), retreatPower * -Mathf.Sin(angle));
        body.AddForce(force);
    }

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        playerInput = this.GetComponent<PlayerInput>();
        playerInput.Retreat += RetreatRigidbody2D;
    }
}
