using UnityEngine;
using System.Collections;

public class AssemblyLineStart : MonoBehaviour
{
    // Implement all of the desired Candies
    public GameObject[] candies;

    // A set range for random placement on the assembly line
    private float offsetRange = .3f;
     
    // Instantiation
    void Start()
    {
        // Start spawning
        StartCoroutine(SpawnCandy(.2f, 1f));
    }

    IEnumerator SpawnCandy(float refreshRate, float timeBetweenSpawns)
    {
        // Repeated 100 times
        for(int i =0; i < 100; i++)
        {
            foreach (GameObject obj in candies)
            {
                // Random location and rotation generation
                float offset = Random.Range(-offsetRange, offsetRange);
                float quatX = Random.Range(0, 360f);
                float quatY = Random.Range(0, 360f);
                float quatZ = Random.Range(0, 360f);
                float quatW = Random.Range(0, 360f);

                // Create a candy object at the desired position and rotation
                Instantiate(obj, transform.position + new Vector3(0, 0, offset), new Quaternion(quatX, quatY, quatZ, quatW));

                // Wait an alotted amount of time before the next candy
                yield return new WaitForSeconds(timeBetweenSpawns);
            }

            yield return new WaitForSeconds(1f / refreshRate);
        }

        yield break;
    }

}
