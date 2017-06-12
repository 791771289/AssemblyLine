using UnityEngine;
using System.Collections;

public class AssemblyLineEnd : MonoBehaviour {

    // This is the enumerated type that decides what SHOULD end on this particular assembly line
    // CUBE - accepts cube candies
    // SPHERE - accepts sphere candies
    // CAPSULE - accepts capsule candies
    // ORIGINAL - the original line that sends all unsorted candy
    public enum ENDTYPE { CUBE, SPHERE, CAPSULE, ORIGINAL}
    public ENDTYPE currentEndType = ENDTYPE.CUBE;

    // Number of candies that pass through this endpoint
    private static int goodCandyCount;
    private static int badCandyCount;
    private static int originalCandyCount;

    // Initialization
    void Start()
    {
        goodCandyCount = 0;
        badCandyCount = 0;
        originalCandyCount = 0;
    }

    // The event that takes place when the two colliders make contact
    void OnTriggerEnter(Collider col)
    {
        // Pull the GrabbableObject component if it exists on the collider
        GrabbableObject grabbableObject = col.transform.GetComponent<GrabbableObject>();
        Candy candy = col.transform.GetComponent<Candy>();

        // Do not continue because the Assembly Line only effects Grabbable Objects and Candy Objects
        if (grabbableObject == null || candy == null)
            return;

        // Add a count for how many items have passed the end

        //Pull the candy enumerated type
        Candy.CANDYTYPE candyType = candy.getCandyType();

        // If the types of candy and assembly line are matching
        if((candyType == Candy.CANDYTYPE.CAPSULE && currentEndType == ENDTYPE.CAPSULE) ||
           (candyType == Candy.CANDYTYPE.CUBE && currentEndType == ENDTYPE.CUBE) ||
           (candyType == Candy.CANDYTYPE.SPHERE && currentEndType == ENDTYPE.SPHERE))
        {
            goodCandyCount++;
            Debug.Log("Candy MATCHES End");
        // If the assembly line is the original line carrying unsorted candy
        } else if(currentEndType == ENDTYPE.ORIGINAL)
        {
            originalCandyCount++;
            Debug.Log("Candy HITS Original End");
        // If the line does not match with the candy type
        } else{
            badCandyCount++;
            Debug.Log("Candy DOES NOT MATCH End");
        }

        // Destroy the game object after it has been scored and recorded
        Destroy(col.gameObject);
    }
}
