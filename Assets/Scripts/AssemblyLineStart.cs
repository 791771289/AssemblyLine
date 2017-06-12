using UnityEngine;
using System.Collections;

public class AssemblyLineStart : MonoBehaviour
{
    public GameObject[] candies;

    void Start()
    {
        foreach(GameObject obj in candies)
        {
            float offset = Random.Range(-.5f, .5f);
            Instantiate(obj, transform.position + new Vector3(0,0,offset), Quaternion.identity);
        }
    }

}
