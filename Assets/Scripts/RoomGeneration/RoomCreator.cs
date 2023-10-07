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


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerStartPos = player.transform.position;

        currentDifficulty = startingDifficulty;

        ProgressionTracking.Instance.Initialize(this);

        DestroyAndBuildRoom();
    }

    public void SpawnRoomItem()
    {
        Instantiate(room.RoomReward.GetRewardItem(), transform);
    }

    public void DestroyAndBuildRoom()
    {
        if (room != null)
        {
            room.DestroyRoom();
        }
        room = RoomFactory.CreateRoom(this.transform, new RoomSettings((int)currentDifficulty));

        room.PopulateObstacles();
        navMesh.BuildNavMesh();
        room.PopulateEnemies();

        currentDifficulty++;
    }

    public void OpenNextRooms()
    {

    }
}
