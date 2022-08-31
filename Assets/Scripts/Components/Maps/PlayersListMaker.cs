using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBuilder))]

public class PlayersListMaker : MonoBehaviour
{
    public static List<Transform> playersList = new();
    private void Awake()
    {
        playersList.Clear();
        PlayerBuilder.OnInstantiatePlayer += InsertPlayerToPlayersList;
    }

    private void InsertPlayerToPlayersList(GameObject newPlayer, int playerNumber)
    {
        playersList.Insert(playerNumber, newPlayer.transform);
    }
}

// TODO: Make documentation about this component.