using UnityEngine;

namespace RoomGeneration
{
    public class RoomObject
    {
        public static RoomObject[] Enemies = new RoomObject[]
        {
                AllObjects.Enemies.MeleeGroup3Near,
                AllObjects.Enemies.MeleeGroup3Far,
                AllObjects.Enemies.MeleeAloneNear,
                AllObjects.Enemies.MeleeAloneFar
        };

        public static class AllObjects
        {
            public static class Enemies
            {
                public static RoomObject MeleeGroup3Far = new RoomObject(
                    "MeleeGroup3",
                    new Vector2[] { new Vector2(-1.9f, -.15f), new Vector2(2.79f, -2.58f) }, 
                    6
                );
                public static RoomObject MeleeGroup3Near = new RoomObject(
                    "MeleeGroup3", 
                    new Vector2[] { new Vector2(-7.67f, -3.71f), new Vector2(-5.08f, -7.27f) }, 
                    9
                );
                public static RoomObject MeleeAloneFar = new RoomObject(
                    "MeleeAlone",
                    new Vector2[] {
                        new Vector2(-1.48f, 3.4f),
                        new Vector2(-0.95f, 0.01f),
                        new Vector2(-6.36f, 4.98f),
                        new Vector2(1.8f, 6.43f)
                    },
                    2
                );
                public static RoomObject MeleeAloneNear = new RoomObject(
                    "MeleeAlone", 
                    new Vector2[] { new Vector2(-9.31f, .94f), new Vector2(-5.27f, .29f) },
                    2
                );
            }

            public static class Obstacles
            {

            }
        }

        protected UnityEngine.Vector2[] positions;

        private string PrefabPath { get; set; }

        public int DifficultyScore { get; private set; }

        public RoomObject(string path, UnityEngine.Vector2 position, int difficulty = 0)
        {
            this.PrefabPath = path;
            this.positions = new UnityEngine.Vector2[] { position };
            DifficultyScore = difficulty;
        }

        public RoomObject(string path, UnityEngine.Vector2[] positions, int difficulty = 0)
        {
            this.PrefabPath = path;
            this.positions = positions;
            DifficultyScore = difficulty;
        }

        public virtual void AddToScene(Transform levelRoot)
        {
            var addedObject = UnityEngine.Object.Instantiate(Resources.Load("LevelPrefabians/" + PrefabPath), levelRoot) as GameObject;
            var position = positions[UnityEngine.Random.Range(0, positions.Length)];
            addedObject.transform.position = new UnityEngine.Vector3(position.x, position.y, addedObject.transform.position.z);
        }
    }
}
