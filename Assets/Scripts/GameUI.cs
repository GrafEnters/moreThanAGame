using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI FruitsCounterText;

    [SerializeField]
    private TextMeshProUGUI MineralsCounterText;

    [SerializeField]
    private GameObject WinGamePanel;

    [SerializeField]
    private TextMeshProUGUI _appleTreeButtonText, _doorButtonText, _orangeTreeButtonText, _winButtonText;

    [SerializeField]
    private Button _appleTreeButton, _doorButton, _orangeTreeButton, _winButton;

    [SerializeField]
    private TextMeshProUGUI _strengthButtonText, _speedButtonText, _hatButtonText;

    [SerializeField]
    private Button _strengthButton, _speedButton, _hatButton;

    private MainGameConfig _config;
    private HomlinUpgradesConfig _upgradesConfig;

    public void Init(MainGameConfig config) {
        _config = config;
        _appleTreeButtonText.text = $"Купить дерево ({config.AppleTreeCost}ф)";
        _doorButtonText.text = $"Купить доступ к пляжу ({config.DoorCost}ф)";
        _orangeTreeButtonText.text = $"Купить апельсиновое дерево ({config.AppleTreeCost}м)";
        _winButtonText.text = $"Победить в игре ({config.WinGameFruitsCost}ф,{config.WinGameMineralsCost}м)";
    }

    public void InitHomlinUpgrades(HomlinUpgradesConfig config) {
        _upgradesConfig = config;
        _strengthButtonText.text = $"Улучшить грузоподъёмность ({config.StrengthIncreaseCost}ф)";
        _speedButtonText.text = $"Улучшить скорость ({config.SpeedIncreaseCost}м)";
        _hatButtonText.text = $"Купить модную шляпу ({config.HatCostFruits}ф,{config.HatCostMinerals}м)";
    }

    public void SetCounters(int fruitsAmount, int mineralsAmount, bool isDoorOpen, bool isHatBought) {
        FruitsCounterText.text = fruitsAmount.ToString();
        MineralsCounterText.text = mineralsAmount.ToString();
        UpdateButtons(fruitsAmount, mineralsAmount, isDoorOpen, isHatBought);
        if (isDoorOpen) {
            _doorButtonText.text = "Доступ к пляжу уже открыт!";
        }

        if (isHatBought) {
            _hatButtonText.text = "Модная шляпа уже куплена!";
        }
    }

    private void UpdateButtons(int fruitsAmount, int mineralsAmount, bool isDoorOpen, bool isHatBought) {
        _appleTreeButton.interactable = fruitsAmount >= _config.AppleTreeCost;
        _doorButton.interactable = fruitsAmount >= _config.DoorCost && !isDoorOpen;
        _orangeTreeButton.interactable = mineralsAmount >= _config.OrangeTreeCost;
        _winButton.interactable = mineralsAmount >= _config.WinGameMineralsCost && fruitsAmount >= _config.WinGameFruitsCost;

        _strengthButton.interactable = fruitsAmount >= _upgradesConfig.StrengthIncreaseCost;
        _speedButton.interactable = mineralsAmount >= _upgradesConfig.SpeedIncreaseCost;
        _hatButton.interactable = fruitsAmount >= _upgradesConfig.HatCostFruits && mineralsAmount >= _upgradesConfig.HatCostMinerals &&
                                  !isHatBought;
    }

    public void ShowWinGame() {
        WinGamePanel.SetActive(true);
    }

    public void ExitGame() {
        Application.Quit();
    }
}