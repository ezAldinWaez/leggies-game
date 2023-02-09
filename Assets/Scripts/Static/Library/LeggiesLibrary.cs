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

        public static Vector2 RandomDirectionUnitVector2()
        {
            float angle = Random.Range(0.0f, 2 * Mathf.PI);
            return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }
    }

    class LeggiesSounds
    {
        public static void PlaySoundFrom(AudioClip audioClip)
        {
            if (audioClip == null)
            {
                Debug.Log("The audio clip is null.");
                return;
            }
            GameObject sounder = new GameObject();
            AudioSource source = sounder.AddComponent<AudioSource>();
            source.playOnAwake = false;
            source.clip = audioClip;
            source.Play(0);
            Object.Destroy(sounder, source.clip.length);
        }

        public static void PlayRandomSoundFrom(AudioClip[] audioClips)
        {
            AudioClip audioClip = audioClips[new System.Random().Next(0, audioClips.Length)];
            PlaySoundFrom(audioClip);
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