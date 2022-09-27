using UnityEngine;

namespace LeggiesLibrary
{
    class LeggiesMath
    {
        public static Vector3 ShakeVector3(Vector3 vector, float shakeMin, float shakeMax)
        {
            float shakeLen = Random.Range(shakeMin, shakeMax);
            return vector + Vector3.one * shakeLen;
        }
    }

    class LeggiesCameraOffset
    {
        public Vector2 center { get; private set; }
        public Vector2 distanceFromEdge { get; private set; }
        public Vector2 positive { get; private set; }
        public Vector2 negative { get; private set; }
        public LeggiesCameraOffset(float distanceFromEdgeX, Vector2 offsetCenter)
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

}