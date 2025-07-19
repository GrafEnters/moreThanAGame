using System;
using TMPro;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
    
    public GameUI GameUI;
    public int CropsCount;
    public int MineralsCount;

    public int TreeCost = 10;
    public int TreeCreateRadius = 25;

    public Plant TreePrefab;

    public int OrangeTreeCost = 30;
    public int OrangeGain = 5;

    public int DoorCost = 30;
    
    public int RareAmberGain = 10;

    public int WinGameFruitsCost = 1000;
    public int WinGameMineralsCost = 100;
    
    public Plant OrangeTree;

    public Homlin Homlin;

    [SerializeField]
    private GameObject Door;

    private void Start() {
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

        if (crop.CompareTag("Apple") || crop.CompareTag("Orange") ||  crop.CompareTag("Amber")||  crop.CompareTag("AmberRare")) {
            Homlin.TakeItem(crop);
        }
    }

    private void UpdateCount() {
        GameUI.SetCounters(CropsCount, MineralsCount);
    }

  

    private void CreateTree(Plant tree) {
        var randomPos = new Vector3(Random.Range(-TreeCreateRadius, TreeCreateRadius), 0, Random.Range(-TreeCreateRadius, TreeCreateRadius));

        Instantiate(tree, randomPos, Quaternion.identity);
    }

    public void SellItems(Transform itemContainer) {
        foreach (Transform item in itemContainer) {
            if (item.CompareTag("Apple")) {
                CropsCount++;
            } else if (item.CompareTag("Orange")) {
                CropsCount += OrangeGain;
            } else if (item.CompareTag("Amber")) {
                MineralsCount++;
            }else if (item.CompareTag("AmberRare")) {
                MineralsCount+= RareAmberGain;
            }
        }

        UpdateCount();
    }

    public void BuyTree() {
        if (CropsCount >= TreeCost) {
            CreateTree(TreePrefab);
            CropsCount -= TreeCost;
            UpdateCount();
        }
    }
    
    public void BuyDoor() {
        if (CropsCount >= DoorCost) {
            CropsCount -= DoorCost;
            Door.gameObject.SetActive(false);
            UpdateCount();
        }
    }
    public void BuyOrangeTree() {
        if (MineralsCount >= OrangeTreeCost) {
            CreateTree(OrangeTree);
            MineralsCount -= OrangeTreeCost;
            UpdateCount();
        }
    }

    public void BuyWinGame() {
        if (CropsCount >= WinGameFruitsCost && MineralsCount >= WinGameMineralsCost) {
            CropsCount -= WinGameFruitsCost;
            MineralsCount -= WinGameMineralsCost;
            GameUI.ShowWinGame();
        }
    }
    
}