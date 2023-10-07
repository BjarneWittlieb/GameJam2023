using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomContent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var room = RoomGeneration.RoomFactory.CreateRoom(this.transform, new RoomGeneration.RoomSettings(1));
        room.AddToScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
