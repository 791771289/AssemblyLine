using UnityEngine;
using System.Collections;

[System.Serializable]
public class Level : MonoBehaviour {

    // Main AssemblyLine Start spawn point
    public Transform spawnPoint;

    // All of the candy spawning for this level includiong all
    // SpawnCandyInstance attributes
    public SpawnCandyInstance[] spawningCandies;

    // A set range for random placement on the assembly line
    private float offsetRange = .3f;

    // Determining variable if candyt is spawning
    private bool spawningCandy;

    // Timing counter to keep track of how long the candy hsa been spwaning
    private float count;

    // Keeping track of the amount of candy instances that are spawned onto the line
    private int instancesDone = 0;

    void Start()
    {
        // Reset counter
        count = 0;
        spawningCandy = false;

        
    }

    void FixedUpdate()
    {
        // If the level was selected to start spawning candy
        if (spawningCandy)
        {
            // Start counting up
            count += Time.deltaTime;

            // Scan all of the candy to be spawned in the level for what can start spawning
            foreach (SpawnCandyInstance instance in spawningCandies)
            {
                // If the starting passtime for spawning candy surpasses and has the candy already spawned
                if (instance.timeStartSpawning < count & instance.IsCandySpawning() == false)
                {
                    // Spawn Candy and set the candy to spawning
                    StartCoroutine(SpawnCandy(instance));
                }
            }

            // Set all other level objects to disabled
            ScanLevels(false);
        } else
        {
            // Set all other level objects to disabled
            ScanLevels(true);
        }
    }

    public void ScanLevels(bool setValue)
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            Level scannedLevel = transform.parent.GetChild(i).GetComponent<Level>();
            if (!scannedLevel.Equals(this))
            {
                scannedLevel.enabled = setValue;
            }
        }
    }

    // Method sent to start spawning candy
    public void StartSpawningCandy()
    {
        spawningCandy = true;
    }

    // Method sent to start spawning candy
    public void FinishSpawningCandy()
    {
        spawningCandy = false;
    }

    public IEnumerator SpawnCandy(SpawnCandyInstance instance)
    {
        // Set the instance bool variable to isSpawning
        instance.CandySpawning();

        // Spawn every candy that is within the instance with a time gap
        for (int i = 0; i < instance.numCandiesSpawned; i++)
        {
            // Random location and rotation generation
            float offset = Random.Range(-offsetRange, offsetRange);
            float quatX = Random.Range(0, 360f);
            float quatY = Random.Range(0, 360f);
            float quatZ = Random.Range(0, 360f);
            float quatW = Random.Range(0, 360f);

            // Create a candy object at the desired position and rotation
            Instantiate(instance.candySpawning, spawnPoint.position + new Vector3(0, 0, offset), new Quaternion(quatX, quatY, quatZ, quatW));
            yield return new WaitForSeconds(instance.timeBetweenCandies);
        }

        // When the candy has finished spawning, add up how many instances are done
        instancesDone++;
        Debug.Log(instancesDone);

        // If all candy spaning instances are donw spawning
        if (instancesDone == spawningCandies.Length)
        {
            Debug.Log("LEVEL FINISHED");
            FinishSpawningCandy();
        }

        yield break;
    }
}
