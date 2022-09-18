using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    private List<Transform> playersList = PlayersListManager.playersList;
    private float sizeMargin;
    private Vector2 minPlayersPosition, maxPlayersPosition;
    public float offset1X = 0.35f, offset1Y = -0.35f, offset2X = -0.35f, offset2Y = -0.75f;
    float distanceX, distanceY;
    bool isOutOfOffsetX, isOutOfOffsetY, isOutOfCenterX, isOutOfCenterY;
    private void Awake()
    {
        this.GetComponent<Camera>().orthographic = true;
        this.GetComponent<Camera>().orthographicSize = 5;
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

    // TODO: The method ahead was made using drugs. If you wanna understand it, be sure to use them.
    void MoveTowardsSupposedPosition()
    {
        Vector2 supposedPosition = (minPlayersPosition + maxPlayersPosition) / 2;
        distanceX = supposedPosition.x - this.transform.position.x;
        distanceY = supposedPosition.y - this.transform.position.y;
        isOutOfOffsetX = distanceX > offset1X || distanceX < offset2X;
        isOutOfOffsetY = distanceY > offset1Y || distanceY < offset2Y;
        isOutOfCenterX = distanceX > offset1X / 3.5f || distanceX < offset2X / 3.5f;
        isOutOfCenterY = distanceY > offset1Y / 3.5f || distanceY < offset2Y / 3.5f;
        if (isOutOfOffsetX)
            this.transform.position = new Vector3((distanceX > offset1X)
                                                   ? supposedPosition.x - offset1X
                                                   : supposedPosition.x - offset2X,
                                                  this.transform.position.y,
                                                  this.transform.position.z);
        else if (isOutOfCenterX)
            this.transform.position = new Vector3((distanceX > offset1X / 3.5f)
                                                   ? this.transform.position.x + Time.deltaTime / 3.5f
                                                   : this.transform.position.x - Time.deltaTime / 3.5f,
                                                  this.transform.position.y,
                                                  this.transform.position.z);
        if (isOutOfOffsetY)
            this.transform.position = new Vector3(this.transform.position.x,
                                                  (distanceY > offset1Y)
                                                   ? supposedPosition.y - offset1Y
                                                   : supposedPosition.y - offset2Y,
                                                  this.transform.position.z);
        else if (isOutOfCenterY)
            this.transform.position = new Vector3(this.transform.position.x,
                                                  (distanceY > offset1Y / 3.5f)
                                                   ? this.transform.position.y + Time.deltaTime / 3.5f
                                                   : this.transform.position.y - Time.deltaTime / 3.5f,
                                                  this.transform.position.z);
    }

    private void SetCameraSize()
    {
        float yDistance = (maxPlayersPosition.y - minPlayersPosition.y),
              xDistance = (maxPlayersPosition.x - minPlayersPosition.x);
        float maxDistance = Mathf.Max(yDistance, xDistance * Screen.height / Screen.width);
        this.GetComponent<Camera>().orthographicSize = sizeMargin + maxDistance / 2;
    }
}