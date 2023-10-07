using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RoomGeneration
{
    public class Room
    {
        private List<RoomObject> objects;
        private Transform levelRoot;

        public RoomReward RoomReward { get; private set; }

        public Room(Transform levelRoot, RoomReward reward)
        {
            this.levelRoot = levelRoot;
            objects = new List<RoomObject>();
            this.RoomReward = reward;
        }

        public void AddRoomObject(RoomObject roomObject)
        {
            objects.Add(roomObject);
        }

        public virtual void PopulateEnemies() { 
            foreach (RoomObject roomObject in objects.Where(ro => ro.Type == RoomObjectType.Enemy)) 
            {
                roomObject.AddToScene(levelRoot);
            }
            ProgressionTracking.Instance.ResetEnemyCountTo(objects.Count());
        }

        public virtual void PopulateObstacles()
        {
            foreach(RoomObject roomObject in objects.Where(ro => ro.Type == RoomObjectType.Obstacle))
            {
                roomObject.AddToScene(levelRoot);
            }
        }

        public void DestroyRoom()
        {
            foreach (var roomObject in objects)
            {
                roomObject.RemoveFromScene();
            }
        }
    }
}
