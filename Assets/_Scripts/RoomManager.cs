using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [System.Serializable]
    public struct RoomPrefab
    {
        public string name;
        public GameObject prefab;
    }

    [Header("Room Prefabs")]
    public List<RoomPrefab> roomPrefabs;

    [Header("Generation Settings")]
    public Vector2 roomSize = new Vector2(16, 11); // each room size in tiles
    public Transform player;

    // internal tracking
    private Dictionary<Vector2Int, GameObject> loadedRooms = new Dictionary<Vector2Int, GameObject>();
    private Vector2Int currentRoom = Vector2Int.zero;

    private void Start()
    {
        // Spawn the first room at origin
        SpawnRoom(currentRoom);
    }

    public void MoveToRoom(Vector2Int direction)
    {
        Vector2Int nextPos = currentRoom + direction;

        // remove old room optionally (for arcade effect)
        UnloadRoom(currentRoom);

        if (!loadedRooms.ContainsKey(nextPos))
        {
            SpawnRoom(nextPos);
        }

        currentRoom = nextPos;
    }

    private void SpawnRoom(Vector2Int position)
    {
        if (roomPrefabs.Count == 0)
        {
            Debug.LogError("No room prefabs assigned!");
            return;
        }

        // Pick random prefab
        RoomPrefab randomRoom = roomPrefabs[Random.Range(0, roomPrefabs.Count)];

        Vector3 worldPos = new Vector3(position.x * roomSize.x, position.y * roomSize.y, 0);
        GameObject newRoom = Instantiate(randomRoom.prefab, worldPos, Quaternion.identity);
        loadedRooms.Add(position, newRoom);
    }

    private void UnloadRoom(Vector2Int pos)
    {
        if (loadedRooms.TryGetValue(pos, out GameObject room))
        {
            Destroy(room);
            loadedRooms.Remove(pos);
        }
    }
}
