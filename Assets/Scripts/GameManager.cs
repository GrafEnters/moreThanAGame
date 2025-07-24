using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameUI GameUI;

    public MainGameConfig MainGameConfig;

    [HideInInspector]
    public int FruitsCount;

    [HideInInspector]
    public int MineralsCount;

    [SerializeField]
    private TreesSpawner AppleTreeSpawner, OrangeTreeSpawner;

    public Homlin Homlin;

    [SerializeField]
    private GameObject Door;

    private bool IsDoorOpen = false;
    public bool IsHatBought = false;

    private void Start() {
        GameUI.Init(MainGameConfig);
        FruitsCount = MainGameConfig.AppleTreeCost;
        UpdateCount();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            var mouse = Input.mousePosition;
            var ray = Camera.main.ScreenPointToRay(mouse);

            if (Physics.Raycast(ray, out RaycastHit hit)) {
                var crop = hit.collider.attachedRigidbody;
                if (crop != null) {
                    CollectItem(crop);
                }
            }
        }
    }

    public void CollectItem(Rigidbody crop) {
        if (crop == null) {
            return;
        }

        if (crop.CompareTag("Apple") || crop.CompareTag("Orange") || crop.CompareTag("Amber") || crop.CompareTag("AmberRare")) {
            Homlin.TakeItem(crop);
        }
    }

    public void UpdateCount() {
        GameUI.SetCounters(FruitsCount, MineralsCount, IsDoorOpen, IsHatBought);
    }

    public void SellItems(Transform itemContainer) {
        foreach (Transform item in itemContainer) {
            if (item.CompareTag("Apple")) {
                FruitsCount++;
            } else if (item.CompareTag("Orange")) {
                FruitsCount += MainGameConfig.OrangeGain;
            } else if (item.CompareTag("Amber")) {
                MineralsCount++;
            } else if (item.CompareTag("AmberRare")) {
                MineralsCount += MainGameConfig.RareAmberGain;
            }
        }

        UpdateCount();
    }

    public void BuyTree() {
        if (FruitsCount >= MainGameConfig.AppleTreeCost) {
            AppleTreeSpawner.CreateTree();
            FruitsCount -= MainGameConfig.AppleTreeCost;
            UpdateCount();
        }
    }

    public void BuyDoor() {
        if (FruitsCount >= MainGameConfig.DoorCost) {
            FruitsCount -= MainGameConfig.DoorCost;
            Door.gameObject.SetActive(false);
            IsDoorOpen = true;
            UpdateCount();
        }
    }

    public void BuyOrangeTree() {
        if (MineralsCount >= MainGameConfig.OrangeTreeCost) {
            OrangeTreeSpawner.CreateTree();
            MineralsCount -= MainGameConfig.OrangeTreeCost;
            UpdateCount();
        }
    }

    public void BuyWinGame() {
        if (FruitsCount >= MainGameConfig.WinGameFruitsCost && MineralsCount >= MainGameConfig.WinGameMineralsCost) {
            FruitsCount -= MainGameConfig.WinGameFruitsCost;
            MineralsCount -= MainGameConfig.WinGameMineralsCost;
            GameUI.ShowWinGame();
        }
    }
}