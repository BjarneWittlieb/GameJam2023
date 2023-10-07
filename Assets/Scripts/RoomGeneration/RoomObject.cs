using System.IO;
using UnityEngine;

namespace RoomGeneration
{
    public class RoomObject
    {
        public static RoomObject[] Enemies =
        {
            AllObjects.Enemies.MeleeGroup3Near,
            AllObjects.Enemies.MeleeGroup3Far,
            AllObjects.Enemies.MeleeAloneNear,
            AllObjects.Enemies.MeleeAloneFar,
            AllObjects.Enemies.RangeAlone,
            AllObjects.Enemies.RangeGroup,
            AllObjects.Enemies.AoEAlone
        };

        private GameObject addedObject;

        protected Vector2[] positions;

        public RoomObject(string path, Vector2 position, int difficulty = 0, RoomObjectType type = RoomObjectType.Agent)
        {
            PrefabPath = path;
            positions = new[] { position };
            DifficultyScore = difficulty;
        }

        public RoomObject(string path, Vector2[] positions, int difficulty = 0,
            RoomObjectType type = RoomObjectType.Agent)
        {
            PrefabPath = path;
            this.positions = positions;
            DifficultyScore = difficulty;
        }

        public RoomObjectType Type { get; }

        private string PrefabPath { get; }

        private Object loadedPrefab { get; set; }

        public int DifficultyScore { get; private set; }

        public virtual void AddToScene(Transform levelRoot)
        {
            addedObject = Object.Instantiate(LoadPrefab(), levelRoot) as GameObject;
            var position = positions[Random.Range(0, positions.Length)];
            addedObject.transform.position = new Vector3(position.x, position.y, addedObject.transform.position.z);
        }

        private Object LoadPrefab()
        {
            // Cache objects in memory, so loading becomes faster
            if (loadedPrefab != null) return loadedPrefab;

            var loadedObject = Resources.Load("LevelPrefabians/" + PrefabPath);
            if (loadedObject == null) throw new FileNotFoundException("No file at " + PrefabPath);
            if (loadedPrefab == null) loadedPrefab = loadedObject;

            return loadedObject;
        }

        public void RemoveFromScene()
        {
            Object.Destroy(addedObject);
        }

        public static class AllObjects
        {
            public static class Enemies
            {
                public static RoomObject MeleeGroup3Far = new(
                    "EnemyPatterns/MeleeGroup3",
                    new Vector2[] { new(1.14f, .58f), new(5.57f, -5.25f) },
                    6
                );

                public static RoomObject MeleeGroup3Near = new(
                    "EnemyPatterns/MeleeGroup3",
                    new Vector2[] { new(-4.22f, -7.04f), new(-3.03f, -10.35f) },
                    9
                );

                public static RoomObject MeleeAloneFar = new(
                    "EnemyPatterns/MeleeAlone",
                    new Vector2[]
                    {
                        new(5.67f, 4.31f),
                        new(5.93f, -1.54f),
                        new(4.01f, 2.93f),
                        new(.89f, 1.14f)
                    },
                    2
                );

                public static RoomObject MeleeAloneNear = new(
                    "EnemyPatterns/MeleeAlone",
                    new Vector2[] { new(-3.81f, -4.85f), new(-10.84f, -1.7f) },
                    2
                );

                public static RoomObject RangeAlone = new(
                    "EnemyPatterns/RangeAlone",
                    new Vector2[]
                    {
                        new(5.67f, 4.31f),
                        new(5.93f, -1.54f),
                        new(4.01f, 2.93f),
                        new(.89f, 1.14f)
                    },
                    2);

                public static RoomObject RangeGroup = new(
                    "EnemyPatterns/RangeGroup",
                    new Vector2[]
                    {
                        new(5.67f, 4.31f),
                        new(5.93f, -1.54f),
                        new(4.01f, 2.93f),
                        new(.89f, 1.14f)
                    },
                    3);

                public static RoomObject AoEAlone = new(
                    "EnemyPatterns/AoEAlone",
                    new Vector2[]
                    {
                        new(5.67f, 4.31f),
                        new(5.93f, -1.54f),
                        new(4.01f, 2.93f),
                        new(.89f, 1.14f)
                    },
                    3);
            }

            public static class Obstacles
            {
            }
        }
    }
}