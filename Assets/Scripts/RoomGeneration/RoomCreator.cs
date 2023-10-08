using NavMeshPlus.Components;
using RoomGeneration;
using UnityEngine;

public class RoomCreator : MonoBehaviour
{
    public NavMeshSurface navMesh;
    public float startingDifficulty = 1f;
    private float currentDifficulty;

    private GameObject player;
    private Vector3 playerStartPos;

    private Room room;

    public LevelDoor levelDoor1;
    public LevelDoor levelDoor2;

    // Start is called before the first frame update
    private void Start()
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
        if (room != null) room.DestroyRoom();
        room = RoomFactory.CreateRoom(transform, new RoomSettings((int)currentDifficulty));

        room.PopulateObstacles();
        Physics2D.SyncTransforms();
        navMesh.BuildNavMesh();
        navMesh.BuildNavMeshAsync();

        //collectSources2d.room;
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