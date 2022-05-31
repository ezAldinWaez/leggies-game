using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDictionaries : MonoBehaviour
{
    private static List<Dictionary<KeyName, KeyCode>> defaultKeysOfPlayer = new() {
        new () {
            [KeyName.UP] = KeyCode.W,
            [KeyName.LEFT] = KeyCode.A,
            [KeyName.DOWN] = KeyCode.S,
            [KeyName.RIGHT] = KeyCode.D,
            [KeyName.RETREAT] = KeyCode.Q,
            [KeyName.ATTACK] = KeyCode.R,
            [KeyName.FEINT] = KeyCode.E
        },
        new () {
            [KeyName.UP] = KeyCode.Keypad8,
            [KeyName.LEFT] = KeyCode.Keypad4,
            [KeyName.DOWN] = KeyCode.Keypad5,
            [KeyName.RIGHT] = KeyCode.Keypad6,
            [KeyName.RETREAT] = KeyCode.Keypad9,
            [KeyName.ATTACK] = KeyCode.KeypadPlus,
            [KeyName.FEINT] = KeyCode.Keypad7
        },
        new () {
            [KeyName.UP] = KeyCode.Y,
            [KeyName.LEFT] = KeyCode.G,
            [KeyName.DOWN] = KeyCode.H,
            [KeyName.RIGHT] = KeyCode.J,
            [KeyName.RETREAT] = KeyCode.T,
            [KeyName.ATTACK] = KeyCode.I,
            [KeyName.FEINT] = KeyCode.U
        },
        new () {
            [KeyName.UP] = KeyCode.P,
            [KeyName.LEFT] = KeyCode.L,
            [KeyName.DOWN] = KeyCode.Semicolon,
            [KeyName.RIGHT] = KeyCode.Quote,
            [KeyName.RETREAT] = KeyCode.O,
            [KeyName.ATTACK] = KeyCode.RightBracket,
            [KeyName.FEINT] = KeyCode.LeftBracket
        }
    };
    private static int playersCount;

    public static Dictionary<KeyName, KeyCode> GetPlayerKeys(int playerNumber)
    {
        Dictionary<KeyName, KeyCode> playerKeys = defaultKeysOfPlayer[playerNumber];
        return playerKeys;
    }
}