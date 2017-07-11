using UnityEngine;
using System.Collections;

// Serializable so each attribute can be edited in the Unity Editor
[System.Serializable]
public class SpawnCandyInstance {

    // Candy Instance that is spawning down the line
    public GameObject candySpawning;

    // The number of candies that are spawned at this time instance
    public int numCandiesSpawned;

    // The time into the level that the candies will be spawning
    public float timeStartSpawning;

    // Spacing time between candy spawning to prevent a flood of candy running down the line
    public float timeBetweenCandies;

    // Tracks if this instance is already running
    private bool isCandySpawning = false;

    // Return the bool variable
    public bool IsCandySpawning()
    {
        return isCandySpawning;
    }

    // Set the candy instance to "it is spawning"
    public void CandySpawning()
    {
        isCandySpawning = true;
    }

    public void CandyNotSpawning()
    {
        isCandySpawning = false;
    }
}
