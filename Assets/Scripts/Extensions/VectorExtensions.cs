using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class VectorExtensions
    {
        public static Vector2 ToIsometric(this Vector2 vector) {
            return Vector2.Scale(vector, new Vector2(1, .5f));
        }

        public static Vector3 ToIsometric(this Vector3 vector)
        {
            return Vector3.Scale(vector, new Vector3(1, .5f, 1));
        }

        public static float GetIsometricSpeedModifier(this Vector2 direction)
        {
            var norm = direction.normalized;
            return .5f + norm.x / 2f;
        }
    }
}
