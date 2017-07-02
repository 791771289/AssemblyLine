using UnityEngine;
using System.Collections;

public class PlayspaceSwitch : MonoBehaviour {

    // Materials for showoing current button state
    public Material idleColor;
    public Material changingTransformColor;

    void Start()
    {
        GetComponent<MeshRenderer>().material = idleColor;
    }

    // Button was pressed
    public void Highlight()
    {
        GetComponent<MeshRenderer>().material = changingTransformColor;
    }
    
    // Button not pressed
    public void Reset()
    {
        GetComponent<MeshRenderer>().material = idleColor;
    }
}
