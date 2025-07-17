using System;
using UnityEngine;

public class Homlin : MonoBehaviour {
    public Transform Transform;

    public float Speed;

    public GameManager GameManager;
    
    public Rigidbody Rigidbody;

    public Transform FruitContainer;

    public float FruitHeight;

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
        GameManager.CollectCrop(other.collider.attachedRigidbody);
    }

    public void TakeFruit(Rigidbody crop) {
        int fruitCount = FruitContainer.childCount;
        
        crop.transform.parent = FruitContainer;
        crop.transform.localPosition = Vector3.zero + Vector3.up * fruitCount * FruitHeight;
        crop.detectCollisions = false;
        crop.isKinematic = true;
    }
    
}