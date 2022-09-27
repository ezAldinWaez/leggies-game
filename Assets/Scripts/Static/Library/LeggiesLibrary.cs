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

}