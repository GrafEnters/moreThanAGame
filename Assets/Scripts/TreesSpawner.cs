using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreesSpawner : MonoBehaviour {
    [SerializeField]
    private Plant TreePrefab;
    
    [SerializeField]
    private int TreeCreateRadius = 25;
    
    public void CreateTree() {
        var randomShift = new Vector3(Random.Range(-TreeCreateRadius, TreeCreateRadius), 0, Random.Range(-TreeCreateRadius, TreeCreateRadius));
        Instantiate(TreePrefab, transform.position + randomShift, Quaternion.identity);
    }

    private void OnDrawGizmosSelected() {
       Gizmos.color = Color.yellow;
       Gizmos.DrawWireSphere(transform.position,TreeCreateRadius);
    }
}