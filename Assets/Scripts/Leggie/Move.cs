using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float power = 300;
    void Start()
    {
        Rigidbody2D body = this.GetComponent<Rigidbody2D>();
        PlayerInput playerInput = this.GetComponent<PlayerInput>();
        playerInput.Move += (float angle) =>
        {
            Vector2 force = new Vector2(power * Mathf.Cos(angle), power * Mathf.Sin(angle));
            body.AddForce(force);
        };
    }
}