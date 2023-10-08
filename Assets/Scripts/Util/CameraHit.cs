using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Util
{
    public class CameraHit : MonoBehaviour
    {
        public float screenShakeTime = .3f;
        public float factor = 1f;

        private void Start()
        {
            Health.OnPlayerHit += StartShake;
        }

        private void OnDisable()
        {
            Health.OnPlayerHit -= StartShake;
        }

        private void StartShake()
        {
            StartCoroutine(Shaking());
        }

        private IEnumerator<object> Shaking()
        {
            var startPos = transform.position;
            var elapsedTime = 0f;

            while (elapsedTime < screenShakeTime)
            {
                elapsedTime += Time.deltaTime;
                transform.position = startPos += factor * .1f * Random.insideUnitSphere;
                yield return null;
            }

            transform.position = startPos;
        }
    }
}