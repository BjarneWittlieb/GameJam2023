using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoomGeneration
{
    public class Room
    {
        private readonly Transform levelRoot;
        private readonly List<RoomObject> objects;

        public bool IsGood { get => RoomReward.IsGood;  }

        public Room(Transform levelRoot, RoomReward reward)
        {
            this.levelRoot = levelRoot;
            objects = new List<RoomObject>();
            RoomReward = reward;
        }

        public RoomReward RoomReward { get; private set; }

        public void AddRoomObject(RoomObject roomObject)
        {
            objects.Add(roomObject);
        }

        public virtual void PopulateEnemies()
        {
            var enemiesCount = 0;
            foreach (var roomObject in objects.Where(ro => ro.Type == RoomObjectType.Enemy))
            {
                roomObject.AddToScene(levelRoot);
                enemiesCount += roomObject.ObjectNumber;
            }

            ProgressionTracking.Instance.ResetEnemyCountTo(enemiesCount);
        }

        public virtual void PopulateObstacles()
        {
            foreach (var roomObject in objects.Where(ro => ro.Type == RoomObjectType.Obstacle))
                roomObject.AddToScene(levelRoot);
        }

        public void DestroyRoom()
        {
            foreach (var roomObject in objects) roomObject.RemoveFromScene();
        }
    }
}