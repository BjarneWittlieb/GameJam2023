using System;
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
            
            int enemyScoreLeft = settings.TotalObstacleScore;
            


            while (true)
            {
                var availableEnemies = RoomObject.Enemies.Where(e => e.DifficultyScore < enemyScoreLeft);
                if (!availableEnemies.Any()) {
                    break;
                }
                var enemy = availableEnemies.ElementAt(UnityEngine.Random.Range(0, availableEnemies.Count()));
                
            }

            return room;
        }


    }
}
