using UnityEngine;
using System.Collections;

public class AssemblyLineStart : MonoBehaviour
{
    public GameObject[] candies;

    private float offsetRange = .3f;
     
    void Start()
    {
        StartCoroutine(SpawnCandy(.3f, .15f));
    }

    IEnumerator SpawnCandy(float refreshRate, float timeBetweenSpawns)
    {
        for(int i =0; i < 100; i++)
        {
            foreach (GameObject obj in candies)
            {
                float offset = Random.Range(-offsetRange, offsetRange);
                float quatX = Random.Range(0, 360f);
                float quatY = Random.Range(0, 360f);
                float quatZ = Random.Range(0, 360f);
                float quatW = Random.Range(0, 360f);

                Instantiate(obj, transform.position + new Vector3(0, 0, offset), new Quaternion(quatX, quatY, quatZ, quatW));
                yield return new WaitForSeconds(timeBetweenSpawns);
            }

            yield return new WaitForSeconds(1f / refreshRate);
        }

        yield break;
    }

}
