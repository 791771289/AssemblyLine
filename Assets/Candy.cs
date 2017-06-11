using UnityEngine;
using System.Collections;

public class Candy : MonoBehaviour {

	public enum CANDYTYPE { CUBE, SPHERE, CAPSULE }
    public CANDYTYPE currentType = CANDYTYPE.CUBE;

    public CANDYTYPE getCandyType()
    {
        return currentType;
    }
}
