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

        public Room(Transform levelRoot)
        {
            this.levelRoot = levelRoot;
            objects = new List<RoomObject>();
        }

        public void AddRoomObject(RoomObject roomObject)
        {
            objects.Add(roomObject);
        }

        public virtual void PopulateAgents() { 
            foreach (RoomObject roomObject in objects.Where(ro => ro.Type == RoomObjectType.Agent)) 
            {
                roomObject.AddToScene(levelRoot);
            }
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
