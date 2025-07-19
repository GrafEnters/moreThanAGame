using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI FruitsCounterText;

    [SerializeField]
    private TextMeshProUGUI MineralsCounterText;

    [SerializeField]
    private GameObject WinGamePanel;

    public void SetCounters(int fruitsAmount, int mineralsAmount) {
        FruitsCounterText.text = fruitsAmount.ToString();
        MineralsCounterText.text = mineralsAmount.ToString();
    }

    public void ShowWinGame() {
        WinGamePanel.SetActive(true);
    }
}