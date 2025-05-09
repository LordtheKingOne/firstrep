using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class ThreatSpawner : MonoBehaviour
{
    [Header("All Spawn Points")]
    public Transform cannonsp1;
    public Transform cannonsp2;
    public Transform cannonsp3;

    public Transform sawsp;
    public Transform fallersp1;
    public Transform fallersp2;
    public Transform fallersp3;
    public Transform fallersp4;
    public Transform macesp1;
    public Transform macesp2;
    public Transform macesp3;

    [Header("Threat Prefabs")]
    public GameObject cannonPrefab;
    public GameObject sawPrefab;
    public GameObject fallingObjectPrefab;
    public GameObject macePrefab;

    public ScoreManager scoreM;
    private int points;

    public float spawnInterval = 3f;

    [SerializeField] AudioSource levelup;
    public AudioClip nextlevel;


    private List<Transform> cannonSPs = new List<Transform>();
    private List<Transform> fallerSPs = new List<Transform>();
    private List<Transform> maceSPs = new List<Transform>();

    private List<GameObject> allThreats = new List<GameObject>();



    int previousLevel = 0; // Track last level
    int level = 0;

    void Update()
    {
        points = scoreM.currentScore;

        // Calculate current level
        level = points / 5;

        // If level increased
        if (level > previousLevel)
        {
            previousLevel = level;
            // Play level-up sound here
            levelup.Play();
            Debug.Log("Leveled Up to: " + level);
        }

        // Adjust spawnInterval
        spawnInterval = Mathf.Max(1f, 2.6f - (level * 0.2f));
    }

    void Start()
    {
        levelup.clip = nextlevel;
        // Add all spawn points to the list
        cannonSPs.Add(cannonsp1);
        cannonSPs.Add(cannonsp2);
        cannonSPs.Add(cannonsp3);

        fallerSPs.Add(fallersp1);
        fallerSPs.Add(fallersp2);
        fallerSPs.Add(fallersp3);
        fallerSPs.Add(fallersp4);
        maceSPs.Add(macesp1);
        maceSPs.Add(macesp2);
        maceSPs.Add(macesp3);


        // Add all threats to the list
        allThreats.Add(cannonPrefab);
        
        allThreats.Add(sawPrefab);
        allThreats.Add(fallingObjectPrefab);
        allThreats.Add(macePrefab);

        // Start the spawn loop
        StartCoroutine(SpawnThreats());
    }
    //scoreM.currentScore = points, make spawn interval shorter every 5 points by 0.2 at level 10 interval will be 1

    IEnumerator SpawnThreats()
    {
        while (true)
        {   
            yield return new WaitForSeconds(spawnInterval);

            GameObject selectedThreat = allThreats[Random.Range(0, allThreats.Count)];

            Transform selectedSpawnPoint = GetSpawnPointForThreat(selectedThreat);

            if (selectedThreat == fallingObjectPrefab)
            {
                Instantiate(selectedThreat, selectedSpawnPoint.position, Quaternion.Euler(0f, 0f, 180f));
            }
            else
            {
                Instantiate(selectedThreat, selectedSpawnPoint.position, Quaternion.identity);
            }


        }
    }

    Transform GetSpawnPointForThreat(GameObject threat)
    {
        if (threat == cannonPrefab)
        {
            // Only allow cannon-specific spawn points
            return cannonSPs[Random.Range(0, cannonSPs.Count)];
        }
        
        else if (threat == sawPrefab)
        {

            return sawsp;
        }
        else if (threat == fallingObjectPrefab)
        {

            return fallerSPs[Random.Range(0,fallerSPs.Count)];
        }
        else 
        {

            return maceSPs[Random.Range(0, maceSPs.Count)];
        }
    }
}

