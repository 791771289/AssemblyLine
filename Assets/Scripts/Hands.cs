using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
[RequireComponent(typeof(SphereCollider))]
public class Hands : MonoBehaviour
{

    // Pull the steamvr tracked controller from the prefab object
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    // Variable to store whther or not the player wants to adjust their placement relative to the Line
    private bool changingSpace;

    // Variable to store whther or not the player wants to adjust the line relative to the ground
    private bool changingLine;

    // The Transform to store the playspace so the changingSpace variable has something to manipulate
    public Transform playSpace;

    // The Transform to store the main assembly line so the changingLine variable has something to manipulate
    public Transform mainAssemblyLine;

    // The two switches that are contolled by the play
    public AssemblyLineSwitch assemblyLineSwitch;
    public PlayspaceSwitch playSpaceSwitch;

    // Step for how much the transform moves everytime the switch is pressesd
    private float stepOffeset = .075f;

    // Step for how much the transform moves everytime the switch is pressesd
    private float lineOffeset = .08f;

    // Variable to hold starting childdren count when keeping track of grabbable objects to 
    // prevent multiple objects grabbed at same time
    private int startingChildCount;

    void Start()
    {
        // Pull components from the steamvr object
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        changingSpace = false;
        changingLine = false;

        startingChildCount = transform.childCount;
    }

    void Update()
    {
        // Add playspace controls if button is pressed
        if (changingSpace)
            UpdatePlayspaceControls();

        // Add assemblyLine controls if button is pressed
        if (changingLine)
            UpdateAssemblyLineControls();

        UpdateMenuButton();

    }

    private void UpdateMenuButton()
    {
        // Scan for if the player wants to end the level they're on by pressing the menu button
        if (controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            bool interrupted = false;
            for (int i = 0; i < GameObject.FindObjectsOfType<Level>().Length; i++)
            {
                interrupted = GameObject.FindObjectsOfType<Level>()[i].enabled;
            }

            if (interrupted)
            {
                Debug.Log("Level Interrupted");
                for (int i = 0; i < GameObject.FindObjectsOfType<Level>().Length; i++)
                {
                    if (GameObject.FindObjectsOfType<Level>()[i].enabled)
                    {
                        // Stop spawning candy for this level and reenable all other levels to be selected
                        GameObject.FindObjectsOfType<Level>()[i].FinishSpawningCandy();
                        GameObject.FindObjectsOfType<Level>()[i].ScanLevels(true);

                        //Destroy all remaining candy
                        for(int j = 0; j < GameObject.FindObjectsOfType<Candy>().Length; j++)
                        {
                            Destroy(GameObject.FindObjectsOfType<Candy>()[j].gameObject);
                        }
                    }

                }
            }
        }
    }

    // Scans the collider for other colliders
    void OnTriggerStay(Collider col)
    {
        Debug.Log("Child Count : " + transform.childCount);

        // If the object is a part of a GrabbableObject class and can be picked up
        if (col.transform.GetComponent<GrabbableObject>() != null)
        {
            // Grabs the collider's rigidbody
            Rigidbody colRB = col.transform.GetComponent<Rigidbody>();

            // If the player wants to control the object by holding the trigger down
            if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && transform.childCount <= startingChildCount)
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

    // This method is called when the player presses on the "changing playspace adjustment"
    // to move the playspace closer or away from the assembly line
    public void FlipHandControls(PlayspaceSwitch x)
    {
        changingSpace = !changingSpace;

        // Change playspace siwtch materials to match current state
        if (changingSpace)
        {
            x.Highlight();

            // Revert the other switch as obsolete so you do not control both as once
            changingLine = false;
            assemblyLineSwitch.Reset();
        }
        else
        {
            x.Reset();
        }
    }

    // This method is called when the player presses on the "changing playspace adjustment"
    // to move the playspace closer or away from the assembly line
    public void FlipHandControls(AssemblyLineSwitch x)
    {
        changingLine = !changingLine;

        // Change playspace siwtch materials to match current state
        if (changingLine)
        {
            x.Highlight();

            // Revert the other switch as obsolete so you do not control both as once
            changingSpace = false;
            playSpaceSwitch.Reset();
        }
        else
        {
            x.Reset();
        }
    }

    void UpdatePlayspaceControls()
    {
        // If the touchpad is pressed
        if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("Y - axis: " + controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y);

            // If the vertical position of your finger on the press is greater than 0, move closer to the line
            if (controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y > 0)
            {
                playSpace.position += new Vector3(0f, 0f, -stepOffeset);
            }
            else
            {
                playSpace.position += new Vector3(0f, 0f, stepOffeset);
            }
        }
    }

    void UpdateAssemblyLineControls()
    {
        // If the touchpad is pressed
        if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("Y - axis: " + controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y);

            // If the vertical position of your finger on the press is greater than 0, move closer to the line
            if (controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y > 0)
            {
                mainAssemblyLine.position += new Vector3(0f, lineOffeset, 0f);
            }
            else
            {
                mainAssemblyLine.position += new Vector3(0f, -lineOffeset, 0f);
            }
        }
    }
}
