using UnityEngine;
using System.Collections;

public class PlayspaceSwitch : MonoBehaviour {

    // Types of transfrom changes
    // UP - closer to the assembly line
    // DOWN - further away
	public enum TYPES { UP, DOWN}
    public TYPES currenttType;

    // Playspace transform to manipulate
    public Transform playSpace;

    // Step for how much the transform moves everytime the switch is pressesd
    private float stepOffeset = 1f;

    public void UpdatePlaySpace()
    {
        if(currenttType == TYPES.UP)
        {
            playSpace.position += new Vector3(0, 0, stepOffeset);
        } else
        {
            playSpace.position += new Vector3(0, 0, -stepOffeset);
        }
    }
}
