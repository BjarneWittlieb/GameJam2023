using NavMeshPlus.Components;
using RoomGeneration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomContentCreation : MonoBehaviour
{
    public NavMeshSurface navMesh;

    // Start is called before the first frame update
    void Start()
    {
        Room room = RoomFactory.CreateRoom(this.transform, new RoomGeneration.RoomSettings(1));

        room.PopulateObstacles();

        navMesh.BuildNavMesh();

        room.PopulateAgents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
