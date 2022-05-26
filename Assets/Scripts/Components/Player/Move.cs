using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [SerializeField] private float power = 300;
    [SerializeField] private float maxSpeed = 25;
    private Rigidbody2D body;
    private void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        PlayerInput playerInput = this.GetComponent<PlayerInput>();
        playerInput.OnKeyPressed += (string key) =>
        {
            switch (key)
            {
                case "UP": body.AddForce(new Vector2(0, power)); break;
                case "LEFT": body.AddForce(new Vector2(-power, 0)); break;
                case "DOWN": body.AddForce(new Vector2(0, -power)); break;
                case "RIGHT": body.AddForce(new Vector2(power, 0)); break;
                default: break;
            }
        };
    }
    private void Update()
    {
        float speed = body.velocity.magnitude;
        if (speed > maxSpeed)
        {
            ReduceSpeed(speed - maxSpeed);
        }
    }

    private void ReduceSpeed(float speedToReduce)
    {
        Vector2 normalizedVelocity = body.velocity.normalized;
        Vector2 forceToReduce = normalizedVelocity * speedToReduce;
        body.AddForce(-forceToReduce);
    }
}