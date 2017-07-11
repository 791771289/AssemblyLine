using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class GrabbableObject : MonoBehaviour {

    // The TYPE of pickup the object wiill take on
    // If the object is FREE - the object has no angle rotations on pickup
    // If the object is LOCK - the object has angle rotations on pickup
    public enum TYPE { FREE, LOCK }
    public TYPE curentType = TYPE.FREE;

    // The LOCK rotation for manipulating grabable objects, when you pick up an object,
    // it snaps to a different rotation besides remaining idle
    public Vector3 lockRotation = Vector3.zero;
   
}
