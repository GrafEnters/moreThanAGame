using System;
using UnityEngine;

public class Homlin : MonoBehaviour {
    public Transform Transform;

    public float Speed;

    public GameManager GameManager;
    
    public Rigidbody Rigidbody;

    public Transform ItemsContainer;

    public float ItemHeight;
    private bool IsSelling;

    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            Rigidbody.MovePosition(Rigidbody.position + Vector3.forward * Speed);
        }

        if (Input.GetKey(KeyCode.A)) {
            Rigidbody.MovePosition(Rigidbody.position + Vector3.left * Speed);
        }

        if (Input.GetKey(KeyCode.S)) {
            Rigidbody.MovePosition(Rigidbody.position + Vector3.back * Speed);
        }

        if (Input.GetKey(KeyCode.D)) {
            Rigidbody.MovePosition(Rigidbody.position + Vector3.right * Speed);
        }
    }

    private void OnCollisionEnter(Collision other) {
        GameManager.CollectItem(other.collider.attachedRigidbody);
    }

    public void TakeItem(Rigidbody crop) {
        int fruitCount = ItemsContainer.childCount;
        crop.transform.parent = ItemsContainer;
        crop.transform.localPosition = Vector3.zero + Vector3.up * fruitCount * ItemHeight;
       
        crop.detectCollisions = false;
        crop.isKinematic = true;
    }

    public void SellItems() {
        if (IsSelling) {
            return;
        }
        IsSelling = true;
        GameManager.SellItems(ItemsContainer);
        foreach (Transform child in ItemsContainer) {
            Destroy(child.gameObject);
        }
    }

    private void LateUpdate() {
        IsSelling = false;
    }
}