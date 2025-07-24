using UnityEngine;

[CreateAssetMenu(fileName = "MainGameConfig", menuName = "Scriptable Objects/MainGameConfig")]
public class MainGameConfig : ScriptableObject
{
    public int AppleTreeCost = 10;
    public int OrangeTreeCost = 30;
    public int OrangeGain = 5;
    
    public int DoorCost = 30;
    
    public int RareAmberGain = 10;
    
    public int WinGameFruitsCost = 1000;
    public int WinGameMineralsCost = 100;
}
