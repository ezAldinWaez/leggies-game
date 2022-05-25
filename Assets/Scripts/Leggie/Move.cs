using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float power = 300;
    private void Start()
    {
        Rigidbody2D body = this.GetComponent<Rigidbody2D>();
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
}