using RoomGeneration;
using UnityEngine;

public class LevelDoor : MonoBehaviour
{
    public RoomCreator creator;

    private bool isEnterable;

    private Room myRoom;
    private SpriteRenderer spriteRenderer;

    public void Reset()
    {
        isEnterable = false;
        if (spriteRenderer == null)
            return;
        spriteRenderer.color = Color.black;
    }

    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Reset();
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (!isEnterable || other.gameObject.name != "Player") return;

        isEnterable = false;
        creator.DestroyAndBuildRoom(myRoom);
    }

    public void SetAccordingTo(Room room)
    {
        if (room.RoomReward.IsGood)
            spriteRenderer.color = Color.green;
        else
            spriteRenderer.color = Color.red;

        myRoom = room;
        isEnterable = true;
    }
}