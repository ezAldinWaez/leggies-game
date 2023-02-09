using System.Collections.Generic;
using UnityEngine;

public class DefaultInputDictionaries
{
    public static List<Dictionary<InputName, KeyCode>> defaultKeysOfPlayer { get; private set; } = new() {
        new () {
            [InputName.UP] = KeyCode.W,
            [InputName.LEFT] = KeyCode.A,
            [InputName.DOWN] = KeyCode.S,
            [InputName.RIGHT] = KeyCode.D,
            [InputName.RETREAT] = KeyCode.Q,
            [InputName.ATTACK] = KeyCode.R,
            [InputName.FEINT] = KeyCode.E,
            [InputName.THROW] = KeyCode.C,
        },
        new () {
            [InputName.UP] = KeyCode.Keypad8,
            [InputName.LEFT] = KeyCode.Keypad4,
            [InputName.DOWN] = KeyCode.Keypad5,
            [InputName.RIGHT] = KeyCode.Keypad6,
            [InputName.RETREAT] = KeyCode.Keypad9,
            [InputName.ATTACK] = KeyCode.KeypadPlus,
            [InputName.FEINT] = KeyCode.Keypad7,
            [InputName.THROW] = KeyCode.Keypad3,
        },
        new () {
            [InputName.UP] = KeyCode.Y,
            [InputName.LEFT] = KeyCode.G,
            [InputName.DOWN] = KeyCode.H,
            [InputName.RIGHT] = KeyCode.J,
            [InputName.RETREAT] = KeyCode.T,
            [InputName.ATTACK] = KeyCode.I,
            [InputName.FEINT] = KeyCode.U,
            [InputName.THROW] = KeyCode.M,
        },
        new () {
            [InputName.UP] = KeyCode.P,
            [InputName.LEFT] = KeyCode.L,
            [InputName.DOWN] = KeyCode.Semicolon,
            [InputName.RIGHT] = KeyCode.Quote,
            [InputName.RETREAT] = KeyCode.O,
            [InputName.ATTACK] = KeyCode.RightBracket,
            [InputName.FEINT] = KeyCode.LeftBracket,
            [InputName.THROW] = KeyCode.Return,
        }
    };
}