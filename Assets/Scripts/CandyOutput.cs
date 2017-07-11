using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class CandyOutput : MonoBehaviour {
	
	void Update ()
    {
        // Output
        GetComponent<Text>().text = "Good: " + AssemblyLineEnd.goodCandyCount + "\n" + 
                                    "Bad: " + AssemblyLineEnd.badCandyCount + "\n" + 
                                    "Original: " + AssemblyLineEnd.originalCandyCount + "\n";
    }
}
