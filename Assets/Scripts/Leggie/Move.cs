using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float power = 300;
    private PlayerInput playerInput;

    void MoveRigidbody2D(float angle)
    {
        Vector2 force = new Vector2(power * Mathf.Cos(angle), power * Mathf.Sin(angle));
        body.AddForce(force);
    }

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        playerInput = this.GetComponent<PlayerInput>();
        playerInput.Move += MoveRigidbody2D;
    }
}
