using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void KeyPressedAction(KeyName key);
    public event KeyPressedAction OnKeyPressed;
    private Dictionary<KeyName, KeyCode> Keys;
    public void setKeys(Dictionary<KeyName, KeyCode> newKeys)
    {
        if (Keys == null) Keys = newKeys;
    }

    void Update()
    {
        if (Keys != null)
            foreach (KeyValuePair<KeyName, KeyCode> key in Keys)
            {
                if (Input.GetKeyDown(key.Value)) OnKeyPressed?.Invoke(key.Key);
            }
    }
}