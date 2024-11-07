using System.Collections;
using UnityEngine;

public class ProceduralMapGenerator : MonoBehaviour
{
    public GameObject[] wallPrefabs;       // Array of wall prefabs
    public Transform playerTransform;      // Reference to player transform
    public float wallGap = 2f;             // Gap between walls in vertical section
    public float wallLifetime = 10f;       // Time to destroy old walls

    public bool generateOnce = true;       // Toggle for single or continuous generation
    public GameObject activationTrigger;   // Trigger object for activating generation

    private bool generationActivated = false;  // Tracks if generation is active
    private float lastWallY;                   // Tracks last Y position of generated wall

    private void Start()
    {
        lastWallY = playerTransform.position.y;   // Initialize position
        if (!generateOnce) StartCoroutine(RemoveOldWalls());  // Start wall cleanup if generating infinitely
    }

    private void Update()
    {
        // Activate generation when player passes the activationTrigger
        if (!generationActivated && playerTransform.position.y >= activationTrigger.transform.position.y)
        {
            generationActivated = true;

            if (generateOnce)
            {
                // Generate a single set of walls
                GenerateWallSet();
            }
            else
            {
                // Start continuous wall generation
                StartCoroutine(GenerateWallsContinuously());
            }
        }
    }

    private void GenerateWallSet()
    {
        // Generate walls upward from the activation point
        for (int i = 0; i < 5; i++)  // Adjust the number of walls in the set as needed
        {
            GenerateWall();
        }
    }

    private IEnumerator GenerateWallsContinuously()
    {
        while (generationActivated)
        {
            GenerateWall();
            yield return new WaitForSeconds(wallGap);  // Control frequency of generation
        }
    }

    private void GenerateWall()
    {
        lastWallY += wallGap;

        // Randomly select a wall prefab
        int randomIndex = Random.Range(0, wallPrefabs.Length);
        GameObject selectedWall = wallPrefabs[randomIndex];

        // Instantiate wall at the specified Y position
        Vector3 wallPosition = new Vector3(0f, lastWallY, 0f);
        GameObject newWall = Instantiate(selectedWall, wallPosition, Quaternion.identity);
        newWall.transform.SetParent(transform);

        // Start removal routine if not in single-generation mode
        if (!generateOnce) StartCoroutine(RemoveWall(newWall));
    }

    private IEnumerator RemoveOldWalls()
    {
        while (true)
        {
            yield return new WaitForSeconds(wallLifetime);
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

            // Remove walls below the player
            foreach (GameObject wall in walls)
            {
                if (wall.transform.position.y < playerTransform.position.y - (wallGap * 2))
                {
                    Destroy(wall);
                }
            }
        }
    }

    private IEnumerator RemoveWall(GameObject wall)
    {
        yield return new WaitForSeconds(wallLifetime);
        Destroy(wall);
    }
}
