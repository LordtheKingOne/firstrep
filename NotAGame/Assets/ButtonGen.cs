using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonGen : MonoBehaviour
{
    [Header("All Spawn Points")]
    public Transform sp1;
    public Transform sp2;
    public Transform sp3;
    public Transform sp4;
    public Transform sp5;

    public GameObject buttonPrefCollectible;
    public float spawnInterval4But = 8f;

    private List<Transform> SPs = new List<Transform>();

    private GameObject currentButton;
    private bool canSpawn = true;
    private Transform lastSpawnPoint = null; // Track the last spawn point

    void Start()
    {
        SPs.Add(sp1);
        SPs.Add(sp2);
        SPs.Add(sp3);
        SPs.Add(sp4);
        SPs.Add(sp5);

        StartCoroutine(SpawnBut());
    }

    IEnumerator SpawnBut()
    {
        while (true)
        {
            yield return new WaitUntil(() => canSpawn);

            SpawnButton();

            canSpawn = false;

            yield return new WaitUntil(() => currentButton == null);

            yield return new WaitForSeconds(3f);

            canSpawn = true;
        }
    }

    void SpawnButton()
    {
        if (SPs.Count == 0) return;

        Transform selectedSpawnPoint = GetDifferentSpawnPoint();

        currentButton = Instantiate(buttonPrefCollectible, selectedSpawnPoint.position, Quaternion.identity);

        lastSpawnPoint = selectedSpawnPoint; // Update last used spawn
    }

    Transform GetDifferentSpawnPoint()
    {
        List<Transform> possibleSpawns = new List<Transform>(SPs);

        if (lastSpawnPoint != null)
        {
            possibleSpawns.Remove(lastSpawnPoint);
        }

        return possibleSpawns[Random.Range(0, possibleSpawns.Count)];
    }
}
