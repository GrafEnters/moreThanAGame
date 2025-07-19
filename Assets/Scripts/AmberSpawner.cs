using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AmberSpawner : MonoBehaviour {
    [SerializeField]
    private List<GameObject> Ambers;

    public float SpawnRate = 10;

    private void Start() {
        InvokeRepeating(nameof(CreateRandomAmber), 0, SpawnRate);
    }

    private void CreateRandomAmber() {
        var amberPrefab = Ambers[Random.Range(0, Ambers.Count)];
        CreateCopy(amberPrefab);
    }

    private void CreateCopy(GameObject amber) {
        var copy = Instantiate(amber, amber.transform.position, Quaternion.identity);
        copy.SetActive(true);
    }
}