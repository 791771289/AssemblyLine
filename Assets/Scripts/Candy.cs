using UnityEngine;
using System.Collections;

public class Candy : MonoBehaviour {

    // Differences in candy types
	public enum CANDYTYPE { CUBE, SPHERE, CAPSULE }
    public CANDYTYPE currentType = CANDYTYPE.CUBE;

    // Is the candy wrapped or not
    public bool wrappedCandy;

    public CANDYTYPE getCandyType()
    {
        return currentType;
    }

    public bool getWarppedCandy()
    {
        return wrappedCandy;
    }
}
