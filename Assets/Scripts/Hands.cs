﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
[RequireComponent(typeof(SphereCollider))]
public class Hands : MonoBehaviour {

    // Pull the steamvr tracked controller from the prefab object
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    void Start()
    {
        // Pull components from the steamvr object
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Scans the collider for other colliders
    void OnTriggerStay(Collider col)
    {
        // If the object is a part of a GrabbableObject class and can be picked up
        if(col.transform.GetComponent<GrabbableObject>() != null)
        {
            // Grabs the collider's rigidbody
            Rigidbody colRB = col.transform.GetComponent<Rigidbody>();

            // If the player wants to control the object by holding the trigger down
            if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                // Set the parent object to the controller transform
                col.transform.parent = transform;
                colRB.isKinematic = true;
                colRB.useGravity = false;
            }

            // If the player wants to control the object by pullin the trigger up
            if (controller.GetHairTriggerUp())
            {
                // Release the collider's parent
                col.transform.parent = null;
                colRB.isKinematic = false;
                colRB.useGravity = true;

                // "Throw" the object by giving it a velocity and angular velocity
                colRB.velocity = controller.velocity;
                colRB.angularVelocity = controller.angularVelocity;
            }
        }
    }
}

