using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionTracking
{
    public static ProgressionTracking Instance = new ProgressionTracking();

    private int enemyCount = -1;

    RoomCreator roomCreator;

    public void Initialize(RoomCreator roomCreator)
    {
        this.roomCreator = roomCreator;
    }

    public void ResetEnemyCountTo(int enemyCount)
    {
        this.enemyCount = enemyCount;
    }

    public void KillEnemy() {
        enemyCount --;

        if (enemyCount <= 0) {
            this.roomCreator.DestroyAndBuildRoom();
        }
    }
}
