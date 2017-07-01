using UnityEngine;
using System.Collections;

public class AssemblyLineSwitch : MonoBehaviour {

    public Material idleColor;
    public Material changingTransformColor;

    void Start()
    {
        GetComponent<MeshRenderer>().material = idleColor;
    }

    public void Highlight()
    {
        GetComponent<MeshRenderer>().material = changingTransformColor;
    }

    public void Reset()
    {
        GetComponent<MeshRenderer>().material = idleColor;
    }
}
