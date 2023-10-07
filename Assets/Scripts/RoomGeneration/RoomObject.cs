using System.IO;
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
                    "EnemyPatterns/MeleeGroup3",
                    new Vector2[] { new Vector2(1.14f, .58f), new Vector2(5.57f, -5.25f) }, 
                    6
                );
                public static RoomObject MeleeGroup3Near = new RoomObject(
                    "EnemyPatterns/MeleeGroup3", 
                    new Vector2[] { new Vector2(-4.22f, -7.04f), new Vector2(-3.03f, -10.35f) }, 
                    9
                );
                public static RoomObject MeleeAloneFar = new RoomObject(
                    "EnemyPatterns/MeleeAlone",
                    new Vector2[] {
                        new Vector2(5.67f, 4.31f),
                        new Vector2(5.93f, -1.54f),
                        new Vector2(4.01f, 2.93f),
                        new Vector2(.89f, 1.14f)
                    },
                    2
                );
                public static RoomObject MeleeAloneNear = new RoomObject(
                    "EnemyPatterns/MeleeAlone", 
                    new Vector2[] { new Vector2(-3.81f, -4.85f), new Vector2(-10.84f, -1.7f) },
                    2
                );
            }

            public static class Obstacles
            {

            }
        }

        public RoomObjectType Type { get; private set; }

        protected UnityEngine.Vector2[] positions;

        private string PrefabPath { get; set; }

        private UnityEngine.Object loadedPrefab { get; set; }

        public int DifficultyScore { get; private set; }

        private GameObject addedObject;

        public RoomObject(string path, UnityEngine.Vector2 position, int difficulty = 0, RoomObjectType type = RoomObjectType.Agent)
        {
            this.PrefabPath = path;
            this.positions = new UnityEngine.Vector2[] { position };
            DifficultyScore = difficulty;
        }

        public RoomObject(string path, UnityEngine.Vector2[] positions, int difficulty = 0, RoomObjectType type = RoomObjectType.Agent)
        {
            this.PrefabPath = path;
            this.positions = positions;
            DifficultyScore = difficulty;
        }

        public virtual void AddToScene(Transform levelRoot)
        {
            addedObject = UnityEngine.Object.Instantiate(LoadPrefab(), levelRoot) as GameObject;
            var position = positions[UnityEngine.Random.Range(0, positions.Length)];
            addedObject.transform.position = new UnityEngine.Vector3(position.x, position.y, addedObject.transform.position.z);
        }

        private UnityEngine.Object LoadPrefab()
        {
            // Cache objects in memory, so loading becomes faster
            if (this.loadedPrefab != null) return this.loadedPrefab;

            var loadedObject = Resources.Load("LevelPrefabians/" + PrefabPath);
            if (loadedObject == null)
            {
                throw new FileNotFoundException("No file at " + PrefabPath);
            }
            if (this.loadedPrefab == null)
            {
                this.loadedPrefab = loadedObject;
            }

            return loadedObject;
        }

        public void RemoveFromScene()
        {
            GameObject.Destroy(addedObject);
        }
    }
}
