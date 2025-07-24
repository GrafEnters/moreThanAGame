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

    private MainGameConfig _config;

    public void Init(MainGameConfig config) {
        _config = config;
        _appleTreeButtonText.text = $"Купить дерево ({config.AppleTreeCost}ф)";
        _doorButtonText.text = $"Купить доступ к пляжу ({config.DoorCost}ф)";
        _orangeTreeButtonText.text = $"Купить апельсиновое дерево ({config.AppleTreeCost}м)";
        _winButtonText.text = $"Победить в игре ({config.WinGameFruitsCost}ф,{config.WinGameMineralsCost}м)";
    }

    public void SetCounters(int fruitsAmount, int mineralsAmount, bool isDoorOpen) {
        FruitsCounterText.text = fruitsAmount.ToString();
        MineralsCounterText.text = mineralsAmount.ToString();
        UpdateButtons(fruitsAmount, mineralsAmount, isDoorOpen);
        if (isDoorOpen) {
            _doorButtonText.text = "Доступ к пляжу уже открыт!";
        }
    }

    private void UpdateButtons(int fruitsAmount, int mineralsAmount, bool isDoorOpen) {
        _appleTreeButton.interactable = fruitsAmount >= _config.AppleTreeCost;
        _doorButton.interactable = fruitsAmount >= _config.DoorCost && !isDoorOpen;
        _orangeTreeButton.interactable = mineralsAmount >= _config.OrangeTreeCost;
        _winButton.interactable = mineralsAmount >= _config.WinGameMineralsCost && fruitsAmount >= _config.WinGameFruitsCost;
    }

    public void ShowWinGame() {
        WinGamePanel.SetActive(true);
    }
}