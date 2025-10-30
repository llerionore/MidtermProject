using UnityEngine;

public class RoomTransfer : MonoBehaviour
{
    public Vector2Int moveDirection;
    public Vector2 cameraChange;
    public Vector3 playerChange;

    private CameraMovement cam;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        cam.MoveCamera(cameraChange);
        collision.transform.position += playerChange;

        RoomManager.Instance.MoveToRoom(moveDirection);
    }
}
