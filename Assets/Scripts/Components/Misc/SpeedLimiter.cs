using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpeedLimiter : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 25;
    private Rigidbody2D body;
    private void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // The following came from the law of terminal speed and air resistance.
        float forceToReduce = body.mass * body.gravityScale * (float) System.Math.Pow(body.velocity.magnitude / maxSpeed, 2);
        ReduceSpeed(forceToReduce);
    }

    private void ReduceSpeed(float speedToReduce)
    {
        Vector2 normalizedVelocity = body.velocity.normalized;
        Vector2 forceToReduce = normalizedVelocity * speedToReduce;
        body.AddForce(-forceToReduce);
    }
}