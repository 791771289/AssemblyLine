using UnityEngine;
using System.Collections;

public class PointerEnd : MonoBehaviour {

    // Pulling the SteamVR controller from its index
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    // Parent hands for controller feedback
    private Hands hands;

    // All components that the pointer can interact with
    private AssemblyLineSwitch assemblyLineSpace;
    private PlayspaceSwitch playSpace;
    private Level level;

    void Start()
    {
        trackedObj = transform.parent.GetComponent<SteamVR_TrackedObject>();
        hands = transform.parent.GetComponent<Hands>();
        
    }

    // The instance the pointer end has made contact with another collider
    void OnTriggerEnter(Collider col)
    {
        // Pull any UI components that are possible
        assemblyLineSpace = col.transform.GetComponent<AssemblyLineSwitch>();
        playSpace = col.transform.GetComponent<PlayspaceSwitch>();
        level = col.transform.GetComponent<Level>();
    }

    // Updates while two colliders make contact
    void OnTriggerStay(Collider col)
    {

        // IF the Controller trigger is pressed and the pointer is on the UI element
        if (controller.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && transform.localPosition != Vector3.zero)
        {

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
                level.StartLevel();
                return;
            }
        }
    }
    
}
