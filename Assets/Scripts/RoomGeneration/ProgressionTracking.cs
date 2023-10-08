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

    public Room CurrentRoom { get; private set; }

    public void Initialize(RoomCreator roomCreator)
    {
        this.roomCreator = roomCreator;
        RoomState = RoomState.None;
    }

    public void SetCurrentRoom(Room room)
    {
        CurrentRoom= room;
    }

    public void ResetEnemyCountTo(int enemyCount)
    {
        this.enemyCount = enemyCount;
        RoomState = RoomState.Fighting;

        Debug.Log("RESET COUNT TO " + this.enemyCount);
    }

    public void KillEnemy() {
        enemyCount --;

        if (enemyCount <= 0) {
            roomCreator.SpawnRoomItem();
            RoomState = RoomState.CollectingItem;
        }

        Debug.Log("ENEMY KILLED NOW COUNT " + enemyCount);
    }

    public void ItemCollected()
    {
        roomCreator.OpenNextRooms();
        RoomState = RoomState.NextRoomOpen;
    }
}
