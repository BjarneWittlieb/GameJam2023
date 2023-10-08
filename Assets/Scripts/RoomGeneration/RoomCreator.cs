using NavMeshPlus.Components;
using RoomGeneration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCreator : MonoBehaviour
{
    public NavMeshSurface navMesh;

    private GameObject player;
    private Vector3 playerStartPos;

    private Room room;
    public float startingDifficulty = 1f;
    private float currentDifficulty;

    public LevelDoor levelDoor1;
    public LevelDoor levelDoor2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerStartPos = player.transform.position;

        currentDifficulty = startingDifficulty;

        ProgressionTracking.Instance.Initialize(this);

        DestroyAndBuildRoom(GetRoom());
    }

    public void SpawnRoomItem()
    {
        Instantiate(room.RoomReward.GetRewardItem(), transform);
    }

    private Room GetRoom()
    {
        return RoomFactory.CreateRoom(this.transform, new RoomSettings((int)currentDifficulty));
    }

    public void DestroyAndBuildRoom(Room newRoom)
    {
        if (room != null)
        {
            room.DestroyRoom();
        }
        room = newRoom;

        room.PopulateObstacles();
        navMesh.BuildNavMesh();
        room.PopulateEnemies();

        player.transform.position = playerStartPos;

        levelDoor1.Reset();
        levelDoor2.Reset();

        currentDifficulty++;
    }

    public void OpenNextRooms()
    {
        levelDoor1.SetAccordingTo(GetRoom());
        levelDoor2.SetAccordingTo(GetRoom());
    }
}
