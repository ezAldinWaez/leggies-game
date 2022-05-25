using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Fire : MonoBehaviour
{
    [SerializeField] public float fireDuration { get; private set; } = 5;
    [SerializeField] public float cooldownDuration { get; private set; } = 7;
    [SerializeField] private Color cooldownColor = new Color(1, 0.78431374f, 0.78431374f, 1);
    public float timeSinceLastFire { get; private set; }
    public bool onFire { get; private set; } = false;
    private PlayerInput playerInput;

    void OnReceiveInput(string key)
    {
        if (key == "FIRE")
            EnableFire();
    }
    private void Start()
    {
        timeSinceLastFire = fireDuration + cooldownDuration;
        playerInput = this.transform.parent.gameObject.GetComponent<PlayerInput>();
        playerInput.OnKeyPressed += OnReceiveInput;
    }

    private void Update()
    {
        timeSinceLastFire += Time.deltaTime;
        if (onFire)
            SetFireScale();
    }

    void EnableFire()
    {
        bool canMakeFire = (timeSinceLastFire >= fireDuration + cooldownDuration);
        if (canMakeFire)
        {
            playerInput.OnKeyPressed -= OnReceiveInput;
            ToggleFireState();
            timeSinceLastFire = 0;
            Invoke("DisableFire", fireDuration);
        }
    }

    void DisableFire()
    {
        ToggleFireState();
        playerInput.OnKeyPressed += OnReceiveInput;
        ChangeColor();
        Invoke("ReturnColor", cooldownDuration);
    }

    void SetFireScale()
    {
        float newSize = fireDuration - timeSinceLastFire + 1;
        this.transform.localScale = new Vector3(newSize, newSize, newSize);
    }

    private void ToggleFireState()
    {
        this.GetComponent<SpriteRenderer>().enabled = !this.GetComponent<SpriteRenderer>().enabled;
        this.GetComponent<PolygonCollider2D>().enabled = !this.GetComponent<PolygonCollider2D>().enabled;
        onFire = !onFire;
    }

    private void ChangeColor()
    {
        this.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = cooldownColor;
    }

    void ReturnColor()
    {
        this.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
