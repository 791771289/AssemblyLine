using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Pointer : MonoBehaviour {

    // Line Attributes for the pointer
    [Header("LineRenderer Attributes")]
    public float lineWidth;
    public float lineLength;
    public Material lineMaterial;

    // Set objects that control the lines position
    [Header("LineRenderer Setup")]
    public Transform startPoint;
    public Transform endPoint;
    private Vector3 endPointScale;

    // Instance of linerenderer
    private LineRenderer lineRenderer;

    // Pulling the SteamVR controller from its index
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    void Start()
    {
        // Grabbing components from the game object
        lineRenderer = GetComponent<LineRenderer>();
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        endPoint.GetComponent<MeshRenderer>().material = lineMaterial;
        endPointScale = endPoint.localScale;

        // Update pointer's attributes
        lineRenderer.SetWidth(lineWidth, lineWidth);
        lineRenderer.material = lineMaterial;
    }

    void Update()
    {
        // Send out a ray to detect where the pointer should be pointing
        Ray ray = new Ray(startPoint.position, startPoint.forward);
        RaycastHit hit;
        bool hitting = Physics.Raycast(ray, out hit, lineLength, 1);

        // Constantly updated set points on the line
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint.position);

        // Update line state
        UpdateCursorLine(hitting, hit);

    }

    void UpdateCursorLine(bool hitting, RaycastHit hit)
    {
        // If hitting and the tags match what the point wants to point at
        if (hitting && hit.transform.tag == "UI")
        {
            // Line Enabled
            endPoint.position = hit.point;
        }
        else
        {
            // Line disabled
            endPoint.localPosition = Vector3.zero;
            endPoint.transform.localScale = Vector3.zero;
        }

    }
}
