using RoomGeneration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionTracking
{
    public static ProgressionTracking Instance = new ProgressionTracking();

    private int enemyCount = -1;

    RoomCreator roomCreator;

    public RoomState RoomState { get; private set; }

    public void Initialize(RoomCreator roomCreator)
    {
        this.roomCreator = roomCreator;
        RoomState = RoomState.None;
    }

    public void ResetEnemyCountTo(int enemyCount)
    {
        this.enemyCount = enemyCount;
        RoomState = RoomState.Fighting;
    }

    public void KillEnemy() {
        enemyCount --;

        if (enemyCount <= 0) {
            roomCreator.SpawnRoomItem();
            RoomState = RoomState.CollectingItem;
        }
    }

    public void ItemCollected()
    {
        roomCreator.OpenNextRooms();
        RoomState = RoomState.NextRoomOpen;
    }
}
