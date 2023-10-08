namespace RoomGeneration
{
    public class RoomSettings
    {
        public RoomSettings()
        {
        }

        public RoomSettings(int roomDifficulty = 1)
        {
            TotalEnemyScore = 10 + roomDifficulty * 5;
            MaximalEnemyBatchScore = 5 + roomDifficulty * 2;

            TotalObstacleScore = 1 + roomDifficulty;
            MaximalObstacleBatchScore = 1 + roomDifficulty;
        }

        public int TotalEnemyScore { get; set; }
        public int MaximalEnemyBatchScore { get; set; }
        public int TotalObstacleScore { get; set; }
        public int MaximalObstacleBatchScore { get; set; }
    }
}