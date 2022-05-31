using UnityEngine;

[RequireComponent(typeof(PlayerBuilder))]
public class PlayerPositioner : MonoBehaviour
{
    [SerializeField] private Vector3[] playersInitialPositions;

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
            if (e.GetType() == typeof(System.IndexOutOfRangeException))
                Debug.Log("Duude, you didn't set the initial position of some players.");
            Debug.Log(e.Message);
        }
    }
}