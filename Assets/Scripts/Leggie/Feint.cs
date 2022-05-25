using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feint : MonoBehaviour
{
    [SerializeField] private float feintDuration = 0.25f;
    private Fire fire;
    private PlayerInput playerInput;
    private void Start()
    {
        fire = this.GetComponent<Fire>();
        playerInput = this.transform.parent.gameObject.GetComponent<PlayerInput>();
        playerInput.OnKeyPressed += EnableFeint;
    }

    void EnableFeint(string key)
    {
        if (key == "FEINT" && fire.timeSinceLastFire > fire.fireDuration)
        {
            playerInput.OnKeyPressed -= EnableFeint;
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<PolygonCollider2D>().enabled = true;
            float newSize = fire.fireDuration + 1;
            this.transform.localScale = new Vector3(newSize, newSize, newSize);
            Invoke("DisableFeint", feintDuration);
        }
    }

    void DisableFeint()
    {
        if (!fire.onFire)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<PolygonCollider2D>().enabled = false;
        }
        playerInput.OnKeyPressed += EnableFeint;
    }
}