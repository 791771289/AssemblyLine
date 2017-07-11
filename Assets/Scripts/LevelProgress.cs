using UnityEngine;
using System.Collections;

// This class keeps track of player stats from star count, locked/unlocked states,
// and score. This is acentral place for saved data and easy access across the whole
// game. 
public class LevelProgress : MonoBehaviour {

    // Level Parent
    public Transform levelParent;

    // Current and most advanced unlocked level the player is currently on
    public static int currentLevel;

    // Array of all locked/unlocked states of levels
    public static bool[] levelStates;

    // Array of all star counts for all levels
    public static int[] levelStarCount;

    // Array of all scores for all levels
    public static int[] levelScoreCount;

    void Start()
    {
        currentLevel = 1;
        levelStates = new bool[5];
        levelStarCount = new int[5];
        levelScoreCount = new int[5];
    }

    public void SaveData(int levelID, int starCount, int score)
    {
        // Adjust currentt level
        currentLevel = levelID + 1;
        levelParent.GetChild(levelID).GetComponent<Level>().UnlockLevel();

        // Adjust levels that are locked and unlocked to move the player to the next level
        levelStates[levelID + 1] = true;

        // Update arrays with scoring data
        levelStarCount[levelID] = starCount;
        levelScoreCount[levelID] = score;
    }
}
