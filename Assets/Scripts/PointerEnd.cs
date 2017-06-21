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
        if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && transform.localPosition != Vector3.zero)
        {
            // Pull any UI components
            PlayspaceSwitch playSpace = col.transform.GetComponent<PlayspaceSwitch>();

            if (playSpace != null)
            {
                Debug.Log("TEST HIT");
                hands.FlipHandControls(playSpace);
                return;
            }
        }
    }
}
