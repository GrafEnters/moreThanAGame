using System;
using System.Linq;
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
    
    [SerializeField]
    private SoundManager _soundManager;
    

    private bool IsDoorOpen = false;
    public bool IsHatBought = false;

    private DateTime _startGameTime;
    

    private void Start() {
        _startGameTime = DateTime.Now;
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

        if (itemContainer.childCount > 0) {
            _soundManager.PlaySound(SoundTypes.Sell);
            UpdateCount();
        }
    }

    public void BuyTree() {
        if (FruitsCount >= MainGameConfig.AppleTreeCost) {
            AppleTreeSpawner.CreateTree();
            FruitsCount -= MainGameConfig.AppleTreeCost;
            UpdateCount();
            _soundManager.PlaySound(SoundTypes.Buy);
        }
    }

    public void BuyDoor() {
        if (FruitsCount >= MainGameConfig.DoorCost) {
            FruitsCount -= MainGameConfig.DoorCost;
            Door.gameObject.SetActive(false);
            IsDoorOpen = true;
            UpdateCount();
            _soundManager.PlaySound(SoundTypes.Buy);
        }
    }

    public void BuyOrangeTree() {
        if (MineralsCount >= MainGameConfig.OrangeTreeCost) {
            OrangeTreeSpawner.CreateTree();
            MineralsCount -= MainGameConfig.OrangeTreeCost;
            UpdateCount();
            _soundManager.PlaySound(SoundTypes.Buy);
        }
    }

    public void BuyWinGame() {
        if (FruitsCount >= MainGameConfig.WinGameFruitsCost && MineralsCount >= MainGameConfig.WinGameMineralsCost) {
            FruitsCount -= MainGameConfig.WinGameFruitsCost;
            MineralsCount -= MainGameConfig.WinGameMineralsCost;
            GameUI.ShowWinGame();
            _soundManager.PlaySound(SoundTypes.Buy);
            
            //сохранить время до победы
            var endTime = DateTime.Now;
            TimeSpan timeSpan = endTime - _startGameTime;
            SaveLoadManager.GameData.Highscores.Add(timeSpan.ToString(@"mm\:ss"));
            SaveLoadManager.GameData.Highscores = SaveLoadManager.GameData.Highscores.TakeLast(3).ToList();
            SaveLoadManager.SaveGame();
        }
    }
}