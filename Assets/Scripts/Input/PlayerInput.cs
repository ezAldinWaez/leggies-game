using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void KeyPressedAction(string key);
    public event KeyPressedAction OnKeyPressed;
    private Dictionary<string, KeyCode> Keys;
    public void setKeys(Dictionary<string, KeyCode> newKeys)
    {
        if (Keys == null) Keys = newKeys;
    }

    void Update()
    {
        foreach (KeyValuePair<string, KeyCode> key in Keys)
        {
            if (Input.GetKeyDown(key.Value)) OnKeyPressed?.Invoke(key.Key);
        }
    }
}