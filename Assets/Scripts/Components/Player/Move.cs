using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class Move : MonoBehaviour
{
    [SerializeField] private float power = 300;
    private Rigidbody2D body;
    private void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        PlayerInput playerInput = this.GetComponent<PlayerInput>();
        playerInput.OnKeyPressed += (InputName key) =>
        {
            switch (key)
            {
                case InputName.UP: body.AddForce(new Vector2(0, power)); break;
                case InputName.LEFT: body.AddForce(new Vector2(-power, 0)); break;
                case InputName.DOWN: body.AddForce(new Vector2(0, -power)); break;
                case InputName.RIGHT: body.AddForce(new Vector2(power, 0)); break;
                default: break;
            }
        };
    }
}