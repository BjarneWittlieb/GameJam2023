using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomGeneration
{
    public class RoomSettings
    {
        public int TotalEnemyScore { get; set; }
        public int MaximalEnemyBatchScore { get; set; }
        public int TotalObstacleScore { get; set; }
        public int MaximalObstacleBatchScore { get; set; }
        
        public RoomSettings() { }

        public RoomSettings(int roomDifficulty = 1)
        {
            TotalEnemyScore = 10 + roomDifficulty * 5;
            MaximalEnemyBatchScore = 5 + roomDifficulty * 2;

            TotalObstacleScore = 3 + roomDifficulty * 3;
            MaximalObstacleBatchScore = 1 + roomDifficulty;
        }
    }
}
