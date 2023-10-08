using System.Linq;
using UnityEngine;

namespace RoomGeneration
{
    public static class RoomFactory
    {
        public static Room CreateRoom(Transform levelRoot, RoomSettings settings)
        {
            var room = new Room(levelRoot, GetRoomReward());

            PopulateRoom(room, settings.TotalEnemyScore, settings.MaximalEnemyBatchScore, RoomObject.Enemies);
            PopulateRoom(room, settings.TotalObstacleScore, settings.MaximalObstacleBatchScore, RoomObject.Obstacles);

            return room;
        }

        private static RoomReward GetRoomReward()
        {
            return RoomReward.Rewards.ElementAt(Random.Range(0, RoomReward.Rewards.Length));
        }

        private static void PopulateRoom(Room room, int maximumScore, int maximumBatchScore, RoomObject[] ojbects)
        {
            var scoreLeft = maximumScore;
            while (true)
            {
                var availableObjects = ojbects.Where(e =>
                    e.DifficultyScore < scoreLeft && e.DifficultyScore < maximumBatchScore);
                if (!availableObjects.Any()) break;
                var roomObject = availableObjects.ElementAt(Random.Range(0, availableObjects.Count()));
                room.AddRoomObject(roomObject);
                scoreLeft -= roomObject.DifficultyScore;
            }
        }
    }
}