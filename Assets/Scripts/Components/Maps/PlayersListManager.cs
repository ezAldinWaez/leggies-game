using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBuilder))]

public class PlayersListManager : MonoBehaviour
{
    public static List<Transform> playersList = new();
    private void Awake()
    {
        playersList.Clear();
        PlayerBuilder.OnInstantiatePlayer += InsertPlayerToPlayersList;
        PlayerBuilder.OnInstantiatePlayer += RegisterPlayerRemovalWhenDead;
    }

    private void InsertPlayerToPlayersList(GameObject newPlayer, int playerNumber)
    {
        playersList.Insert(playerNumber, newPlayer.transform);
    }
    
    private void RegisterPlayerRemovalWhenDead(GameObject newPlayer, int playerNumber)
    {
        Die newPlayersDie = newPlayer.GetComponent<Die>();
        if (newPlayersDie != null)
            newPlayersDie.OnDying += () =>
            {
                playersList.Remove(newPlayer.transform);
            };
    }
}