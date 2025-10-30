using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int minEnemies = 2;
    public int maxEnemies = 5;
    public Vector2 spawnMin = new Vector2(-6, -4);
    public Vector2 spawnMax = new Vector2(6, 4);

    [HideInInspector] public string roomID;
    private List<GameObject> enemies = new List<GameObject>();
    private bool isCleared;

    void Start()
    {
        if (RoomManager.Instance.IsRoomCleared(roomID))
        {
            isCleared = true;
            return;
        }

        int count = Random.Range(minEnemies, maxEnemies + 1);
        for (int i = 0; i < count; i++)
        {
            GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Vector2 pos = new Vector2(
                transform.position.x + Random.Range(spawnMin.x, spawnMax.x),
                transform.position.y + Random.Range(spawnMin.y, spawnMax.y)
            );

            GameObject e = Instantiate(prefab, pos, Quaternion.identity);
            enemies.Add(e);
        }

        StartCoroutine(CheckCleared());
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
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
