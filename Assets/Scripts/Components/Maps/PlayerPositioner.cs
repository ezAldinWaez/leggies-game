using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBuilder))]
public class PlayerPositioner : MonoBehaviour
{
    [SerializeField] private List<Vector3> playersInitialPositions = new();

    private void Awake()
    {
        PlayerBuilder.OnInstantiatePlayer += SetPlayerPosition;
    }

    private void SetPlayerPosition(GameObject newPlayer, int playerNumber)
    {
        try
        {
            newPlayer.transform.position = playersInitialPositions[playerNumber];
        }
        catch (System.Exception e)
        {
            Debug.Log("Duude, you didn't set the initial position of some players.");
            Debug.Log(e.Message);
            playersInitialPositions.Add(new Vector3(0,0,0));
            newPlayer.transform.position = playersInitialPositions[playerNumber];
        }
    }
}