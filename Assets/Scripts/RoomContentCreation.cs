using NavMeshPlus.Components;
using RoomGeneration;
using UnityEngine;

public class RoomContentCreation : MonoBehaviour
{
    public NavMeshSurface navMesh;
    public int difficulty = 1;

    // Start is called before the first frame update
    private void Start()
    {
        var room = RoomFactory.CreateRoom(transform, new RoomSettings(difficulty));

        room.PopulateObstacles();

        navMesh.BuildNavMesh();

        room.PopulateAgents();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}