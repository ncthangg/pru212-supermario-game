using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public Progress progress;

    public void CompletedMap(int mapIndex)
    {
        progress.lastPlayedMapIndex = mapIndex;
        Debug.Log("Map updated: " + mapIndex);
    }
    public void CompletedGame()
    {
        progress.lastPlayedMapIndex = 1;
        Debug.Log("Map updated: " + progress.lastPlayedMapIndex);
    }
}
