using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBuilder))]
public class PlayerInputSetter : MonoBehaviour
{
    private void Awake()
    {
        PlayerBuilder.OnInstantiatePlayer += SetPlayerInput;
    }

    private void SetPlayerInput(GameObject newPlayer, int playerNumber)
    {
        Dictionary<InputName, KeyCode> newPlayerKeys = DefaultInputDictionaries.defaultKeysOfPlayer[playerNumber];
        newPlayer.GetComponent<PlayerInput>().setKeys(newPlayerKeys);
    }
}