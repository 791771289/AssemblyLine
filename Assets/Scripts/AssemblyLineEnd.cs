using UnityEngine;
using System.Collections;

public class AssemblyLineEnd : MonoBehaviour {

    private int count = 0;

    // The event that takes place when the two colliders make contact
    void OnTriggerEnter(Collider col)
    {
        // Pull the GrabbableObject component if it exists on the collider
        GrabbableObject grabbableObject = col.transform.GetComponent<GrabbableObject>();

        // Do not continue because the Assembly Line only effects Grabbable Objects
        if (grabbableObject == null)
            return;

        // Add a count for how many items have passed the end
        count++;
        Debug.Log("Count: " + count);

        // Destroy the game object after it has been scored and recorded
        Destroy(col.gameObject);
    }
}
