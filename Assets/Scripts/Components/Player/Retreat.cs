using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Retreat : MonoBehaviour
{
    [SerializeField] private float power = 1000;
    void Start()
    {
        Rigidbody2D movedBody = this.GetComponent<Rigidbody2D>();
        PlayerInput playerInput = this.GetComponent<PlayerInput>();
        playerInput.OnKeyPressed += (string key) =>
        {
            if (key == "RETREAT")
            {
                float angle = Mathf.Atan2(movedBody.velocity.y, movedBody.velocity.x);
                movedBody.velocity = new Vector2(0, 0);
                Vector2 movedForce = new Vector2(power * -Mathf.Cos(angle), power * -Mathf.Sin(angle));
                movedBody.AddForce(movedForce);
            }
        };
    }
}