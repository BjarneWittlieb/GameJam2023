﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Util.RoomGeneration;

namespace RoomGeneration
{
    public static class RoomFactory
    {
        public static Room CreateRoom(Transform levelRoot, RoomSettings settings) {
            var room = new Room(levelRoot);

            PopulateRoom(room, levelRoot, settings.TotalEnemyScore, settings.MaximalEnemyBatchScore, RoomObject.Enemies);
            PopulateRoom(room, levelRoot, settings.TotalObstacleScore, settings.MaximalObstacleBatchScore, new RoomObject[] { });

            return room;
        }

        private static void PopulateRoom(Room room, Transform levelRoot, int maximumScore, int maximumBatchScore, RoomObject[] ojbects)
        {
            int scoreLeft = maximumScore;
            while (true)
            {
                var availableObjects = RoomObject.Enemies.Where(e => e.DifficultyScore < scoreLeft && e.DifficultyScore < maximumBatchScore);
                if (!availableObjects.Any())
                {
                    break;
                }
                var roomObject = availableObjects.ElementAt(UnityEngine.Random.Range(0, availableObjects.Count()));
                room.AddRoomObject(roomObject);
            }
        }
    }
}