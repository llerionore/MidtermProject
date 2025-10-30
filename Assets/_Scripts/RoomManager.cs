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

    public static RoomManager Instance;

    [Header("Room Prefabs")]
    public List<RoomPrefab> roomPrefabs;

    [Header("Settings")]
    public Vector2 roomSize = new Vector2(16, 11);
    public Transform player;

    private Dictionary<Vector2Int, GameObject> loadedRooms = new Dictionary<Vector2Int, GameObject>();
    private HashSet<string> clearedRooms = new HashSet<string>();
    private Vector2Int currentRoom = Vector2Int.zero;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        SpawnRoom(currentRoom);
    }

    public void MoveToRoom(Vector2Int direction)
    {
        Vector2Int next = currentRoom + direction;

        if (!loadedRooms.ContainsKey(next))
            SpawnRoom(next);

        currentRoom = next;
    }

    private void SpawnRoom(Vector2Int pos)
    {
        RoomPrefab random = roomPrefabs[Random.Range(0, roomPrefabs.Count)];
        Vector3 worldPos = new Vector3(pos.x * roomSize.x, pos.y * roomSize.y, 0);
        GameObject newRoom = Instantiate(random.prefab, worldPos, Quaternion.identity);

        loadedRooms.Add(pos, newRoom);

        EnemyGenerator gen = newRoom.GetComponentInChildren<EnemyGenerator>();
        if (gen != null)
            gen.roomID = pos.ToString(); // coordinate = unique room id
    }

    public bool IsRoomCleared(string id)
    {
        return clearedRooms.Contains(id);
    }

    public void MarkRoomCleared(string id)
    {
        clearedRooms.Add(id);
    }
}
