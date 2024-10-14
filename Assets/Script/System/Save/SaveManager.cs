using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public Progress progress;

    public void CompleteMap(int mapIndex)
    {
        progress.lastPlayedMapIndex = mapIndex;
        Debug.Log("Map updated: " + mapIndex);
    }
    public void CompleteGame()
    {
        progress.lastPlayedMapIndex = 1;
        Debug.Log("Map updated: " + progress.lastPlayedMapIndex);
    }
}
