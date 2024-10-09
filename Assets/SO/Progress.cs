using UnityEngine;

[CreateAssetMenu(fileName = "Progress", menuName = "ScriptableObjects/Progress", order = 1)]
public class Progress : ScriptableObject
{
    public int lastPlayedMapIndex; // Lưu lại chỉ số của map cuối cùng mà người chơi đã chơi
    private int mapIndexLimit = 3;
    public int GetNowMap()
    {
        var currentMap = lastPlayedMapIndex;
        Debug.Log("Current Map - " + currentMap);
        return currentMap;
    }
    public int GetNextMap()
    {
        var nextMap = lastPlayedMapIndex + 1;
        if (nextMap < mapIndexLimit)
        {
            Debug.Log("Next Map - " + nextMap);
            return nextMap;
        }
        else
        {
            lastPlayedMapIndex = 1;
            return lastPlayedMapIndex;
        }
    }
}
