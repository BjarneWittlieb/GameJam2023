using Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Util
{


    public class CameraHit : MonoBehaviour
    {
        public float screenShakeTime = .3f;
        public float factor = 1f;

        void Start()
        {
            Health.OnPlayerHit += StartShake;
        }

        void StartShake()
        {
            StartCoroutine(Shaking());
        }

        IEnumerator<object> Shaking()
        {
            Vector3 startPos = transform.position;
            float elapsedTime = 0f;

            while (elapsedTime < screenShakeTime)
            {
                elapsedTime+= Time.deltaTime;
                transform.position = startPos += (factor * .1f *  UnityEngine.Random.insideUnitSphere);
                yield return null;
            }

            transform.position = startPos;
        }

    }
}
