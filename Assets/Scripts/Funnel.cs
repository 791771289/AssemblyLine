using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class Funnel : MonoBehaviour {

    // The Bottom transform that is used to instantiate wrapped candies
    public Transform bottom;

    // The possible wraped candies that come out of the funnel
    public GameObject wrappedCapsule;
    public GameObject wrappedCube;
    public GameObject wrappedSphere;

    // The event that takes place when the two colliders make contact
    void OnTriggerEnter(Collider col)
    {
        // Pull the Candy oibject from the game object
        Candy candy = col.transform.GetComponent<Candy>();

        // Test if the object script exists
        if (candy == null)
            return;

        // Random location and rotation generation
        float quatX = Random.Range(0, 360f);
        float quatY = Random.Range(0, 360f);
        float quatZ = Random.Range(0, 360f);
        float quatW = Random.Range(0, 360f);

        // Spawn the wrapped candy based on the given unwrapped candy
        if (candy.getCandyType() == Candy.CANDYTYPE.CAPSULE) {
            Instantiate(wrappedCapsule, bottom.position, new Quaternion(quatX, quatY, quatZ, quatW));

        } else if(candy.getCandyType() == Candy.CANDYTYPE.CUBE){
            Instantiate(wrappedCube, bottom.position, new Quaternion(quatX, quatY, quatZ, quatW));

        } else if(candy.getCandyType() == Candy.CANDYTYPE.SPHERE){
            Instantiate(wrappedSphere, bottom.position, new Quaternion(quatX, quatY, quatZ, quatW));

        } else
        {
            Debug.Log("FUNNEL: Candies do not match funnel");
        }

        // Destroy the unwrapped candy
        Destroy(col.gameObject);
    }
}
