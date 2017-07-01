using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PointerEnd : MonoBehaviour {

    // Pulling the SteamVR controller from its index
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    private Hands hands;

    void Start()
    {
        trackedObj = transform.parent.GetComponent<SteamVR_TrackedObject>();
        hands = transform.parent.GetComponent<Hands>();
    }

    // Updates while two colliders make contact
    void OnTriggerStay(Collider col)
    {

        // IF the Controller trigger is pressed and the pointer is on the UI element
        if (controller.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && transform.localPosition != Vector3.zero)
        {
            // Pull any UI components that are possible
            AssemblyLineSwitch assemblyLineSpace = col.transform.GetComponent<AssemblyLineSwitch>();
            PlayspaceSwitch playSpace = col.transform.GetComponent<PlayspaceSwitch>();
            Level level = col.transform.GetComponent<Level>();

            if(assemblyLineSpace != null)
            {
                Debug.Log("HIT AssemblyLineSwitch");
                hands.FlipHandControls(assemblyLineSpace);
                return;
            }

            if (playSpace != null)
            {
                Debug.Log("HIT Playspace");
                hands.FlipHandControls(playSpace);
                return;
            }

            if(level != null)
            {
                Debug.Log("HIT level");
                level.StartSpawningCandy();
                return;
            }
        }
    }
}
