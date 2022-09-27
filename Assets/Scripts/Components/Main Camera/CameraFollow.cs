using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LeggiesLibrary;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float bigOffsetDistanceX = 1, smallOffsetDistanceX = 0.5f;
    [SerializeField] private Vector2 offsetCenter = Vector2.zero;
    private List<Transform> playersList = PlayersListManager.playersList;
    private float sizeMargin;
    private Vector2 minPlayersPosition, maxPlayersPosition;
    bool isOutOfBigOffsetX, isOutOfBigOffsetY, isOutOfSmallOffsetX, isOutOfSmallOffsetY;
    private Camera myCamera;
    private void Awake()
    {
        myCamera = this.GetComponent<Camera>();
        myCamera.orthographic = true;
        myCamera.orthographicSize = 5;
        transform.position = new Vector3(0, 0, -3);
        sizeMargin = 0.004f * Mathf.Max(Screen.height, Screen.width);
    }

    void Update()
    {
        SetMinMaxPlayersPositons();
        MoveTowardsSupposedPosition();
        SetCameraSize();
    }

    void SetMinMaxPlayersPositons()
    {
        if (playersList.Count != 0)
        {
            minPlayersPosition = maxPlayersPosition = playersList[0].position;
            for (int i = 1; i < playersList.Count; i++)
            {
                // Debug.Log(playersList[i].position);
                if (maxPlayersPosition.x < playersList[i].position.x)
                    maxPlayersPosition.x = playersList[i].position.x;
                else if (minPlayersPosition.x > playersList[i].position.x)
                    minPlayersPosition.x = playersList[i].position.x;

                if (maxPlayersPosition.y < playersList[i].position.y)
                    maxPlayersPosition.y = playersList[i].position.y;
                else if (minPlayersPosition.y > playersList[i].position.y)
                    minPlayersPosition.y = playersList[i].position.y;
            }
        }
    }

    // TODO: Document Attack, Feint, and Camera shake. And LeggiesLibrary.
    
    // TODO: Extract the offset madness into a class of its own. Just give it bigOffsetDistanceX, Y, and Center and it does all the madness.
    void MoveTowardsSupposedPosition()
    {
        Vector2 supposedPosition = (minPlayersPosition + maxPlayersPosition) / 2;
        Vector2 distance = supposedPosition - (Vector2) this.transform.position;
        Vector2 bigOffsetDistance = new Vector2(bigOffsetDistanceX, bigOffsetDistanceX * Screen.height / Screen.width);
        Vector2 positiveBigOffset = offsetCenter + bigOffsetDistance/2;
        Vector2 negativeBigOffset = offsetCenter - bigOffsetDistance/2;
        Vector2 positiveSmallOffset = positiveBigOffset * smallOffsetDistanceX/bigOffsetDistanceX;
        Vector2 negativeSmallOffset = negativeBigOffset * smallOffsetDistanceX/bigOffsetDistanceX; 
        isOutOfBigOffsetX = distance.x > positiveBigOffset.x || distance.x < negativeBigOffset.x;
        isOutOfBigOffsetY = distance.y > positiveBigOffset.y || distance.y < negativeBigOffset.y;
        isOutOfSmallOffsetX = distance.x > positiveSmallOffset.x || distance.x < negativeSmallOffset.x;
        isOutOfSmallOffsetY = distance.y > positiveSmallOffset.y || distance.y < negativeSmallOffset.y;
        if (isOutOfBigOffsetX)
            this.transform.position = new Vector3((distance.x > positiveBigOffset.x)
                                                   ? supposedPosition.x - positiveBigOffset.x
                                                   : supposedPosition.x - negativeBigOffset.x,
                                                  this.transform.position.y,
                                                  this.transform.position.z);
        else if (isOutOfSmallOffsetX)
            this.transform.position = new Vector3((distance.x > positiveSmallOffset.x)
                                                   ? this.transform.position.x + Time.deltaTime * smallOffsetDistanceX/bigOffsetDistanceX
                                                   : this.transform.position.x - Time.deltaTime * smallOffsetDistanceX/bigOffsetDistanceX,
                                                  this.transform.position.y,
                                                  this.transform.position.z);
        if (isOutOfBigOffsetY)
            this.transform.position = new Vector3(this.transform.position.x,
                                                  (distance.y > positiveBigOffset.y)
                                                   ? supposedPosition.y - positiveBigOffset.y
                                                   : supposedPosition.y - negativeBigOffset.y,
                                                  this.transform.position.z);
        else if (isOutOfSmallOffsetY)
            this.transform.position = new Vector3(this.transform.position.x,
                                                  (distance.y > positiveSmallOffset.y)
                                                   ? this.transform.position.y + Time.deltaTime * smallOffsetDistanceX/bigOffsetDistanceX
                                                   : this.transform.position.y - Time.deltaTime * smallOffsetDistanceX/bigOffsetDistanceX,
                                                  this.transform.position.z);
    }

    private void SetCameraSize()
    {
        float yDistance = (maxPlayersPosition.y - minPlayersPosition.y),
              xDistance = (maxPlayersPosition.x - minPlayersPosition.x);
        float maxDistance = Mathf.Max(yDistance, xDistance * Screen.height / Screen.width);
        myCamera.orthographicSize = sizeMargin + maxDistance / 2;
    }
}