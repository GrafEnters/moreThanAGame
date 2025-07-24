using UnityEngine;

[CreateAssetMenu(fileName = "HomlinUpgradesConfig", menuName = "Scriptable Objects/HomlinUpgradesConfig")]
public class HomlinUpgradesConfig : ScriptableObject {

    public int StrengthIncrease = 2;
    public int StrengthIncreaseCost = 5;
    
    public float SpeedIncrease = 0.01f;
    public int SpeedIncreaseCost = 10;

    public int HatCostFruits = 10;
    public int HatCostMinerals = 10;
}
