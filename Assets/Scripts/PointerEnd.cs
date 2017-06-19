using UnityEngine;
using System.Collections;

public class PointerEnd : MonoBehaviour {
    
    // Pulling the SteamVR controller from its index
    //private SteamVR_TrackedObject trackedObj;
    //private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    void Start()
    {
        //trackedObj = transform.parent.GetComponent<SteamVR_TrackedObject>();
    }

    // Updates while two colliders make contact
    void OnTriggerStay(Collider col)
    {
        // Pull any UI components
        //PlayspaceSwitch playSpace = col.transform.GetComponent<PlayspaceSwitch>();

        Debug.Log("TEST 2");

       // if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        //{
       //     Debug.Log("TEST");
       // }
    }
}
