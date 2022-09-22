using UnityEngine;

namespace LeggiesLibrary
{
    class Math
    {
        public static Vector3 ShakeBaseVector(Vector3 baseVector, float shakeMin, float shakeMax)
        {
            float shakeLen = Random.Range(shakeMin, shakeMax);
            return baseVector + Vector3.one * shakeLen;
        }
    }

}