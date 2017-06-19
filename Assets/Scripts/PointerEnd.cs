using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PointerEnd : MonoBehaviour {

    // Pulling the SteamVR controller from its index
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    

    void Start()
    {
        trackedObj = transform.parent.GetComponent<SteamVR_TrackedObject>();
        Debug.Log("TEST 1");
    }

    // Updates while two colliders make contact
    void OnTriggerStay(Collider col)
    {
        // Pull any UI components
        PlayspaceSwitch playSpace = col.transform.GetComponent<PlayspaceSwitch>();

        // IF the Controller trigger is pressed and the pointer is on the UI element
        if (controller.GetHairTriggerDown() && transform.localPosition != Vector3.zero)
        {
            Debug.Log("TEST");

            if (playSpace != null)
            {
                playSpace.UpdatePlaySpace();
                return;
            }
        }
    }
}
