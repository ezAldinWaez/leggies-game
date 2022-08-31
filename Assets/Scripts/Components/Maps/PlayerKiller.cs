using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayersListMaker))]

public class PlayerKiller : MonoBehaviour
{
    private List<Transform> playersList = PlayersListMaker.playersList;
    private void Awake()
    {
        PlayerBuilder.OnInstantiatePlayer += RegisterPlayerRemovalWhenDead;
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

// TODO: Make documentation about this component.