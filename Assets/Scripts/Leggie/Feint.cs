using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feint : MonoBehaviour
{
    [SerializeField] private float feintDuration = 0.25f;
    private Fire fire;
    private PlayerInput playerInput;

    void OnReceiveInput(string key)
    {
        if (key == "FEINT")
            EnableFeint();
    }

    private void Start()
    {
        fire = this.GetComponent<Fire>();
        playerInput = this.transform.parent.gameObject.GetComponent<PlayerInput>();
        playerInput.OnKeyPressed += OnReceiveInput;
    }

    void EnableFeint()
    {
        if (!fire.onFire)
        {
            playerInput.OnKeyPressed -= OnReceiveInput;
            ToggleFeintState();
            SetFeintSize();
            Invoke("DisableFeint", feintDuration);
        }
    }

    void DisableFeint()
    {
        if (!fire.onFire)
            ToggleFeintState();
        playerInput.OnKeyPressed += OnReceiveInput;
    }

    private void ToggleFeintState()
    {
        this.GetComponent<SpriteRenderer>().enabled = !this.GetComponent<SpriteRenderer>().enabled;
        this.GetComponent<PolygonCollider2D>().enabled = !this.GetComponent<PolygonCollider2D>().enabled;
    }
    private void SetFeintSize()
    {
        float newSize = fire.fireDuration + 1;
        this.transform.localScale = new Vector3(newSize, newSize, newSize);
    }
}