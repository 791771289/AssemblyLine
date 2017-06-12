using UnityEngine;
using System.Collections;

public class AssemblyLine : MonoBehaviour {

    // Assembly Line crossing speed for increased difficulty and/or slow paced gameplay
    public float speed = 1f;

    // Inverts moving directtion for more combinations
    public bool inverted = false;

    // All three axis to decide what force to add to the grabbable object
    public enum AXIS { RED, GREEN, BLUE}
    public AXIS currentAxis = AXIS.RED;
     
    // The event that takes place when the two colliders make contact
	void OnTriggerStay(Collider col)
    {
        // Pull the GrabbableObject component if it exists on the collider
        GrabbableObject grabbableObject = col.transform.GetComponent<GrabbableObject>();
        Candy candy = col.transform.GetComponent<Candy>();

        // Do not continue because the Assembly Line only effects Grabbable Objects
        // Depends on the objects pulled from the original object or if it is being manipulated by the player
        if (grabbableObject == null || candy == null || col.transform.parent != null)
            return;

        // Move the Grabbable Object across the line based around the desired axis
        // It also factors in an inverted variable to switch either forward or backwards in direction
        switch (currentAxis)
        {
            case AXIS.RED:
                if(!inverted)
                    col.transform.Translate(Time.deltaTime * speed * Vector3.right, Space.World);
                else
                    col.transform.Translate(-Time.deltaTime * speed * Vector3.right, Space.World);
                break;
            case AXIS.BLUE:
                if (!inverted)
                    col.transform.Translate(Time.deltaTime * speed * Vector3.forward, Space.World);
                else
                    col.transform.Translate(-Time.deltaTime *speed * Vector3.forward, Space.World);
                break;
            case AXIS.GREEN:
                if (!inverted)
                    col.transform.Translate(Time.deltaTime * speed * Vector3.up, Space.World);
                else
                    col.transform.Translate(-Time.deltaTime * speed * Vector3.up, Space.World);
                break;

        }
    }
}
