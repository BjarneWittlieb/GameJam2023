﻿using System.IO;
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
            AllObjects.Enemies.RangedAlone,
            AllObjects.Enemies.RangedGroup,
            AllObjects.Enemies.AoEAlone
        };

        public static RoomObject[] Obstacles =
        {
            AllObjects.Obstacles.Obstacle
        };

        public static RoomObject Boss = new(
            "EnemyPatterns/Boss", new Vector2(1f, 1f), 10);

        private GameObject addedObject;

        protected Vector2[] positions;

        public RoomObject(string path, Vector2 position, int difficulty = 0, RoomObjectType type = RoomObjectType.Enemy)
        {
            PrefabPath = path;
            positions = new[] { position };
            DifficultyScore = difficulty;
            ObjectNumber = 1;
        }

        public RoomObject(string path, Vector2[] positions, int difficulty = 0,
            RoomObjectType type = RoomObjectType.Enemy, int objectNumber = 1)
        {
            PrefabPath = path;
            this.positions = positions;
            DifficultyScore = difficulty;
            ObjectNumber = objectNumber;
            Type = type;
        }

        public RoomObjectType Type { get; }
        public int ObjectNumber { get; }

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
                    new Vector2[] { new(3.14f, .58f), new(5.57f, -5.25f) },
                    6, objectNumber: 3
                );

                public static RoomObject MeleeGroup3Near = new(
                    "EnemyPatterns/MeleeGroup3",
                    new Vector2[] { new(-4.22f, -7.04f), new(-3.03f, -10.35f) },
                    9, objectNumber: 3
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
                    new Vector2[] { new(-1.81f, -4.85f), new(-10.84f, -1.7f) },
                    2
                );

                public static RoomObject RangedAlone = new(
                    "EnemyPatterns/RangeAlone",
                    new Vector2[]
                    {
                        new(5.67f, 4.31f),
                        new(5.93f, -1.54f),
                        new(4.01f, 2.93f),
                        new(3.1f, 1.14f)
                    },
                    2
                );

                public static RoomObject RangedGroup = new(
                    "EnemyPatterns/RangeGroup",
                    new Vector2[]
                    {
                        new(5.67f, 4.31f),
                        new(5.93f, -1.54f),
                        new(4.01f, 2.93f),
                        new(4.2f, 1.14f)
                    },
                    10,
                    objectNumber: 3
                );

                public static RoomObject RangedBoss = new(
                    "EnemyPatterns/RangeHard",
                    new Vector2[]
                    {
                        new(5.67f, 4.31f),
                        new(5.93f, -1.54f),
                        new(4.01f, 2.93f),
                        new(4.0f, 1.14f)
                    },
                    15
                );

                public static RoomObject AoEAlone = new(
                    "EnemyPatterns/AoEAlone",
                    new Vector2[]
                    {
                        new(5.67f, 4.31f),
                        new(5.93f, -1.54f),
                        new(4.01f, 2.93f)
                    },
                    7
                );
            }

            public static class Obstacles
            {
                public static RoomObject Obstacle = new(
                    "ObstaclePatterns/Obstacle",
                    new Vector2[]
                    {
                        new(-8.5f, 0.36f),
                        new(3.39f, -0.9f),
                        new(-1.63f, -4.8f),
                        new(8.32f, 0.36f),
                        new(0.14f, 4.9f),
                        new(1.67f, -0.9f),
                        new(4.08f, 5f),
                        new(-6.51f, -0.9f)
                    },
                    1,
                    RoomObjectType.Obstacle
                );
            }
        }
    }
}