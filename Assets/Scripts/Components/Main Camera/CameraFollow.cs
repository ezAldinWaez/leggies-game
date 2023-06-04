using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float followingSpeed = 1, distanceFromBigOffsetX = 1, distanceFromSmallOffsetX = 0.5f;
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

        if (distanceFromSmallOffsetX > distanceFromBigOffsetX)
        {
            distanceFromSmallOffsetX = distanceFromBigOffsetX;
            Debug.Log("Dude? Can't have the small offset be bigger than the big, duh. I set them both to the same value, the big offset.");
        }
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

    class CameraOffset
    {
        public Vector2 center { get; private set; }
        public Vector2 distanceFromEdge { get; private set; }
        public Vector2 positive { get; private set; }
        public Vector2 negative { get; private set; }

        public CameraOffset(float distanceFromEdgeX, Vector2 offsetCenter)
        {
            this.center = offsetCenter;
            this.distanceFromEdge = new Vector2(distanceFromEdgeX, distanceFromEdgeX * Screen.height / Screen.width);
            this.positive = offsetCenter + distanceFromEdge;
            this.negative = offsetCenter - distanceFromEdge;
        }

        public bool isOutOfBoundariesX(Vector2 supposedPosition, Vector2 currentPosition)
        {
            float distanceX = supposedPosition.x - currentPosition.x;
            return distanceX > positive.x || distanceX < negative.x;
        }

        public bool isOutOfBoundariesY(Vector2 supposedPosition, Vector2 currentPosition)
        {
            float distanceY = supposedPosition.y - currentPosition.y;
            return distanceY > positive.y || distanceY < negative.y;
        }
    }

    void MoveTowardsSupposedPosition()
    {
        Vector2 supposedPosition = (minPlayersPosition + maxPlayersPosition) / 2;
        Vector2 distanceToSupposedPosition = supposedPosition - (Vector2)this.transform.position;
        CameraOffset bigOffset = new CameraOffset(distanceFromBigOffsetX, offsetCenter);
        CameraOffset smallOffset = new CameraOffset(distanceFromSmallOffsetX, offsetCenter);
        if (bigOffset.isOutOfBoundariesX(supposedPosition, (Vector2)this.transform.position))
        {
            float offsetEdgeX = (distanceToSupposedPosition.x > bigOffset.positive.x) ? bigOffset.positive.x : bigOffset.negative.x;
            this.transform.position = new Vector3(supposedPosition.x - offsetEdgeX, this.transform.position.y, this.transform.position.z);
        }
        else if (smallOffset.isOutOfBoundariesX(supposedPosition, (Vector2)this.transform.position))
        {
            float changeOnX = Time.deltaTime * followingSpeed;
            if (distanceToSupposedPosition.x < smallOffset.negative.x) changeOnX *= -1;
            this.transform.position += new Vector3(changeOnX, 0, 0);
        }
        if (bigOffset.isOutOfBoundariesY(supposedPosition, (Vector2)this.transform.position))
        {
            float offsetEdgeY = (distanceToSupposedPosition.y > bigOffset.positive.y) ? bigOffset.positive.y : bigOffset.negative.y;
            this.transform.position = new Vector3(this.transform.position.x, supposedPosition.y - offsetEdgeY, this.transform.position.z);
        }
        else if (smallOffset.isOutOfBoundariesY(supposedPosition, (Vector2)this.transform.position))
        {
            float changeOnY = Time.deltaTime * followingSpeed;
            if (distanceToSupposedPosition.y < smallOffset.negative.y) changeOnY *= -1;
            this.transform.position += new Vector3(0, changeOnY, 0);
        }
    }

    private void SetCameraSize()
    {
        float yDistance = (maxPlayersPosition.y - minPlayersPosition.y),
              xDistance = (maxPlayersPosition.x - minPlayersPosition.x);
        float maxDistance = Mathf.Max(yDistance, xDistance * Screen.height / Screen.width);
        myCamera.orthographicSize = sizeMargin + maxDistance / 2;
    }
}