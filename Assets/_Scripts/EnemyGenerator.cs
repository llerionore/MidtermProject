using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject[] enemyPrefabs;

    public int minEnemies = 2;
    public int maxEnemies = 5;

    public Vector2 spawnMin = new Vector2(-4, -2);
    public Vector2 spawnMax = new Vector2(4, 2);

    public LayerMask obstacleMask;
    public LayerMask enemyMask;
    public float checkRadius = 0.05f;
    public int maxAttemptsPerEnemy = 100;  

    [HideInInspector] public string roomID;

    private readonly List<GameObject> enemies = new List<GameObject>();
    private bool isCleared;

    public void Initialize(string id, Transform roomParent)
    {
        roomID = id;

        if (RoomManager.Instance.IsRoomCleared(roomID))
        {
            isCleared = true;
            return;
        }

        int targetCount = Random.Range(minEnemies, maxEnemies + 1);

        for (int i = 0; i < targetCount; i++)
        {
            Vector3? spawnPoint = FindFreePoint();
            if (spawnPoint == null)
            {
                continue;
            }

            GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            GameObject e = Instantiate(prefab, spawnPoint.Value, Quaternion.identity, roomParent);
            enemies.Add(e);
        }

        if (enemies.Count > 0)
            StartCoroutine(CheckCleared());
    }

    private Vector3? FindFreePoint()
    {
        for (int attempt = 0; attempt < maxAttemptsPerEnemy; attempt++)
        {
            float x = Random.Range(spawnMin.x, spawnMax.x);
            float y = Random.Range(spawnMin.y, spawnMax.y);
            Vector3 world = transform.position + new Vector3(x, y, 0);

            bool hitsWall = Physics2D.OverlapCircle(world, checkRadius, obstacleMask);
            if (hitsWall) continue;

            bool hitsEnemy = Physics2D.OverlapCircle(world, checkRadius, enemyMask);
            if (hitsEnemy) continue;

            return world;
        }
        return null;
    }

    private IEnumerator CheckCleared()
    {
        while (!isCleared)
        {
            enemies.RemoveAll(e => e == null);
            if (enemies.Count == 0)
            {
                isCleared = true;
                RoomManager.Instance.MarkRoomCleared(roomID);
                yield break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 a = transform.position + (Vector3)spawnMin;
        Vector3 b = transform.position + new Vector3(spawnMax.x, spawnMin.y, 0);
        Vector3 c = transform.position + (Vector3)spawnMax;
        Vector3 d = transform.position + new Vector3(spawnMin.x, spawnMax.y, 0);
        Gizmos.DrawLine(a, b); Gizmos.DrawLine(b, c); Gizmos.DrawLine(c, d); Gizmos.DrawLine(d, a);
    }
#endif
}
