using UnityEngine;
using System.Collections;

public class AssemblyLine : MonoBehaviour {

    // All three axis to decide what force to add to the grabbable object
    public enum AXIS { RED, GREEN, BLUE}
    public AXIS currentAxis = AXIS.RED;
     
    // The event that takes place when the two colliders make contact
	void OnTriggerStay(Collider col)
    {
        // Pull the GrabbableObject component if it exists on the collider
        GrabbableObject grabbableObject = col.transform.GetComponent<GrabbableObject>();

        // Do not continue because the Assembly Line only effects Grabbable Objects
        if (grabbableObject == null)
            return;

        // Move the Grabbable Object across the line based around the desired axis
        if (currentAxis == AXIS.RED) {
            col.transform.Translate(Time.deltaTime * Vector3.right);
        } else if (currentAxis == AXIS.BLUE) {
            col.transform.Translate(Time.deltaTime * Vector3.forward);
        } else {
            col.transform.Translate(Time.deltaTime * Vector3.up);
        }

    }
}
