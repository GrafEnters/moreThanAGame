using System;
using TMPro;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
    public TextMeshProUGUI Text;
    public int CropsCount;

    public int TreeCost = 10;
    public int TreeCreateRadius = 25;

    public Plant TreePrefab;

    public int OrangeTreeCost = 30;
    public int OrangeGain = 5;
    public Plant OrangeTree;

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
                    CollectCrop(crop);
                }
            }
        }
    }

    public void CollectCrop(Rigidbody crop) {
        if (crop.CompareTag("Apple")) {
            CropsCount++;
            UpdateCount();
            Destroy(crop.gameObject);
        } else if (crop.CompareTag("Orange")) {
            CropsCount += OrangeGain;

            UpdateCount();
            Destroy(crop.gameObject);
        }
    }

    private void UpdateCount() {
        Text.text = CropsCount.ToString();
    }
    

    public void BuyTree() {
        if (CropsCount >= TreeCost) {
            CreateTree(TreePrefab);
            CropsCount -= TreeCost;
            UpdateCount();
        }
    }

    public void BuyOrangeTree() {
        if (CropsCount >= OrangeTreeCost) {
            CreateTree(OrangeTree);
            CropsCount -= OrangeTreeCost;
            UpdateCount();
        }
    }

    private void CreateTree(Plant tree) {
        var randomPos = new Vector3(Random.Range(-TreeCreateRadius, TreeCreateRadius), 0, Random.Range(-TreeCreateRadius, TreeCreateRadius));

        Instantiate(tree, randomPos, Quaternion.identity);
    }
}