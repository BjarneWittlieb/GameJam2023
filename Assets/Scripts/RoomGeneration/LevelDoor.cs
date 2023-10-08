using RoomGeneration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoor : MonoBehaviour
{
    public RoomCreator creator;
    private SpriteRenderer spriteRenderer;

    private bool isEnterable = false;

    private Room myRoom;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Reset();
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (!isEnterable || other.gameObject.name != "Player") {
            return;
        }

        isEnterable = false;
        creator.DestroyAndBuildRoom(myRoom);
    }

    public void Reset()
    {
        spriteRenderer.color = Color.black;
        isEnterable = false;
    }

    public void SetAccordingTo(Room room)
    {
        if (room.RoomReward.IsGood)
        {
            spriteRenderer.color = Color.green;
        } else
        {
            spriteRenderer.color = Color.red;
        }

        myRoom = room;
        isEnterable = true;
    }
}
