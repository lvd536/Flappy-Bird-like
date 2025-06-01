using UnityEngine;

[System.Serializable]
public class GameData
{
    [SerializeField] [Range(0.0f, 1.0f)] public float musicVolume;
    [SerializeField] [Range(0.0f, 1.0f)] public float vfxVolume;
    [SerializeField] public int level;
    [SerializeField] public int score;
    [SerializeField] public int bestScore;
    [SerializeField] public int money;
    [SerializeField] public short currentSkinId;
    [SerializeField] public short[] bothSkinIds;

    public GameData()
    {
        currentSkinId = 0;
        level = 1;
        score = 0;
        bestScore = 0;
        money = 0;
        bothSkinIds = new short[7];
    }
}
