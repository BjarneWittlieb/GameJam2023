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

        public virtual void AddToScene()
        {
            foreach(RoomObject roomObject in objects)
            {
                roomObject.AddToScene(levelRoot);
            }
        }
    }
}
