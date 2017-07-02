using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CandyOutput : MonoBehaviour {
    

	void Start () {
	
	}
	
	void Update ()
    {
        GetComponent<Text>().text = "Good: " + AssemblyLineEnd.goodCandyCount + "\n" + "Bad: " + AssemblyLineEnd.badCandyCount + "\n" + "Original: " + AssemblyLineEnd.originalCandyCount + "\n";
    }
}
